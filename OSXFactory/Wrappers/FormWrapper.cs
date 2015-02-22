using System;
using System.Collections.Generic;
using System.Text;
using SongIllustrator;
using System.Reflection;
using MonoMac.AppKit;
using MonoMac.Foundation;
using System.Drawing;

namespace OSXFactory.Wrappers {
	public class FormWrapper : IFormView {
		NSWindow _form = new NSWindow();
		#region IFormView Members

		public void ShowDialog() {
			//_form.BackColor = System.Drawing.Color.Black;
			/*_form.MouseUp += delegate {
				if (Click != null) {
					Click(this, EventArgs.Empty);
				}
			};*/
			//_form.Window.IsMainWindow = true;
			//_form
			_form.MakeKeyAndOrderFront(new NSObject());
			//_form.Refresh();
		}
		/*public static void SetDoubleBuffered(Control control) {
			// set instance non-public property with name "DoubleBuffered" to true
			typeof(Control).InvokeMember("DoubleBuffered",
					BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
					null, control, new object[] { true });
		}*/
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
				return new ControlSize((int)_form.Frame.Width, (int)_form.Frame.Height);
			}
			set {
				_form.ContentView.Bounds = new RectangleF (_form.Frame.X, _form.Frame.Y, value.Width, value.Height);
				//_form.Frame.Height = value.Height;
			}
		}

		public ControlLocation ControlLocation {
			get {
				return new ControlLocation((int)_form.Frame.X, (int)_form.Frame.X);
			}
			set {
				_form.ContentView.Bounds = new RectangleF (value.X, value.Y, _form.Frame.Width, _form.Frame.Height);
			}
		}

		public int ControlWidth {
			get {
				return (int)_form.Frame.Width;
			}
			set {
				_form.ContentView.Bounds = new RectangleF (_form.Frame.X, _form.Frame.Y, value, _form.Frame.Height);
			}
		}

		public int ControlHeight {
			get {
				return (int)_form.Frame.Height;
			}
			set {
				_form.ContentView.Bounds = new RectangleF (_form.Frame.X, _form.Frame.Y, _form.Frame.Width, value);
			}
		}

		public void AddControl(IView control) {
			try {
				//_form(control as ControlWrapper).Control;
				//(control as NSControl).
				_viewList.Add(_viewList.Count, control);
			} catch {
			
			}
			//_form.Refresh();
			//_form.BringToFront();
		}

		public void RemoveControl(IView control) {
			//_form.Controls.Remove((control as ControlWrapper).Control);
			//_viewList.Remove (control);
		}

		public void RemoveControl(int index) {
			//_form.Controls.RemoveAt(index);
			_viewList.Remove (index);
		}

		public new void Dispose(bool dispose) {
			throw new NotImplementedException();
		}

		public SongIllustrator.Color ControlBackColor {
			get {
				return SongIllustrator.Color.FromArgb(
					(int)_form.BackgroundColor.AlphaComponent, 
					(int)_form.BackgroundColor.RedComponent, 
					(int)_form.BackgroundColor.GreenComponent, 
					(int)_form.BackgroundColor.BlueComponent);
			}
			set {
				//_form.BackgroundColor = (System.Drawing.Color.FromArgb(value.ToArgb());
				object val = value;
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
			//_form.Controls.Clear();
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
				//return _form.Controls.Count;
				return -1;
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
				_form.Menu = (value as NSMenu);
			}
		}

		#endregion

		#region IFormView Members


		public void EnableFullscreen() {
			//_form.FormBorderStyle = FormBorderStyle.None;
			//_form.TopMost = true;
			//_form.WindowState = FormWindowState.Maximized;
		}

		#endregion

		#region IFormView Members


		public void DisableFullScreen() {
			//_form.FormBorderStyle = FormBorderStyle.FixedSingle;
			//_form.TopMost = false;
			//_form.WindowState = FormWindowState.Normal;
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
