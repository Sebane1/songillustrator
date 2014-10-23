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

		private void timer1_Tick(object sender, EventArgs e) {

		}

		public void UpdateTimeline() {
			if (!DesignMode) {
				panel1.Controls.Clear();
				Form1 form = (Form1) this.Parent.Parent.Parent;
				foreach (LightData padData in form.LaunchPads) {
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
								for (int z = 0; z < form.Canvas.Controls.Count; z++) {
									try {
										form.Canvas.Controls[z].BackColor = frameData.Colours[z];
										form.Timestamp = frameData.TimeStamp.ToString();
									} catch {
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
		//private void UpdateTimeline(int width) {
		//  if (!DesignMode) {
		//    panel1.Controls.Clear();
		//    Form1 form = (Form1) this.Parent.Parent.Parent;
		//    if (form.Frames.Count > 0) {
		//      decimal maxMilliseconds = form.Frames[form.Frames.Count - 1].TimeStamp;
		//      int lastXPosition = 0;
		//      for (int i = 0; i < form.Frames.Count; i++) {
		//        FrameData frame = form.Frames[i];
		//        TimelineItem button = new TimelineItem();
		//        button.Density = form.Density;
		//        button.ScaleOffset = width;
		//        button.Frame = frame;
		//        button.Location = new Point((int) frame.TimeStamp * width, 0);
		//        decimal buttonWidth = frame.TimeStamp - form.Frames[i > 0 ? i - 1 : i].TimeStamp * width;
		//        if (panel1.Controls.Count > 0) {
		//          //panel1.Controls[i > 0 ? i - 1 : i].Width = (int)buttonWidth;
		//        }
		//        button.Width = (int) 20;
		//        button.Height = 20;
		//        button.ClickEvent(delegate {
		//          FrameData frameData = frame;
		//          for (int z = 0; z < form.Canvas.Controls.Count; z++) {
		//            try {
		//              form.Canvas.Controls[z].BackColor = frameData.Colours[z];
		//              form.Timestamp = frameData.TimeStamp.ToString();
		//            } catch {
		//            }
		//          }
		//        });
		//        lastXPosition += (int) frame.TimeStamp;
		//        try {
		//          panel1.Controls.Add(button);
		//        } catch {
		//        }
		//      }
		//    }
		//  }
		//}

		private void trackBar1_ValueChanged(object sender, EventArgs e) {
		//	UpdateTimeline(trackBar1.Value);
		}
	}
}
