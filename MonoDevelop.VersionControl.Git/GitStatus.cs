using System;
using System.Collections.Generic;

namespace MonoDevelop.VersionControl.Git {
	internal class GitStatus {

		GitSharp.Core.IndexDiff _diff;

		public GitStatus(GitSharp.Core.Repository repository)
		{
			_diff = new GitSharp.Core.IndexDiff(repository);
			if (_diff != null)
				HasChanges = _diff.Diff();
		}

		public bool HasChanges { get; private set; }

		public HashSet<string> Added
		{
			get { return _diff.Added; }
		}

		public HashSet<string> Changed
		{
			get { return _diff.Changed; }
		}

		public HashSet<string> Removed
		{
			get { return _diff.Removed; }
		}

		public HashSet<string> Missing
		{
			get { return _diff.Missing; }
		}

		public HashSet<string> Modified
		{
			get { return _diff.Modified; }
		}

		public HashSet<string> Untracked
		{
			get { return _diff.Untracked; }
		}

		public HashSet<string> MergeConflict
		{
			get { return _diff.MergeConflict; }
		}

		public int IndexSize
		{
			get { return _diff.IndexSize; }
		}
	}
}
