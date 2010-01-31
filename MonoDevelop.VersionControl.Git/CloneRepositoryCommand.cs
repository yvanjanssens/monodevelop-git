using System;

using MonoDevelop.Components.Commands;
using MonoDevelop.Core.Gui;

namespace MonoDevelop.VersionControl.Git
{
	public class CloneRepositoryCommand : CommandHandler
	{
		protected override void Run ()
		{
			//string repositoryUrl = MessageService.GetTextResponse(
			//    "Repository Location:",
			//    "Clone GIT Repository",
			//    string.Empty);
	
			//if (!string.IsNullOrEmpty(repositoryUrl))
			//{
			//    MessageService.ShowMessage(repositoryUrl); 
			//}
			var cloneDialog = new CloneRepositoryDialog ();
			cloneDialog.Run ();
			cloneDialog.Destroy ();
			
			MessageService.ShowMessage (cloneDialog.RepositoryPath);
		}
	}
}
