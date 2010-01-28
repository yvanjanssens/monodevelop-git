using System;
using System.IO;
using System.Linq;

using MonoDevelop.Components.Commands;
using MonoDevelop.Ide.Gui;
using MonoDevelop.Projects;

namespace MonoDevelop.VersionControl.Git
{
	internal class InitializeRepositoryCommand : CommandHandler
	{
		private GitRepository _repository;
		
		private Project CurrentProject {
			get {
				Project currentProject = null;
				if (IdeApp.Workspace.IsOpen && IdeApp.Workbench.ActiveDocument != null) {
					string currentFile = IdeApp.Workbench.ActiveDocument.FileName;
					currentProject = IdeApp.Workspace.GetProjectContainingFile (currentFile);
				}
				return currentProject;
			}
		}
		/// <summary>
		/// Returns current project (determined by current active file) 
		/// BaseDirectory suffixed by .git dir
		/// </summary>
		private DirectoryInfo CurrentProjectGitDirectory {
			get {
				DirectoryInfo gitDir = null;
				if (CurrentProject != null) {
					gitDir = new DirectoryInfo (Path.Combine (
						CurrentProject.BaseDirectory, 
						GitSharp.Core.Constants.DOT_GIT));
				}
				
				return gitDir;
			}	
		}
		
		/// <summary>
		/// Determines command enabled state. Should only
		/// be enabled when there is an active project not 
		/// yet initialized.
		/// </summary>
		private bool CanRun {
			get {
				return (CurrentProjectGitDirectory != null && 
					 !CurrentProjectGitDirectory.Exists);			
			}
		}
		
		protected override void Run ()
		{
			//if (!CanRun)
			//        return;

			//VersionControlItem vci = GetItems()[0];
			//Solution sln = (Solution)vci.WorkspaceObject;

			//var vcs = (from v in VersionControlService.GetVersionControlSystems()
			//                           where v is GitVersionControl
			//                           select v).FirstOrDefault();
			//if (vcs != null) {
			//        var rep = vcs.GetRepositoryReference(vci.Path, string.Empty) as GitRepository;
			//        rep.Initialize();
			//}

		}	
		
		protected override void Update (CommandInfo info)
		{
			info.Enabled = CanRun;
		}
	}
}
