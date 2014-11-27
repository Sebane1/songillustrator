using System;
using System.Collections.Generic;
using System.Text;
using SongIllustrator;
using System.Timers;
using MediaPlayerModuleBase;

namespace ControlFactory {
	public interface IFactory {
		IButtonView BuildButton();
		IRichTextBoxView BuildRichTextBox();
		ITextBoxView BuildTextBox();
		IView BuildFormControl();
		IFormView BuildFormView();
		ILabelView BuildLabelView();
		IArrayView BuildListView();
		IArrayViewItem BuildListViewItem();
		IMenu BuildMenu();
		IToolStripMenuView BuildToolStripMenu();
		IContextMenuView BuildContextMenu();
		IMenuItemView BuildMenuItem();
		IMenuItemView BuildContextMenuItem();
		IMenuItemSeperator BuildMenuItemSeperator();
		IPictureView BuildPictureView();
		SplitContainerView BuildSplitContainerView();
		ITextBoxView BuildTextBoxView();
		ITrackBarView BuildTrackBar();


		IPanelView BuildPanel();

		//SongIllustrator.Timer BuildTimer();

		IMessageBox BuildPopup();

		OpenFileDialogView BuildOpenFileDialog();

		SaveFileDialogView BuildSaveDialog();

		IMediaPlayer BuildMediaPlayer(IFormView formView);

		ControlSize MaxBounds();

		ControlLocation GetCursorPosition();
	}
}
