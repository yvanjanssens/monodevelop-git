using System;
using System.Collections.Generic;
using System.IO;

using MonoDevelop.Components.Commands;
using MonoDevelop.Core.Gui;

using GitSharp.Core;
using GitSharp.Core.Transport;

namespace MonoDevelop.VersionControl.Git
{
	public class CloneRepositoryCommand : CommandHandler
	{
		protected override void Run ()
		{
			var cloneDialog = new CloneRepositoryDialog ();
			cloneDialog.Run ();
			cloneDialog.Destroy ();
			
			var repositoryPath = cloneDialog.RepositoryPath;
			URIish source = new URIish (repositoryPath);
			var originName = cloneDialog.OriginName;
			var destination = cloneDialog.WorkingDirectory;
			var workingDirectory = Path.Combine (destination, Constants.DOT_GIT);
			
			if (string.IsNullOrEmpty (originName))
				originName = Constants.DEFAULT_REMOTE_NAME;
			
			var rep = new GitSharp.Core.Repository (new DirectoryInfo (workingDirectory));
			rep.Create ();
			rep.Config.setBoolean ("core", null, "bare", false);
			rep.Config.save ();
			
			var rc = new RemoteConfig (rep.Config, originName);
			rc.AddURI (source);
			rc.AddFetchRefSpec (new RefSpec ().SetForce (true).SetSourceDestination (
					Constants.R_HEADS + "*", 
					Constants.R_REMOTES + originName + "/*"));
			rc.Update (rep.Config);
			rep.Config.save ();
			
			var tn = Transport.Open (rep, originName);
			FetchResult fetchResult = null;
			try 
			{
				fetchResult = tn.fetch (new NullProgressMonitor (), null);
			} 
			catch 
			{
				tn.Dispose ();
			}
			
			GitSharp.Core.Ref branch = null;
			if (fetchResult != null) 
			{
				var headId = fetchResult.GetAdvertisedRef (Constants.HEAD);
				var availableRefs = new List<GitSharp.Core.Ref> ();
				
				foreach (GitSharp.Core.Ref r in fetchResult.AdvertisedRefs.Values) 
				{
					var n = r.Name;
					if (!n.StartsWith (Constants.R_HEADS))
						continue;
					
					availableRefs.Add (r);
					if (headId == null || branch != null)
						continue;
					
					if (r.ObjectId.Equals (headId.ObjectId))
						branch = r;
				}
				
				availableRefs.Sort (RefComparator.INSTANCE);
				
				if (headId != null && branch == null)
					branch = headId;
			}
			
			if (branch != null) 
			{
				if (!Constants.HEAD.Equals (branch.Name)) 
				{
					rep.WriteSymref (Constants.HEAD, branch.Name);
					GitSharp.Core.Commit commit = rep.MapCommit (branch.ObjectId);
					var update = rep.UpdateRef (Constants.HEAD);
					update.NewObjectId = commit.CommitId;
					update.ForceUpdate ();
					
					var index = new GitIndex (rep);
					var tree = commit.TreeEntry;
					WorkDirCheckout co = new WorkDirCheckout (rep, rep.WorkingDirectory, index, tree);
					co.checkout ();
					index.write ();
				}
			} 
			else 
			{
				MessageService.ShowError ("Cannot clone: no HEAD advertised by remote.");
			}
			
			MessageService.ShowMessage(string.Format("Finished cloning {0} to {1}", 
					repositoryPath, 
					destination));
		}
	}
}