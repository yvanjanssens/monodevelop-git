using System;

namespace MonoDevelop.VersionControl.Git
{
	public class GitRevision : Revision
	{
		public readonly string _commitId;

		public GitRevision(Repository repository, string revision)
			: base(repository)
		{
			_commitId = revision;
		}

		public GitRevision(
			Repository repository, 
			string revision, 
			DateTime time, 
			string author, 
			string message, 
			RevisionPath[] changedFiles) : base(repository, time, author, message, changedFiles)
		{
			_commitId = revision;
		}

		public override string ToString()
		{
			return _commitId;
		}

		public override Revision GetPrevious()
		{
			// TODO: Find out how to get previous commit (RevWalk ?)
			return this;
		}
	}
}
