using System;
using System.IO;

using MonoDevelop.Core;
using MonoDevelop.VersionControl;

namespace MonoDevelop.VersionControl.Git {

	public class GitVersionControl : VersionControlSystem {

		public override Gtk.Widget CreateRepositoryEditor(Repository repo)
		{
			throw new NotImplementedException();
		}

		public override string Name
		{
			get { return "Git"; }
		}

		protected override Repository OnCreateRepositoryInstance()
		{
			return new GitRepository(this);
		}

		public override Repository GetRepositoryReference(FilePath path, string id)
		{
			if (!IsVersioned(path))
				return null;

			return new GitRepository(this, FindRepositoryPath(path));
		}

		public override void StoreRepositoryReference(Repository repo, FilePath path, string id)
		{
		}

		public override bool IsInstalled
		{
			get { return true; }
		}

		public bool IsVersioned(FilePath localPath)
		{
			string repPath = string.Empty;
			if (File.Exists(localPath))
				repPath = FindRepositoryPath(Path.GetDirectoryName(localPath));
			else if (Directory.Exists(localPath))
				repPath = FindRepositoryPath(localPath);

			return !string.IsNullOrEmpty(repPath);
		}

		private string FindRepositoryPath(string path)
		{
			if (Directory.Exists(Path.Combine(path, GitSharp.Core.Constants.DOT_GIT)))
				return path;
			if (path == Directory.GetDirectoryRoot(path))
				return string.Empty;

			return FindRepositoryPath(Path.GetDirectoryName(path));
		}
	}
}
