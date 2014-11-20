using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;

namespace SongIllustrator {
	public partial class Timeline : FormControl {
		private void Timeline_Load(object sender, EventArgs e) {

		}
		public void UpdateTimeline() {
			FormControls.Clear();
			BaseForm form = (BaseForm) this.ParentControl.ParentControl.ParentControl;
			foreach (Launchpad padData in form.LaunchPads) {
				if (padData.FrameData.Count > 0) {
					decimal maxMilliseconds = padData.FrameData[padData.FrameData.Count - 1].TimeStamp;
					int lastXPosition = 0;
					for (int i = 0; i < padData.FrameData.Count; i++) {
						FrameData frame = padData.FrameData[i];
						TimelineItem button = new TimelineItem();
						button.Density = form.Density;
						button.Frame = frame;
						button.ControlLocation = new ControlLocation((int) frame.TimeStamp, 0);
						decimal buttonWidth = frame.TimeStamp - padData.FrameData[i > 0 ? i - 1 : i].TimeStamp;
						if (FormControls.Count > 0) {
							//panel1.FormControls[i > 0 ? i - 1 : i].ControlWidth = (int) buttonWidth;
						}
						button.ControlWidth = (int) 20;
						button.Height = 20;
						button.ClickEvent(delegate {
							FrameData frameData = frame;
							if (form.FrameList.ControlItems.Count > 0) {
								int index = i;
								foreach (FrameData item in form.FrameList.ControlItems) {
									if (item.TimeStamp == frameData.TimeStamp) {
										form.FrameList.SelectedItem = item;
										break;
									}
								}
							}
							for (int y = 0; y < form.Canvas.FormControls.Count; y++) {
								LightPad pad = (form.Canvas.FormControls[y] as LightPad);
								if (pad != null) {
									pad.SetFrame(form.FrameList.SelectedIndex);
									form.Timestamp = (form.FrameList.SelectedItem as FrameData).TimeStamp.ToString();
								}
							}
						});
						lastXPosition += (int) frame.TimeStamp;
						try {
							FormControls.Add(button);
						} catch {
						}
					}
				}
			}
		}

		#region FormControl Members

		public event EventHandler Clicked;

		public event EventHandler RightClicked;

		public event EventHandler KeyDown;

		public event EventHandler KeyUp;

		public event EventHandler Resized;

		public void Initialize() {
			throw new NotImplementedException();
		}

		public FormControl ParentControl {
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

		public ControlSize ControlSize {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public ControlLocation ControlLocation {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public List<FormControl> FormControls {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public void Dispose(bool dispose) {
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
		private void trackBar1_ValueChanged(object sender, EventArgs e) {
			//	UpdateTimeline(trackBar1.Value);
		}
		#endregion

		#region FormControl Members

		public event EventHandler Click;

		public int TabIndex {
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

		public ControlSize MinimumSize {
			get;
			set;
		}

		#region FormControl Members


		public int ControlWidth {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public int ControlHeight {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		#endregion

		#region FormControl Members


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

		#region FormControl Members

		#endregion

		#region FormControl Members

		EventHandler FormControl.Click {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		EventHandler FormControl.RightClicked {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		EventHandler FormControl.KeyDown {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		EventHandler FormControl.KeyUp {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		EventHandler FormControl.Resized {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		#endregion
	}
}

