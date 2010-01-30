using System;
using System.Collections.Generic;
using System.Linq;

using MonoDevelop.Components.Commands;
using MonoDevelop.Ide.Gui.Components;
using MonoDevelop.Ide.Gui.Pads.ProjectPad;
using MonoDevelop.Projects;

namespace MonoDevelop.VersionControl.Git {
	public class GitCommandHandler : VersionControlCommandHandler {

		[CommandUpdateHandler(Commands.InitializeRepository)]
		virtual protected void CanInitializeRepository(CommandInfo info)
		{
			info.Visible = false;
			var items = GetItems();
			if (items.Count == 1) {
				if (items[0].Repository == null &&
					(items[0].WorkspaceObject is Solution ||
					items[0].WorkspaceObject is Project)) {
					info.Visible = true;
				}
			}
		}

		[CommandHandler(Commands.InitializeRepository)]
		virtual protected void OnInitializeRepository()
		{
			var item = GetItems()[0];

			var vcs = (from v in VersionControlService.GetVersionControlSystems()
				   where v is GitVersionControl
				   select v).FirstOrDefault();
			if (vcs != null && vcs.IsInstalled) {
				var rep = new GitRepository(vcs, item.Path);
				rep.Initialize();

				rep.Add(GetAllFiles(item.WorkspaceObject), false, null);

				if (item.WorkspaceObject is Solution)
					((Solution)item.WorkspaceObject).NeedsReload = true;
				else if (item.WorkspaceObject is Project)
					((Project)item.WorkspaceObject).NeedsReload = true;
				else
					System.Diagnostics.Debug.Assert(false, "Item should be either solution or project.");
			}
		}

		[CommandUpdateHandler(Commands.CloneRepository)]
		virtual protected void CanCloneRepository(CommandInfo info)
		{
			info.Enabled = true;
		}

		[CommandHandler(Commands.CloneRepository)]
		virtual protected void OnCloneRepository()
		{
		}

		private Core.FilePath[] GetAllFiles(IWorkspaceObject item)
		{
			var files = new List<Core.FilePath>();
			if (item is Solution) {
				var sln = (Solution)item;
				files.Add(sln.FileName);
				foreach (var childSolution in sln.GetAllSolutions())
					if (childSolution != sln)
						files.AddRange(GetAllFiles(childSolution));

				foreach (var project in sln.GetAllProjects())
					files.AddRange(GetAllFiles(project));
			}

			if (item is Project) {
				var prj = (Project)item;
				files.Add(prj.FileName);
				foreach (var file in ((Project)item).Files)
					files.Add(file.FilePath);
			}

			return files.ToArray();
		}
	}

	class GitNodeExtension : NodeBuilderExtension {
		public override bool CanBuildNode(Type dataType)
		{
			return typeof(ProjectFile).IsAssignableFrom(dataType)
				|| typeof(SystemFile).IsAssignableFrom(dataType)
				|| typeof(ProjectFolder).IsAssignableFrom(dataType)
				|| typeof(IWorkspaceObject).IsAssignableFrom(dataType);
		}

		public override Type CommandHandlerType
		{
			get { return typeof(GitCommandHandler); }
		}
	}
}
