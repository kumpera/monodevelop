
// This file has been generated by the GUI designer. Do not modify.
namespace MonoDevelop.Ide.Gui.OptionPanels
{
	public partial class KeyBindingsPanel
	{
		private global::Gtk.VBox vbox;
		private global::Gtk.HBox hbox1;
		private global::Gtk.Label labelScheme;
		private global::Gtk.ComboBox schemeCombo;
		private global::Gtk.HSeparator hseparator2;
		private global::Gtk.HBox hbox2;
		private global::Gtk.Label label1;
		private global::Gtk.Entry searchEntry;
		private global::Gtk.Button clearFilterButton;
		private global::Gtk.Image image25;
		private global::Gtk.VBox globalWarningBox;
		private global::Gtk.Frame frame1;
		private global::Gtk.Alignment alignment1;
		private global::Gtk.HBox warningBox;
		private global::Gtk.Image image3;
		private global::Gtk.Label label2;
		private global::MonoDevelop.Components.MenuButton conflicButton;
		private global::Gtk.ScrolledWindow scrolledwindow;
		private global::Gtk.TreeView keyTreeView;
		private global::Gtk.Label labelMessage;
		private global::Gtk.HBox hbox;
		private global::Gtk.Label labelEditBinding;
		private global::Gtk.Entry accelEntry;
		private global::Gtk.Button updateButton;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget MonoDevelop.Ide.Gui.OptionPanels.KeyBindingsPanel
			global::Stetic.BinContainer.Attach (this);
			this.Name = "MonoDevelop.Ide.Gui.OptionPanels.KeyBindingsPanel";
			// Container child MonoDevelop.Ide.Gui.OptionPanels.KeyBindingsPanel.Gtk.Container+ContainerChild
			this.vbox = new global::Gtk.VBox ();
			this.vbox.Name = "vbox";
			this.vbox.Spacing = 6;
			// Container child vbox.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.labelScheme = new global::Gtk.Label ();
			this.labelScheme.Name = "labelScheme";
			this.labelScheme.Xalign = 0F;
			this.labelScheme.LabelProp = global::Mono.Unix.Catalog.GetString ("Scheme:");
			this.hbox1.Add (this.labelScheme);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.labelScheme]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.schemeCombo = global::Gtk.ComboBox.NewText ();
			this.schemeCombo.Name = "schemeCombo";
			this.hbox1.Add (this.schemeCombo);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.schemeCombo]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			this.vbox.Add (this.hbox1);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox [this.hbox1]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox.Gtk.Box+BoxChild
			this.hseparator2 = new global::Gtk.HSeparator ();
			this.hseparator2.Name = "hseparator2";
			this.vbox.Add (this.hseparator2);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox [this.hseparator2]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("_Search:");
			this.label1.UseUnderline = true;
			this.hbox2.Add (this.label1);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.label1]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.searchEntry = new global::Gtk.Entry ();
			this.searchEntry.CanFocus = true;
			this.searchEntry.Name = "searchEntry";
			this.searchEntry.IsEditable = true;
			this.searchEntry.InvisibleChar = '●';
			this.hbox2.Add (this.searchEntry);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.searchEntry]));
			w6.Position = 1;
			// Container child hbox2.Gtk.Box+BoxChild
			this.clearFilterButton = new global::Gtk.Button ();
			this.clearFilterButton.CanFocus = true;
			this.clearFilterButton.Name = "clearFilterButton";
			// Container child clearFilterButton.Gtk.Container+ContainerChild
			this.image25 = new global::Gtk.Image ();
			this.image25.Name = "image25";
			this.image25.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-clear", global::Gtk.IconSize.Menu);
			this.clearFilterButton.Add (this.image25);
			this.clearFilterButton.Label = null;
			this.hbox2.Add (this.clearFilterButton);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.clearFilterButton]));
			w8.Position = 2;
			w8.Expand = false;
			w8.Fill = false;
			this.vbox.Add (this.hbox2);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox [this.hbox2]));
			w9.Position = 2;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vbox.Gtk.Box+BoxChild
			this.globalWarningBox = new global::Gtk.VBox ();
			this.globalWarningBox.Name = "globalWarningBox";
			this.globalWarningBox.Spacing = 6;
			// Container child globalWarningBox.Gtk.Box+BoxChild
			this.frame1 = new global::Gtk.Frame ();
			this.frame1.Name = "frame1";
			// Container child frame1.Gtk.Container+ContainerChild
			this.alignment1 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment1.Name = "alignment1";
			this.alignment1.BorderWidth = ((uint)(2));
			// Container child alignment1.Gtk.Container+ContainerChild
			this.warningBox = new global::Gtk.HBox ();
			this.warningBox.Name = "warningBox";
			this.warningBox.Spacing = 6;
			// Container child warningBox.Gtk.Box+BoxChild
			this.image3 = new global::Gtk.Image ();
			this.image3.Name = "image3";
			this.image3.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-dialog-warning", global::Gtk.IconSize.Menu);
			this.warningBox.Add (this.image3);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.warningBox [this.image3]));
			w10.Position = 0;
			w10.Expand = false;
			w10.Fill = false;
			// Container child warningBox.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.Xalign = 0F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("The current scheme has conflicting key bindings");
			this.warningBox.Add (this.label2);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.warningBox [this.label2]));
			w11.Position = 1;
			// Container child warningBox.Gtk.Box+BoxChild
			this.conflicButton = new global::MonoDevelop.Components.MenuButton ();
			this.conflicButton.CanFocus = true;
			this.conflicButton.Name = "conflicButton";
			this.conflicButton.UseUnderline = false;
			this.conflicButton.UseMarkup = false;
			this.conflicButton.Label = null;
			this.warningBox.Add (this.conflicButton);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.warningBox [this.conflicButton]));
			w12.Position = 2;
			w12.Expand = false;
			w12.Fill = false;
			this.alignment1.Add (this.warningBox);
			this.frame1.Add (this.alignment1);
			this.globalWarningBox.Add (this.frame1);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.globalWarningBox [this.frame1]));
			w15.Position = 0;
			w15.Expand = false;
			w15.Fill = false;
			this.vbox.Add (this.globalWarningBox);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox [this.globalWarningBox]));
			w16.Position = 3;
			w16.Expand = false;
			w16.Fill = false;
			// Container child vbox.Gtk.Box+BoxChild
			this.scrolledwindow = new global::Gtk.ScrolledWindow ();
			this.scrolledwindow.CanFocus = true;
			this.scrolledwindow.Name = "scrolledwindow";
			this.scrolledwindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child scrolledwindow.Gtk.Container+ContainerChild
			this.keyTreeView = new global::Gtk.TreeView ();
			this.keyTreeView.CanFocus = true;
			this.keyTreeView.Name = "keyTreeView";
			this.keyTreeView.EnableSearch = false;
			this.scrolledwindow.Add (this.keyTreeView);
			this.vbox.Add (this.scrolledwindow);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox [this.scrolledwindow]));
			w18.Position = 4;
			// Container child vbox.Gtk.Box+BoxChild
			this.labelMessage = new global::Gtk.Label ();
			this.labelMessage.Name = "labelMessage";
			this.labelMessage.Xalign = 0F;
			this.labelMessage.UseMarkup = true;
			this.vbox.Add (this.labelMessage);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.vbox [this.labelMessage]));
			w19.Position = 5;
			w19.Expand = false;
			w19.Fill = false;
			// Container child vbox.Gtk.Box+BoxChild
			this.hbox = new global::Gtk.HBox ();
			this.hbox.Name = "hbox";
			this.hbox.Spacing = 6;
			// Container child hbox.Gtk.Box+BoxChild
			this.labelEditBinding = new global::Gtk.Label ();
			this.labelEditBinding.Name = "labelEditBinding";
			this.labelEditBinding.LabelProp = global::Mono.Unix.Catalog.GetString ("Edit Binding");
			this.hbox.Add (this.labelEditBinding);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.hbox [this.labelEditBinding]));
			w20.Position = 0;
			w20.Expand = false;
			w20.Fill = false;
			// Container child hbox.Gtk.Box+BoxChild
			this.accelEntry = new global::Gtk.Entry ();
			this.accelEntry.CanFocus = true;
			this.accelEntry.Name = "accelEntry";
			this.accelEntry.IsEditable = true;
			this.accelEntry.InvisibleChar = '●';
			this.hbox.Add (this.accelEntry);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hbox [this.accelEntry]));
			w21.Position = 1;
			// Container child hbox.Gtk.Box+BoxChild
			this.updateButton = new global::Gtk.Button ();
			this.updateButton.CanFocus = true;
			this.updateButton.Name = "updateButton";
			this.updateButton.UseUnderline = true;
			// Container child updateButton.Gtk.Container+ContainerChild
			global::Gtk.Alignment w22 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w23 = new global::Gtk.HBox ();
			w23.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w24 = new global::Gtk.Image ();
			w24.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-apply", global::Gtk.IconSize.Button);
			w23.Add (w24);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w26 = new global::Gtk.Label ();
			w26.LabelProp = global::Mono.Unix.Catalog.GetString ("Apply");
			w26.UseUnderline = true;
			w23.Add (w26);
			w22.Add (w23);
			this.updateButton.Add (w22);
			this.hbox.Add (this.updateButton);
			global::Gtk.Box.BoxChild w30 = ((global::Gtk.Box.BoxChild)(this.hbox [this.updateButton]));
			w30.Position = 2;
			w30.Expand = false;
			w30.Fill = false;
			this.vbox.Add (this.hbox);
			global::Gtk.Box.BoxChild w31 = ((global::Gtk.Box.BoxChild)(this.vbox [this.hbox]));
			w31.Position = 6;
			w31.Expand = false;
			w31.Fill = false;
			this.Add (this.vbox);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.label1.MnemonicWidget = this.searchEntry;
			this.globalWarningBox.Hide ();
			this.labelMessage.Hide ();
			this.Show ();
		}
	}
}