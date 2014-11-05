using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SongIllustrator {
	public partial class TutorialForm : Form {
		public TutorialForm() {
			InitializeComponent();
		}
		List<TutorialPage> _tutorialPages = new List<TutorialPage>();

		internal List<TutorialPage> TutorialPages {
			get {
				return _tutorialPages;
			}
			set {
				_tutorialPages = value;
			}
		}
		int _currentPage = 0;
		private void richTextBox1_TextChanged(object sender, EventArgs e) {

		}

		private void previousImageButton_Click(object sender, EventArgs e) {
			if (_currentPage > 0) {
				_currentPage--;
				SetPage();
			}
		}
		private void SetPage() {
			if (_tutorialPages.Count > 0) {
				if (_currentPage < _tutorialPages.Count && _currentPage >= 0) {
					textBox1.Text = _tutorialPages[_currentPage].Description;
					visualPictureBox.BackgroundImage = _tutorialPages[_currentPage].Image;
				}
			}
		}
		private void nextImageButton_Click(object sender, EventArgs e) {
			if (_currentPage < _tutorialPages.Count) {
				_currentPage++;
				SetPage();
			}
		}

		private void TutorialForm_Load(object sender, EventArgs e) {

		}

		private void TutorialForm_Shown(object sender, EventArgs e) {
			SetPage();
		}
	}
}
