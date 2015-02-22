using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using ControlFactory;

namespace SongIllustrator {
	public partial class TutorialForm : IView {
		IFormView _formView;
		public TutorialForm(IFactory factory) {
			InitializeComponent();
			_factory = factory;
			_formView = _factory.BuildFormView();
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

		#region IView Members

		public event EventHandler Click;

		public event EventHandler RightClicked;

		public event EventHandler KeyDown;

		public event EventHandler KeyUp;

		public event EventHandler Resized;

		public void Initialize() {
			throw new NotImplementedException();
		}

		public int TabIndex {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public IView Parent {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public string Name {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public ControlSize Size {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public ControlLocation Location {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public List<IView> FormControls {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		void IView.Dispose(bool dispose) {
			throw new NotImplementedException();
		}

		public int Height {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public bool Enabled {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		#endregion

		#region IView Members


		public bool Visible {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public EventHandler Load {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public EventHandler Shown {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public EventHandler DoubleClick {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public string Text {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		#endregion

		internal void ShowDialog() {
			throw new NotImplementedException();
		}

		#region IView Members


		public int Width {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public int height {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		#endregion

		#region IView Members

		void IView.Initialize() {
			throw new NotImplementedException();
		}

		int IView.TabIndex {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		IView IView.ParentControl {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		string IView.Name {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		ControlSize IView.ControlSize {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		ControlLocation IView.ControlLocation {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		int IView.ControlWidth {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		int IView.ControlHeight {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		bool IView.Visible {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		bool IView.Enabled {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}
		string IView.Text {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		#endregion

		#region IView Members


		public event EventHandler BackColorChanged;

		public Color ControlBackColor {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		#endregion

		#region IView Members



		#endregion

		#region IView Members

		
		#endregion

		#region IView Members


		public void AddControl(IView control) {
			throw new NotImplementedException();
		}

		public void RemoveControl(IView control) {
			throw new NotImplementedException();
		}

		public void RemoveControl(int index) {
			throw new NotImplementedException();
		}

		event EventHandler IView.Load {
			add {
				throw new NotImplementedException();
			}
			remove {
				throw new NotImplementedException();
			}
		}

		event EventHandler IView.Shown {
			add {
				throw new NotImplementedException();
			}
			remove {
				throw new NotImplementedException();
			}
		}

		event EventHandler IView.DoubleClick {
			add {
				throw new NotImplementedException();
			}
			remove {
				throw new NotImplementedException();
			}
		}

		#endregion

		#region IView Members


		public event EventHandler MouseLeftUp;

		public event EventHandler MouseRightUp;

		public event EventHandler MouseLeftDown;

		public event EventHandler MouseRightDown;
		private IFactory _factory;

		#endregion
	}
}
