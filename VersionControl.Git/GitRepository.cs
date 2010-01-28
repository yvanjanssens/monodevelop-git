using System;
using System.IO;

using MonoDevelop.Core;
using MonoDevelop.VersionControl;

namespace MonoDevelop.VersionControl.Git
{
	public class GitRepository : Repository, IDisposable
	{
		GitSharp.Core.Repository _coreRepository;
		GitStatus _cachedStatus;
		bool _disposed;
		
		public GitRepository (VersionControlSystem vcs) : base(vcs)
		{
		}
		
		public GitRepository (VersionControlSystem vcs, FilePath localPath) : base (vcs)
		{
			string gitDir;
			if (Environment.GetEnvironmentVariable("GIT_DIT") != null)
				gitDir = Environment.GetEnvironmentVariable("GIT_DIR");
			else
				gitDir = localPath;

			if (!gitDir.EndsWith(GitSharp.Core.Constants.DOT_GIT_EXT))
				gitDir = Path.Combine(gitDir, GitSharp.Core.Constants.DOT_GIT);

			_coreRepository = new GitSharp.Core.Repository(new DirectoryInfo(gitDir));
		}

		public void Initialize()
		{
			if (_coreRepository == null) throw new InvalidOperationException("Core Repository shouldn't be null");

			_coreRepository.Create();
		}

		public DirectoryInfo WorkingDirectory
		{
			get { return _coreRepository == null ? null : _coreRepository.WorkingDirectory; }
		}

		internal GitStatus CachedStatus
		{
			get
			{
				if (_cachedStatus == null)
					_cachedStatus = new GitStatus(_coreRepository);

				return _cachedStatus;
			}
		}

		#region Overrides
		public override bool IsVersioned(FilePath localPath)
		{
			bool isVersioned = false;
			string relativePath = localPath.ToRelative(
				_coreRepository.WorkingDirectory.FullName).ToString().Replace('\\', '/');
			if (_coreRepository == null || _coreRepository.Directory == null)
				isVersioned = false;
			else
				isVersioned = CachedStatus != null && !CachedStatus.Untracked.Contains(relativePath);
			
			return isVersioned;
		}

		public override bool IsModified(FilePath localFile)
		{
			return false;
		}

		public override bool CanAdd(FilePath localPath)
		{
			return !IsVersioned(localPath);
		}

		public override bool CanCommit(FilePath localPath)
		{
			return false;
		}

		public override bool CanRemove(FilePath localPath)
		{
			return false;
		}

		public override bool CanGetAnnotations(FilePath localPath)
		{
			return false;
		}

		public override bool CanLock(FilePath localPath)
		{
			return false;
		}

		public override bool CanMoveFilesFrom(Repository srcRepository, FilePath localSrcPath, FilePath localDestPath)
		{
			return false;
		}

		public override bool CanRevert(FilePath localPath)
		{
			return false;
		}

		public override bool CanUnlock(FilePath localPath)
		{
			return false;
		}

		public override bool CanUpdate(FilePath localPath)
		{
			return false;
		}

		public override void Add(FilePath[] localPaths, bool recurse, IProgressMonitor monitor)
		{
			_coreRepository.Index.RereadIfNecessary();
			foreach (var path in localPaths) {
				if (File.Exists(path))
					AddFile(new FileInfo(path));
				else if (Directory.Exists(path))
					AddDirectory(new DirectoryInfo(path));

			}
			_coreRepository.Index.write();
		}

		public override void Checkout(FilePath targetLocalPath, Revision rev, bool recurse, IProgressMonitor monitor)
		{
			throw new NotImplementedException();
		}
		 
		public override void Commit(ChangeSet changeSet, IProgressMonitor monitor)
		{
			throw new NotImplementedException();
		}

		public override VersionInfo[] GetDirectoryVersionInfo(FilePath localDirectory, bool getRemoteStatus, bool recursive)
		{
			return null;
		}

		public override Revision[] GetHistory(FilePath localFile, Revision since)
		{
			throw new NotImplementedException();
		}

		public override string GetPathToBaseText(FilePath localFile)
		{
			throw new NotImplementedException();
		}

		public override string GetTextAtRevision(FilePath repositoryPath, Revision revision)
		{
			throw new NotImplementedException();
		}

		public override VersionInfo GetVersionInfo(FilePath localPath, bool getRemoteStatus)
		{
			if (!IsVersioned(localPath))
				return null;
			var status = GetLocalStatus(localPath);

			var vi = new VersionInfo(localPath, 
				localPath /*repositoryPath*/, 
				Directory.Exists(localPath), 
				status.VersionStatus, 
				new GitRevision(this, status.Revision), 
				VersionStatus.Unversioned, 
				null);

			return vi;
		}

		public override Repository Publish(string serverPath, FilePath localPath, FilePath[] files, string message, IProgressMonitor monitor)
		{
			throw new NotImplementedException();
		}

		public override void Revert(FilePath[] localPaths, bool recurse, IProgressMonitor monitor)
		{
			throw new NotImplementedException();
		}

		public override void RevertRevision(FilePath localPath, Revision revision, IProgressMonitor monitor)
		{
			throw new NotImplementedException();
		}

		public override void RevertToRevision(FilePath localPath, Revision revision, IProgressMonitor monitor)
		{
			throw new NotImplementedException();
		}

		public override void Update(FilePath[] localPaths, bool recurse, IProgressMonitor monitor)
		{
			throw new NotImplementedException();
		} 
		#endregion

		#region Private Methods
		private void AddDirectory(DirectoryInfo directoryInfo)
		{
			foreach (FileInfo file in directoryInfo.GetFiles())
				AddFile(file);
			foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
				AddDirectory(directory);
		}

		private void AddFile(FileInfo file)
		{
			_coreRepository.Index.add(_coreRepository.WorkingDirectory, file);
		}

		private LocalStatus GetLocalStatus(FilePath localPath)
		{
			var st = new LocalStatus();
			var commit = _coreRepository.Resolve(GitSharp.Core.Constants.HEAD);
			if (commit != null)
				st.Revision = commit.ToString();
			
			string relativePath = (localPath.ToRelative(_coreRepository.WorkingDirectory.FullName)).ToString().Replace('\\', '/');
			if (CachedStatus.Untracked.Contains(relativePath))
				st.VersionStatus = VersionStatus.Unversioned;
			if (CachedStatus.Added.Contains(relativePath))
				st.VersionStatus = VersionStatus.Versioned | VersionStatus.ScheduledAdd;
			if (CachedStatus.Removed.Contains(relativePath))
				st.VersionStatus = VersionStatus.Versioned | VersionStatus.ScheduledDelete;
			if (CachedStatus.Modified.Contains(relativePath))
				st.VersionStatus = VersionStatus.Versioned | VersionStatus.Modified;
			if (CachedStatus.Removed.Contains(relativePath))
				st.VersionStatus = VersionStatus.Versioned | VersionStatus.ScheduledDelete;
			// TODO: Missing some version statuses to check.

			return st;
		}

		#endregion

		#region Dispose
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		virtual protected void Dispose(bool disposing)
		{
			if (!_disposed) {
				if (disposing) {
					if (_coreRepository != null)
						_coreRepository.Dispose();
				}

				_coreRepository = null;
				_disposed = true;
			}
		} 
		#endregion		
		
		private class LocalStatus
		{
			public LocalStatus()
			{
				Revision = string.Empty;
				VersionStatus = VersionControl.VersionStatus.Versioned;
			}

			public VersionStatus VersionStatus { get; set; }
			public string Revision { get; set; }
		}
	}
}
