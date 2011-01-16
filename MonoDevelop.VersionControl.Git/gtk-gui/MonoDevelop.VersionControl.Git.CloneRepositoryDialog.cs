
// This file has been generated by the GUI designer. Do not modify.
namespace MonoDevelop.VersionControl.Git
{
	public partial class CloneRepositoryDialog
	{
		private global::Gtk.Table table1;

		private global::MonoDevelop.Components.FolderEntry editFolderEntry;

		private global::Gtk.Entry entryOriginName;

		private global::Gtk.Entry entryRepositoryPath;

		private global::Gtk.Label labelOriginName;

		private global::Gtk.Label labelRepositoryPath;

		private global::Gtk.Label labelWorkingDirectory;

		private global::Gtk.Button buttonCancel;

		private global::Gtk.Button buttonOk;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget MonoDevelop.VersionControl.Git.CloneRepositoryDialog
			this.Name = "MonoDevelop.VersionControl.Git.CloneRepositoryDialog";
			this.Title = global::Mono.Unix.Catalog.GetString ("Clone Repository Dialog");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.Modal = true;
			this.Resizable = false;
			this.AllowGrow = false;
			this.DestroyWithParent = true;
			// Internal child MonoDevelop.VersionControl.Git.CloneRepositoryDialog.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.table1 = new global::Gtk.Table (((uint)(3)), ((uint)(2)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.editFolderEntry = new global::MonoDevelop.Components.FolderEntry ();
			this.editFolderEntry.Name = "editFolderEntry";
			this.editFolderEntry.BrowserTitle = "Select working directory";
			this.table1.Add (this.editFolderEntry);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table1[this.editFolderEntry]));
			w2.TopAttach = ((uint)(2));
			w2.BottomAttach = ((uint)(3));
			w2.LeftAttach = ((uint)(1));
			w2.RightAttach = ((uint)(2));
			w2.XOptions = ((global::Gtk.AttachOptions)(4));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.entryOriginName = new global::Gtk.Entry ();
			this.entryOriginName.CanFocus = true;
			this.entryOriginName.Name = "entryOriginName";
			this.entryOriginName.IsEditable = true;
			this.entryOriginName.InvisibleChar = '●';
			this.table1.Add (this.entryOriginName);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table1[this.entryOriginName]));
			w3.TopAttach = ((uint)(1));
			w3.BottomAttach = ((uint)(2));
			w3.LeftAttach = ((uint)(1));
			w3.RightAttach = ((uint)(2));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.entryRepositoryPath = new global::Gtk.Entry ();
			this.entryRepositoryPath.CanFocus = true;
			this.entryRepositoryPath.Name = "entryRepositoryPath";
			this.entryRepositoryPath.IsEditable = true;
			this.entryRepositoryPath.InvisibleChar = '●';
			this.table1.Add (this.entryRepositoryPath);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table1[this.entryRepositoryPath]));
			w4.LeftAttach = ((uint)(1));
			w4.RightAttach = ((uint)(2));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.labelOriginName = new global::Gtk.Label ();
			this.labelOriginName.Name = "labelOriginName";
			this.labelOriginName.LabelProp = global::Mono.Unix.Catalog.GetString ("Origin Name");
			this.table1.Add (this.labelOriginName);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table1[this.labelOriginName]));
			w5.TopAttach = ((uint)(1));
			w5.BottomAttach = ((uint)(2));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.labelRepositoryPath = new global::Gtk.Label ();
			this.labelRepositoryPath.Name = "labelRepositoryPath";
			this.labelRepositoryPath.LabelProp = global::Mono.Unix.Catalog.GetString ("Repository Path");
			this.labelRepositoryPath.Justify = ((global::Gtk.Justification)(3));
			this.table1.Add (this.labelRepositoryPath);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table1[this.labelRepositoryPath]));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.labelWorkingDirectory = new global::Gtk.Label ();
			this.labelWorkingDirectory.Name = "labelWorkingDirectory";
			this.labelWorkingDirectory.LabelProp = global::Mono.Unix.Catalog.GetString ("Working Directory");
			this.labelWorkingDirectory.Justify = ((global::Gtk.Justification)(3));
			this.table1.Add (this.labelWorkingDirectory);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table1[this.labelWorkingDirectory]));
			w7.TopAttach = ((uint)(2));
			w7.BottomAttach = ((uint)(3));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			w1.Add (this.table1);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(w1[this.table1]));
			w8.Position = 0;
			w8.Expand = false;
			w8.Fill = false;
			// Internal child MonoDevelop.VersionControl.Git.CloneRepositoryDialog.ActionArea
			global::Gtk.HButtonBox w9 = this.ActionArea;
			w9.Name = "dialog1_ActionArea";
			w9.Spacing = 10;
			w9.BorderWidth = ((uint)(5));
			w9.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonCancel = new global::Gtk.Button ();
			this.buttonCancel.CanDefault = true;
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseStock = true;
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = "gtk-cancel";
			this.AddActionWidget (this.buttonCancel, -6);
			global::Gtk.ButtonBox.ButtonBoxChild w10 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w9[this.buttonCancel]));
			w10.Expand = false;
			w10.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOk = new global::Gtk.Button ();
			this.buttonOk.CanDefault = true;
			this.buttonOk.CanFocus = true;
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.UseStock = true;
			this.buttonOk.UseUnderline = true;
			this.buttonOk.Label = "gtk-ok";
			this.AddActionWidget (this.buttonOk, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w11 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w9[this.buttonOk]));
			w11.Position = 1;
			w11.Expand = false;
			w11.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 377;
			this.DefaultHeight = 169;
			this.Show ();
			this.buttonCancel.ButtonPressEvent += new global::Gtk.ButtonPressEventHandler (this.Cancel_ButtonPress);
		}
	}
}
