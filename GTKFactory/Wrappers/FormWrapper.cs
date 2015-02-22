using System;
using System.Collections.Generic;
using System.Text;
using SongIllustrator;
using System.Windows.Forms;
using System.Reflection;

namespace Win32Factory.Wrappers {
	public class FormWrapper : IFormView {
		Form _form = new Form();
		#region IFormView Members

		public void ShowDialog() {
			SetDoubleBuffered(_form);
			_form.FormBorderStyle = FormBorderStyle.FixedSingle;
			_form.BackColor = System.Drawing.Color.Black;
			_form.Click += delegate {
				if (Click != null) {
					Click(this, EventArgs.Empty);
				}
			};
			_form.Show();
			_form.Refresh();
		}
		public static void SetDoubleBuffered(Control control) {
			// set instance non-public property with name "DoubleBuffered" to true
			typeof(Control).InvokeMember("DoubleBuffered",
					BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
					null, control, new object[] { true });
		}
		#endregion

		#region IView Members


		public event EventHandler RightClicked;

		public new event EventHandler KeyDown;

		public new event EventHandler KeyUp;

		public event EventHandler Resized;

		public void Initialize() {
			throw new NotImplementedException();
		}

		public IView ParentControl {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public ControlSize ControlSize {
			get {
				return new ControlSize(_form.Width, _form.Height);
			}
			set {
				_form.Size = new System.Drawing.Size(value.Width, value.Height);
			}
		}

		public ControlLocation ControlLocation {
			get {
				return new ControlLocation(_form.Location.X, _form.Location.Y);
			}
			set {
				_form.Size = new System.Drawing.Size(value.X, value.Y);
			}
		}

		public int ControlWidth {
			get {
				return _form.Width;
			}
			set {
				_form.Width = value;
			}
		}

		public int ControlHeight {
			get {
				return _form.Height;
			}
			set {
				_form.Height = value;
			}
		}

		public void AddControl(IView control) {
			try {
				_form.Controls.Add((control as ControlWrapper).Control);
				_viewList.Add(_viewList.Count, control);
			} catch {
			
			}
			//_form.Refresh();
			_form.BringToFront();
		}

		public void RemoveControl(IView control) {
			_form.Controls.Remove((control as ControlWrapper).Control);
		}

		public void RemoveControl(int index) {
			_form.Controls.RemoveAt(index);
		}

		public new void Dispose(bool dispose) {
			throw new NotImplementedException();
		}

		public Color ControlBackColor {
			get {
				return Color.FromArgb(_form.BackColor.ToArgb());
			}
			set {
				_form.BackColor = System.Drawing.Color.FromArgb(value.ToArgb());
			}
		}

		#endregion

		#region IView Members

		public event EventHandler Click;

		public event EventHandler BackColorChanged;

		public int TabIndex {
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

		public bool Visible {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
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

		public event EventHandler Load;

		public event EventHandler Shown;

		public event EventHandler DoubleClick;

		public string Text {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		#endregion
		Dictionary<int, IView> _viewList = new Dictionary<int, IView>();
		#region IContainerView Members

		public Dictionary<int, IView> ViewList {
			get {
				return _viewList;
			}
		}

		public void Clear() {
			_form.Controls.Clear();
		}

		public void Add(IView item) {
			AddControl(item);
		}

		public void Remove(IView item) {
			RemoveControl(item);
		}

		public void Remove(int index) {
			RemoveControl(index);
		}

		public void AddRange(IView[] items) {
			foreach (IView item in items) {
				AddControl(item);
			}
		}

		public void AddRange(List<IView> items) {
			AddRange(items.ToArray());
		}

		public int Count {
			get {
				return _form.Controls.Count;
			}
			set {
				int boob = value;
			}
		}

		#endregion

		#region IFormView Members


		public IView MenuStrip {
			get {
				return null;
			}
			set {
				_form.MainMenuStrip = (value as ControlWrapper).Control as MenuStrip;
			}
		}

		#endregion

		#region IFormView Members


		public void EnableFullscreen() {
			_form.FormBorderStyle = FormBorderStyle.None;
			//_form.TopMost = true;
			_form.WindowState = FormWindowState.Maximized;
		}

		#endregion

		#region IFormView Members


		public void DisableFullScreen() {
			_form.FormBorderStyle = FormBorderStyle.FixedSingle;
			_form.TopMost = false;
			_form.WindowState = FormWindowState.Normal;
		}

		#endregion

		#region IView Members


		public event EventHandler MouseLeftUp;

		public event EventHandler MouseRightUp;

		public event EventHandler MouseLeftDown;

		public event EventHandler MouseRightDown;

		#endregion
	}
}
