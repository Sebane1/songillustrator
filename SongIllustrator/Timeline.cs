using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SongIllustrator {
	public partial class Timeline : UserControl {
		public Timeline() {
			InitializeComponent();
		}



		private void Timeline_Load(object sender, EventArgs e) {

		}
		public void UpdateTimeline() {
			if (!DesignMode) {
				panel1.Controls.Clear();
				Form1 form = (Form1) this.Parent.Parent.Parent;
				foreach (Launchpad padData in form.LaunchPads) {
					if (padData.FrameData.Count > 0) {
						decimal maxMilliseconds = padData.FrameData[padData.FrameData.Count - 1].TimeStamp;
						int lastXPosition = 0;
						for (int i = 0; i < padData.FrameData.Count; i++) {
							FrameData frame = padData.FrameData[i];
							TimelineItem button = new TimelineItem();
							button.Density = form.Density;
							button.Frame = frame;
							button.Location = new Point((int) frame.TimeStamp, 0);
							decimal buttonWidth = frame.TimeStamp - padData.FrameData[i > 0 ? i - 1 : i].TimeStamp;
							if (panel1.Controls.Count > 0) {
								//panel1.Controls[i > 0 ? i - 1 : i].Width = (int) buttonWidth;
							}
							button.Width = (int) 20;
							button.Height = 20;
							button.ClickEvent(delegate {
								FrameData frameData = frame;
								if (form.FrameList.Items.Count > 0) {
									int index = i;
									foreach (FrameData item in form.FrameList.Items) {
										if (item.TimeStamp == frameData.TimeStamp) {
											form.FrameList.SelectedItem = item;
											break;
										}
									}
								}
								for (int y = 0; y < form.Canvas.Controls.Count; y++) {
									LightPad pad = (form.Canvas.Controls[y] as LightPad);
									if (pad != null) {
										pad.SetFrame(form.FrameList.SelectedIndex);
										form.Timestamp = (form.FrameList.SelectedItem as FrameData).TimeStamp.ToString();
									}
								}
							});
							lastXPosition += (int) frame.TimeStamp;
							try {
								panel1.Controls.Add(button);
							} catch {
							}
						}
					}
				}
			}
		}

		private void trackBar1_ValueChanged(object sender, EventArgs e) {
			//	UpdateTimeline(trackBar1.Value);
		}
	}
}
