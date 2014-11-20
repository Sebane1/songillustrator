using System;
using System.Collections.Generic;
using System.Text;
using SongIllustrator;
using System.Timers;

namespace ControlFactory {
	public interface Factory {
		ButtonView BuildButton();
		TextBoxView BuildRichTextBox();
		TextBoxView BuildTextBox();
		FormControl BuildFormControl();
		FormView BuildFormView();
		LabelView BuildLabelView();
		ArrayView BuildListView();
		ArrayViewItem BuildListViewItem();
		Menu BuildMenu();
		ToolStripMenuView BuildToolStripMenu();
		ContextMenuView BuildContextMenu();
		MenuItemView BuildMenuItem();
		MenuItemSeperator BuildMenuItemSeperator();
		PictureView BuildPictureView();
		SplitContainerView BuildSplitContainerView();
		TextBoxView BuildTextBoxView();
		TrackBarView BuildTrackBar();


		FormControl BuildPanel();

		//SongIllustrator.Timer BuildTimer();
	}
}
