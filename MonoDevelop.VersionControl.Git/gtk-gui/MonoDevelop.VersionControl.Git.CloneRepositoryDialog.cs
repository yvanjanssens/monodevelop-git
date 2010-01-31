//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MonoDevelop.VersionControl.Git {
    
    
    public partial class CloneRepositoryDialog {
        
        private Gtk.Table table1;
        
        private MonoDevelop.Components.FolderEntry editFolderEntry;
        
        private Gtk.Entry editRepositoryPath;
        
        private Gtk.Label labelRepositoryPath;
        
        private Gtk.Label labelWorkingDirectory;
        
        private Gtk.Button buttonCancel;
        
        private Gtk.Button buttonOk;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget MonoDevelop.VersionControl.Git.CloneRepositoryDialog
            this.Name = "MonoDevelop.VersionControl.Git.CloneRepositoryDialog";
            this.Title = Mono.Unix.Catalog.GetString("Clone Repository Dialog");
            this.WindowPosition = ((Gtk.WindowPosition)(4));
            this.Modal = true;
            this.Resizable = false;
            this.AllowGrow = false;
            this.DestroyWithParent = true;
            // Internal child MonoDevelop.VersionControl.Git.CloneRepositoryDialog.VBox
            Gtk.VBox w1 = this.VBox;
            w1.Name = "dialog1_VBox";
            w1.BorderWidth = ((uint)(2));
            // Container child dialog1_VBox.Gtk.Box+BoxChild
            this.table1 = new Gtk.Table(((uint)(2)), ((uint)(2)), false);
            this.table1.Name = "table1";
            this.table1.RowSpacing = ((uint)(6));
            this.table1.ColumnSpacing = ((uint)(6));
            // Container child table1.Gtk.Table+TableChild
            this.editFolderEntry = new MonoDevelop.Components.FolderEntry();
            this.editFolderEntry.Name = "editFolderEntry";
            this.editFolderEntry.BrowserTitle = "Select working directory";
            this.table1.Add(this.editFolderEntry);
            Gtk.Table.TableChild w2 = ((Gtk.Table.TableChild)(this.table1[this.editFolderEntry]));
            w2.TopAttach = ((uint)(1));
            w2.BottomAttach = ((uint)(2));
            w2.LeftAttach = ((uint)(1));
            w2.RightAttach = ((uint)(2));
            w2.XOptions = ((Gtk.AttachOptions)(4));
            w2.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.editRepositoryPath = new Gtk.Entry();
            this.editRepositoryPath.CanFocus = true;
            this.editRepositoryPath.Name = "editRepositoryPath";
            this.editRepositoryPath.IsEditable = true;
            this.table1.Add(this.editRepositoryPath);
            Gtk.Table.TableChild w3 = ((Gtk.Table.TableChild)(this.table1[this.editRepositoryPath]));
            w3.LeftAttach = ((uint)(1));
            w3.RightAttach = ((uint)(2));
            w3.XOptions = ((Gtk.AttachOptions)(4));
            w3.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.labelRepositoryPath = new Gtk.Label();
            this.labelRepositoryPath.Name = "labelRepositoryPath";
            this.labelRepositoryPath.LabelProp = Mono.Unix.Catalog.GetString("Repository Path:");
            this.labelRepositoryPath.Justify = ((Gtk.Justification)(3));
            this.table1.Add(this.labelRepositoryPath);
            Gtk.Table.TableChild w4 = ((Gtk.Table.TableChild)(this.table1[this.labelRepositoryPath]));
            w4.XOptions = ((Gtk.AttachOptions)(4));
            w4.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.labelWorkingDirectory = new Gtk.Label();
            this.labelWorkingDirectory.Name = "labelWorkingDirectory";
            this.labelWorkingDirectory.LabelProp = Mono.Unix.Catalog.GetString("Working Directory:");
            this.labelWorkingDirectory.Justify = ((Gtk.Justification)(3));
            this.table1.Add(this.labelWorkingDirectory);
            Gtk.Table.TableChild w5 = ((Gtk.Table.TableChild)(this.table1[this.labelWorkingDirectory]));
            w5.TopAttach = ((uint)(1));
            w5.BottomAttach = ((uint)(2));
            w5.XOptions = ((Gtk.AttachOptions)(4));
            w5.YOptions = ((Gtk.AttachOptions)(4));
            w1.Add(this.table1);
            Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(w1[this.table1]));
            w6.Position = 0;
            w6.Expand = false;
            w6.Fill = false;
            // Internal child MonoDevelop.VersionControl.Git.CloneRepositoryDialog.ActionArea
            Gtk.HButtonBox w7 = this.ActionArea;
            w7.Name = "dialog1_ActionArea";
            w7.Spacing = 10;
            w7.BorderWidth = ((uint)(5));
            w7.LayoutStyle = ((Gtk.ButtonBoxStyle)(4));
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.buttonCancel = new Gtk.Button();
            this.buttonCancel.CanDefault = true;
            this.buttonCancel.CanFocus = true;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseStock = true;
            this.buttonCancel.UseUnderline = true;
            this.buttonCancel.Label = "gtk-cancel";
            this.AddActionWidget(this.buttonCancel, -6);
            Gtk.ButtonBox.ButtonBoxChild w8 = ((Gtk.ButtonBox.ButtonBoxChild)(w7[this.buttonCancel]));
            w8.Expand = false;
            w8.Fill = false;
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.buttonOk = new Gtk.Button();
            this.buttonOk.CanDefault = true;
            this.buttonOk.CanFocus = true;
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.UseStock = true;
            this.buttonOk.UseUnderline = true;
            this.buttonOk.Label = "gtk-ok";
            this.AddActionWidget(this.buttonOk, -5);
            Gtk.ButtonBox.ButtonBoxChild w9 = ((Gtk.ButtonBox.ButtonBoxChild)(w7[this.buttonOk]));
            w9.Position = 1;
            w9.Expand = false;
            w9.Fill = false;
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 377;
            this.DefaultHeight = 143;
            this.Show();
            this.buttonCancel.ButtonPressEvent += new Gtk.ButtonPressEventHandler(this.Cancel_ButtonPress);
        }
    }
}