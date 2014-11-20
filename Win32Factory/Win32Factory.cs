using System;
using System.Collections.Generic;
using System.Text;
using ControlFactory;
using Win32Factory.Wrappers;

namespace SongIllustrator {
	public class Win32Factory : Factory {
		#region Factory Members

		public ButtonView BuildButton() {
			return new ButtonWrapper();
		}

		public TextBoxView BuildRichTextBox() {
			return new TextBoxWrapper();
		}

		public TextBoxView BuildTextBox() {
			return new TextBoxWrapper();
		}

		public FormControl BuildFormControl() {
			return new ControlWrapper();
		}

		public FormView BuildFormView() {
			return new FormWrapper();
		}

		public LabelView BuildLabelView() {
			return new LabelWrapper();
		}

		public ArrayView BuildListView() {
			return new ListBoxWrapper();
		}

		public ArrayViewItem BuildListViewItem() {
			return null;
		}

		public Menu BuildMenu() {
			throw new NotImplementedException();
		}

		public MenuItemView BuildMenuItem() {
			return new ToolStripMenuItemWrapper();
		}

		public MenuItemSeperator BuildMenuItemSeperator() {
			return new ToolStripSeparatorWrapper();
		}

		public PictureView BuildPictureView() {
			return new PictureBoxWrapper();
		}

		public SplitContainerView BuildSplitContainerView() {
			return new SplitContainerWrapper();
		}

		public TextBoxView BuildTextBoxView() {
			return new TextBoxWrapper();
		}

		public TrackBarView BuildTrackBar() {
			return new TrackBarWrapper();
		}

		#endregion

		#region Factory Members


		public ToolStripMenuView BuildToolStripMenu() {
			return new ToolStripMenuWrapper();
		}

		public ContextMenuView BuildContextMenu() {
			return new ContextMenuWrapper();
		}

		#endregion

		#region Factory Members


		public FormControl BuildPanel() {
			return new ControlWrapper();
		}

		//public Timer BuildTimer() {
		//  return new 
		//}

		#endregion

		#region Factory Members


		public Timer BuildTimer() {
			throw new NotImplementedException();
		}

		#endregion
	}
}
