﻿using System;
using System.Collections.Generic;
using System.Text;
using ControlFactory;
using Win32Factory.Wrappers;
using Win32Factory;
using System.Windows.Forms;

namespace SongIllustrator {
	public class Win32Factory : IFactory {
		#region IFactory Members

		public IButtonView BuildButton() {
			return new ButtonWrapper();
		}

		public IRichTextBoxView BuildRichTextBox() {
			return new RichTextBoxWrapper();
		}

		public ITextBoxView BuildTextBox() {
			return new TextBoxWrapper();
		}

		public IView BuildFormControl() {
			return new ControlWrapper();
		}

		public IFormView BuildFormView() {
			return new FormWrapper();
		}

		public ILabelView BuildLabelView() {
			return new LabelWrapper();
		}

		public IArrayView BuildListView() {
			return new ListBoxWrapper();
		}

		public IArrayViewItem BuildListViewItem() {
			return null;
		}

		public IMenu BuildMenu() {
			throw new NotImplementedException();
		}

		public IMenuItemView BuildMenuItem() {
			return new ToolStripMenuItemWrapper();
		}

		public IMenuItemSeperator BuildMenuItemSeperator() {
			return new ToolStripSeparatorWrapper();
		}

		public IPictureView BuildPictureView() {
			return new PictureBoxWrapper();
		}

		public SplitContainerView BuildSplitContainerView() {
			return new SplitContainerWrapper();
		}

		public ITextBoxView BuildTextBoxView() {
			return new TextBoxWrapper();
		}

		public ITrackBarView BuildTrackBar() {
			return new TrackBarWrapper();
		}

		#endregion

		#region IFactory Members


		public IToolStripMenuView BuildToolStripMenu() {
			return new ToolStripMenuWrapper();
		}

		public IContextMenuView BuildContextMenu() {
			return new ContextMenuWrapper();
		}

		#endregion

		#region IFactory Members


		public IPanelView BuildPanel() {
			return new PanelWrapper();
		}

		//public Timer BuildTimer() {
		//  return new 
		//}

		#endregion

		#region IFactory Members

		#endregion

		#region IFactory Members


		public IMessageBox BuildPopup() {
			return new MessageBoxWrapper();
		}

		#endregion

		#region IFactory Members


		public OpenFileDialogView BuildOpenFileDialog() {
			return new OpenFileDialogWrapper();
		}

		public SaveFileDialogView BuildSaveDialog() {
			return new SaveDialogWrapper();
		}

		#endregion

		#region IFactory Members


		public IMediaPlayer BuildMediaPlayer(IFormView formView) {
			return new MediaPlayerWrapper(this, formView);
		}

		#endregion

		#region IFactory Members


		public ControlSize MaxBounds() {
			return new ControlSize(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
		}

		#endregion

		#region IFactory Members


		public ControlLocation GetCursorPosition() {
			return new ControlLocation(Cursor.Position.X, Cursor.Position.Y - 20);
		}

		#endregion

		#region IFactory Members


		public IMenuItemView BuildContextMenuItem() {
			return new MenuItemWrapper();
		}

		#endregion
	}
}
