// SelectReferenceDialog.cs
//  
// Author:
//       Todd Berman <tberman@sevenl.net>
//       Lluis Sanchez Gual <lluis@novell.com>
// 
// Copyright (c) 2004 Todd Berman
// Copyright (c) 2009 Novell, Inc (http://www.novell.com)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;

using MonoDevelop.Projects;
using MonoDevelop.Core;
using MonoDevelop.Core.Assemblies;

using Gtk;
using System.Collections.Generic;
using MonoDevelop.Components;

namespace MonoDevelop.Ide.Projects
{
	internal interface IReferencePanel
	{
		void SetProject (DotNetProject configureProject);
		void SignalRefChange (ProjectReference refInfo, bool newState);
		void SetFilter (string filter);
	}
	
	internal partial class SelectReferenceDialog: Gtk.Dialog
	{
		ListStore refTreeStore;
		
		GacReferencePanel gacRefPanel;
		GacReferencePanel allRefPanel;
		ProjectReferencePanel projectRefPanel;
		AssemblyReferencePanel assemblyRefPanel;
		DotNetProject configureProject;
		List<IReferencePanel> panels = new List<IReferencePanel> ();
		SearchEntry filterEntry;
		
		const int NameColumn = 0;
		const int TypeNameColumn = 1;
		const int LocationColumn = 2;
		const int ProjectReferenceColumn = 3;
		const int IconColumn = 4;
		
		public ProjectReferenceCollection ReferenceInformations {
			get {
				ProjectReferenceCollection referenceInformations = new ProjectReferenceCollection();
				Gtk.TreeIter looping_iter;
				if (!refTreeStore.GetIterFirst (out looping_iter)) {
					return referenceInformations;
				}
				do {
					referenceInformations.Add ((ProjectReference) refTreeStore.GetValue(looping_iter, ProjectReferenceColumn));
				} while (refTreeStore.IterNext (ref looping_iter));
				return referenceInformations;
			}
		}
		
		public void SetProject (DotNetProject configureProject)
		{
			this.configureProject = configureProject;
			foreach (var p in panels)
				p.SetProject (configureProject);
			
			((ListStore) ReferencesTreeView.Model).Clear ();

			foreach (ProjectReference refInfo in configureProject.References)
				AppendReference (refInfo);

			OnChanged (null, null);
		}
		
		TreeIter AppendReference (ProjectReference refInfo)
		{
			foreach (var p in panels)
				p.SignalRefChange (refInfo, true);
			
			switch (refInfo.ReferenceType) {
				case ReferenceType.Assembly:
					return AddAssemplyReference (refInfo);
				case ReferenceType.Project:
					return AddProjectReference (refInfo);
				case ReferenceType.Gac:
					return AddGacReference (refInfo);
				default:
					return TreeIter.Zero;
			}
		}

		TreeIter AddAssemplyReference (ProjectReference refInfo)
		{
			string txt = GLib.Markup.EscapeText (System.IO.Path.GetFileName (refInfo.Reference)) + "\n";
			txt += "<span color='darkgrey'><small>" + GLib.Markup.EscapeText (System.IO.Path.GetFullPath (refInfo.Reference)) + "</small></span>";
			return refTreeStore.AppendValues (txt, GetTypeText (refInfo), System.IO.Path.GetFullPath (refInfo.Reference), refInfo, ImageService.GetPixbuf ("md-empty-file-icon", IconSize.Dnd));
		}

		TreeIter AddProjectReference (ProjectReference refInfo)
		{
			Solution c = configureProject.ParentSolution;
			if (c == null) return TreeIter.Zero;
			
			Project p = c.FindProjectByName (refInfo.Reference);
			if (p == null) return TreeIter.Zero;
			
			string txt = GLib.Markup.EscapeText (System.IO.Path.GetFileName (refInfo.Reference)) + "\n";
			txt += "<span color='darkgrey'><small>" + GLib.Markup.EscapeText (p.BaseDirectory.ToString ()) + "</small></span>";
			return refTreeStore.AppendValues (txt, GetTypeText (refInfo), p.BaseDirectory.ToString (), refInfo, ImageService.GetPixbuf ("md-project", IconSize.Dnd));
		}

		TreeIter AddGacReference (ProjectReference refInfo)
		{
			string txt = GLib.Markup.EscapeText (System.IO.Path.GetFileNameWithoutExtension (refInfo.Reference));
			int i = refInfo.Reference.IndexOf (',');
			if (i != -1)
				txt = GLib.Markup.EscapeText (txt.Substring (0, i)) + "\n<span color='darkgrey'><small>" + GLib.Markup.EscapeText (refInfo.Reference.Substring (i+1).Trim()) + "</small></span>";
			return refTreeStore.AppendValues (txt, GetTypeText (refInfo), refInfo.Reference, refInfo, ImageService.GetPixbuf ("md-package", IconSize.Dnd));
		}
		
		public SelectReferenceDialog ()
		{
			Build ();
			
			boxRefs.WidthRequest = 200;
			
			refTreeStore = new ListStore (typeof (string), typeof(string), typeof(string), typeof(ProjectReference), typeof(Gdk.Pixbuf));
			ReferencesTreeView.Model = refTreeStore;

			TreeViewColumn col = new TreeViewColumn ();
			col.Title = GettextCatalog.GetString("Reference");
			CellRendererPixbuf crp = new CellRendererPixbuf ();
			crp.Yalign = 0f;
			col.PackStart (crp, false);
			col.AddAttribute (crp, "pixbuf", IconColumn);
			CellRendererText text_render = new CellRendererText ();
			col.PackStart (text_render, true);
			col.AddAttribute (text_render, "markup", NameColumn);
			text_render.Ellipsize = Pango.EllipsizeMode.End;
			
			ReferencesTreeView.AppendColumn (col);
//			ReferencesTreeView.AppendColumn (GettextCatalog.GetString ("Type"), new CellRendererText (), "text", TypeNameColumn);
//			ReferencesTreeView.AppendColumn (GettextCatalog.GetString ("Location"), new CellRendererText (), "text", LocationColumn);
			
			projectRefPanel = new ProjectReferencePanel (this);
			gacRefPanel = new GacReferencePanel (this, false);
			allRefPanel = new GacReferencePanel (this, true);
			assemblyRefPanel = new AssemblyReferencePanel (this);
			panels.Add (allRefPanel);
			panels.Add (gacRefPanel);
			panels.Add (projectRefPanel);
			panels.Add (assemblyRefPanel);
			
			mainBook.RemovePage (mainBook.CurrentPage);
			
			HBox tab = new HBox (false, 3);
//			tab.PackStart (new Image (ImageService.GetPixbuf (MonoDevelop.Ide.Gui.Stock.Reference, IconSize.Menu)), false, false, 0);
			tab.PackStart (new Label (GettextCatalog.GetString ("All")), true, true, 0);
			tab.BorderWidth = 3;
			tab.ShowAll ();
			mainBook.AppendPage (allRefPanel, tab);
			
			tab = new HBox (false, 3);
//			tab.PackStart (new Image (ImageService.GetPixbuf (MonoDevelop.Ide.Gui.Stock.Package, IconSize.Menu)), false, false, 0);
			tab.PackStart (new Label (GettextCatalog.GetString ("Packages")), true, true, 0);
			tab.BorderWidth = 3;
			tab.ShowAll ();
			mainBook.AppendPage (gacRefPanel, tab);
			
			tab = new HBox (false, 3);
//			tab.PackStart (new Image (ImageService.GetPixbuf (MonoDevelop.Ide.Gui.Stock.Project, IconSize.Menu)), false, false, 0);
			tab.PackStart (new Label (GettextCatalog.GetString ("Projects")), true, true, 0);
			tab.BorderWidth = 3;
			tab.ShowAll ();
			mainBook.AppendPage (projectRefPanel, tab);
			
			tab = new HBox (false, 3);
//			tab.PackStart (new Image (ImageService.GetPixbuf (MonoDevelop.Ide.Gui.Stock.OpenFolder, IconSize.Menu)), false, false, 0);
			tab.PackStart (new Label (GettextCatalog.GetString (".Net Assembly")), true, true, 0);
			tab.BorderWidth = 3;
			tab.ShowAll ();
			mainBook.AppendPage (assemblyRefPanel, tab);
			
			mainBook.Page = 0;
			
			var w = selectedHeader.Child;
			selectedHeader.Remove (w);
			HeaderBox header = new HeaderBox (1, 0, 1, 1);
			header.SetPadding (6, 6, 6, 6);
			header.GradientBackround = true;
			header.Add (w);
			selectedHeader.Add (header);
			
			ReferencesTreeView.Selection.Changed += new EventHandler (OnChanged);
			Child.ShowAll ();
			OnChanged (null, null);
			Show ();
			InsertFilterEntry ();
		}
		
		void InsertFilterEntry ()
		{
			filterEntry = new SearchEntry ();
			filterEntry.Entry.SetSizeRequest (200, filterEntry.Entry.SizeRequest ().Height);
			filterEntry.Parent = mainBook;
			filterEntry.Ready = true;
			filterEntry.ForceFilterButtonVisible = true;
			filterEntry.Visible = true;
			filterEntry.HasFocus = true;
			
			mainBook.SizeAllocated += delegate {
				RepositionFilter ();
			};
			filterEntry.Changed += delegate {
				foreach (var p in panels)
					p.SetFilter (filterEntry.Query);
			};
			RepositionFilter ();
		}
		
		void RepositionFilter ()
		{
			int w = filterEntry.SizeRequest ().Width;
			int h = filterEntry.SizeRequest ().Height;
			filterEntry.Allocation = new Gdk.Rectangle (mainBook.Allocation.Right - w - 1, mainBook.Allocation.Y, w, h);
		}
		
		protected override void OnShown ()
		{
			base.OnShown ();
			Focus = filterEntry;
		}

		void OnChanged (object o, EventArgs e)
		{
			if (ReferencesTreeView.Selection.CountSelectedRows () > 0)
				RemoveReferenceButton.Sensitive = true;
			else
				RemoveReferenceButton.Sensitive = false;
		}
		
		string GetTypeText (ProjectReference pref)
		{
			switch (pref.ReferenceType) {
				case ReferenceType.Gac: return GettextCatalog.GetString ("Package");
				case ReferenceType.Assembly: return GettextCatalog.GetString ("Assembly");
				case ReferenceType.Project: return GettextCatalog.GetString ("Project");
				default: return "";
			}
		}

		public void RemoveReference (ReferenceType referenceType, string reference)
		{
			TreeIter iter = FindReference (referenceType, reference);
			if (iter.Equals (TreeIter.Zero))
				return;
			refTreeStore.Remove (ref iter);
		}
		
		public void AddReference (ProjectReference pref)
		{
			TreeIter iter = FindReference (pref.ReferenceType, pref.Reference);
			if (!iter.Equals (TreeIter.Zero))
				return;
			
			TreeIter ni = AppendReference (pref);
			if (!ni.Equals (TreeIter.Zero))
				ReferencesTreeView.ScrollToCell (refTreeStore.GetPath (ni), null, false, 0, 0);
		}
		
		TreeIter FindReference (ReferenceType referenceType, string reference)
		{
			TreeIter looping_iter;
			if (refTreeStore.GetIterFirst (out looping_iter)) {
				do {
					ProjectReference pref = (ProjectReference) refTreeStore.GetValue (looping_iter, ProjectReferenceColumn);
					if (pref.Reference == reference && pref.ReferenceType == referenceType) {
						return looping_iter;
					}
				} while (refTreeStore.IterNext (ref looping_iter));
			}
			return TreeIter.Zero;
		}
		
		protected void RemoveReference (object sender, EventArgs e)
		{
			TreeIter iter;
			TreeModel mdl;
			if (ReferencesTreeView.Selection.GetSelected (out mdl, out iter)) {
				ProjectReference pref = (ProjectReference)refTreeStore.GetValue (iter, ProjectReferenceColumn);
				foreach (var p in panels)
					p.SignalRefChange (pref, false);
				TreeIter newIter = iter;
				if (refTreeStore.IterNext (ref newIter)) {
					ReferencesTreeView.Selection.SelectIter (newIter);
					refTreeStore.Remove (ref iter);
				} else {
					TreePath path = refTreeStore.GetPath (iter);
					if (path.Prev ()) {
						ReferencesTreeView.Selection.SelectPath (path);
						refTreeStore.Remove (ref iter);
					} else {
						refTreeStore.Remove (ref iter);
					}
				}
			}
		}
	}
}

