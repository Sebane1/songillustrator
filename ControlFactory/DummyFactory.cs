using System;
using System.Collections.Generic;
using System.Text;
using ControlFactory;

namespace SongIllustrator {
	public class DummyFactory : IFactory {
		#region IFactory Members

		public IButtonView BuildButton() {
			return new object() as IButtonView;
		}

		public IRichTextBoxView BuildRichTextBox() {
			return new object() as IRichTextBoxView;
		}

		public ITextBoxView BuildTextBox() {
			return new object() as ITextBoxView;
		}

		public IView BuildFormControl() {
			return new object() as IView;
		}

		public IFormView BuildFormView() {
			return new object() as IFormView;
		}

		public ILabelView BuildLabelView() {
			return new object() as ILabelView;
		}

		public IArrayView BuildListView() {
			return new object() as IArrayView;
		}

		public IArrayViewItem BuildListViewItem() {
			return new object() as IArrayViewItem;
		}

		public IMenu BuildMenu() {
			return new object() as IMenu;
		}

		public IToolStripMenuView BuildToolStripMenu() {
			return new object() as IToolStripMenuView;
		}

		public IContextMenuView BuildContextMenu() {
			return new object() as IContextMenuView;
		}

		public IMenuItemView BuildMenuItem() {
			return new object() as IMenuItemView;
		}

		public IMenuItemSeperator BuildMenuItemSeperator() {
			return new object() as IMenuItemSeperator;
		}

		public IPictureView BuildPictureView() {
			return new object() as IPictureView;
		}

		public SplitContainerView BuildSplitContainerView() {
			return new object() as SplitContainerView;
		}

		public ITextBoxView BuildTextBoxView() {
			return new object() as ITextBoxView;
		}

		public ITrackBarView BuildTrackBar() {
			return new object() as ITrackBarView;
		}

		public IPanelView BuildPanel() {
			return new object() as IPanelView;
		}

		public IMessageBox BuildPopup() {
			return new object() as IMessageBox;
		}

		public OpenFileDialogView BuildOpenFileDialog() {
			return new object() as OpenFileDialogView;
		}

		public SaveFileDialogView BuildSaveDialog() {
			return new object() as SaveFileDialogView;
		}

		public IMediaPlayer BuildMediaPlayer(IFormView formView) {
			return new object() as IMediaPlayer;
		}

		#endregion

		#region IFactory Members


		public ControlSize MaxBounds() {
			throw new NotImplementedException();
		}

		#endregion

		#region IFactory Members


		public ControlLocation GetCursorPosition() {
			throw new NotImplementedException();
		}

		#endregion

		#region IFactory Members


		public IMenuItemView BuildContextMenuItem() {
			throw new NotImplementedException();
		}

		#endregion
	}
}
