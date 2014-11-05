using File_Encryptor_Launcher.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using SongIllustrator;
using System.Collections.Generic;
namespace File_Encryptor_Launcher {
	public class Launcher : Form {
		private IContainer components = null;
		private TextBox textBox1;
		private Timer timer1;
		private Timer timer2;
		private BackgroundWorker backgroundWorker1;
		private WebBrowser webBrowser1;
		private WebClient webClient = new WebClient();
		private string commandLine = /*"(path)" + Application.StartupPath + "\\Song Illustrator Launcher.exe"*/null;
		private bool _downloading = false;
		private bool finishedDownload = false;
		private int progress = 0;
		private Panel panel1;
		private int i = 0;
		MilliStopWatch stopwatch = new MilliStopWatch();
		private Timer timer3;
		int frameProgress = 0;
		int pixelDensity;
		List<FrameData> frames = new List<FrameData>();
		public string CommandLine {
			get {
				return this.commandLine;
			}
			set {
				this.commandLine = value;
			}
		}
		protected override void Dispose(bool disposing) {
			if (disposing && this.components != null) {
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.webBrowser1 = new System.Windows.Forms.WebBrowser();
			this.panel1 = new System.Windows.Forms.Panel();
			this.timer3 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.Color.Black;
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox1.ForeColor = System.Drawing.Color.White;
			this.textBox1.Location = new System.Drawing.Point(12, 307);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(785, 20);
			this.textBox1.TabIndex = 0;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// timer2
			// 
			this.timer2.Interval = 1000;
			this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.WorkerReportsProgress = true;
			this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
			this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
			this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
			// 
			// webBrowser1
			// 
			this.webBrowser1.Location = new System.Drawing.Point(699, 326);
			this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.ScriptErrorsSuppressed = true;
			this.webBrowser1.Size = new System.Drawing.Size(20, 20);
			this.webBrowser1.TabIndex = 1;
			this.webBrowser1.Url = new System.Uri("http://ombstats.x10.mx/Song Illustrator/check.htm", System.UriKind.Absolute);
			this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
			this.webBrowser1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser1_Navigated);
			this.webBrowser1.NewWindow += new System.ComponentModel.CancelEventHandler(this.webBrowser1_NewWindow);
			// 
			// panel1
			// 
			this.panel1.BackgroundImage = global::Properties.Resources.si;
			this.panel1.Location = new System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(778, 274);
			this.panel1.TabIndex = 2;
			// 
			// timer3
			// 
			this.timer3.Enabled = true;
			this.timer3.Interval = 1;
			this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
			// 
			// Launcher
			// 
			this.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (192)))), ((int) (((byte) (64)))), ((int) (((byte) (192)))));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(802, 341);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.webBrowser1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Launcher";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Launcher";
			this.TransparencyKey = System.Drawing.Color.FromArgb(((int) (((byte) (192)))), ((int) (((byte) (64)))), ((int) (((byte) (192)))));
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Shown += new System.EventHandler(this.Launcher_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		public Launcher() {
			this.InitializeComponent();
		}
		public void GeneratePixels(int pixels) {
			panel1.Controls.Clear();
			Size buttonSize = new Size(panel1.Width / pixels, panel1.Height / pixels);
			for (int heightProgression = 0; heightProgression < pixels; heightProgression++) {

				for (int widthProgression = 0; widthProgression < pixels; widthProgression++) {
					DisplayButton button = new DisplayButton();
					button.Size = buttonSize;
					button.Location = new Point(buttonSize.Width * widthProgression, buttonSize.Height * heightProgression);
					panel1.Controls.Add(button);
				}
			}
		}
		private void timer1_Tick(object sender, EventArgs e) {
			if (this.textBox1.Width < 232) {
				this.textBox1.Width++;
			} else {
				if (this.textBox1.Height < 40) {
					this.textBox1.Height++;
				} else {
					this.timer1.Stop();
					this.timer2.Start();
				}
			}
		}
		private void timer2_Tick(object sender, EventArgs e) {
			try {
				switch (this.i) {
					case 0:
						this.textBox1.AppendText("Connecting to server.\r\n");
						this.i++;
						break;
					case 1: {
							this.textBox1.AppendText("Looking for updates.\r\n");
							Stream stream = this.webClient.OpenRead("http://sebastianlawe.com/apps/si/version.txt");
							string b = null;
							try {
								FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(Program.RecentFileLog);
								b = versionInfo.ProductVersion;
							} catch {
								b = "0.0.0.0";
							}
							using (StreamReader streamReader = new StreamReader(stream)) {
								if (streamReader.ReadLine() != b) {
									this.i++;
								} else {
									this.timer2.Stop();
									this.textBox1.AppendText("Things are up to date.\r\n");
									Process.Start(Program.RecentFileLog, this.commandLine);
									base.Close();
								}
							}
							break;
						}
					case 2:
						if (!this._downloading) {
							this.timer2.Stop();
							switch (MessageBox.Show("A new version of Song Illustrator has been found, would you like to update?", "Launcher", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)) {
								case DialogResult.Yes:
									this.textBox1.AppendText("Downloading updates.\r\n");
									this.Refresh();
									this._downloading = true;
									this.backgroundWorker1.RunWorkerAsync();
									break;
								case DialogResult.No:
									Process.Start(Program.RecentFileLog, this.commandLine);
									base.Close();
									break;
							}
						}
						if (this.finishedDownload) {
							this.i++;
						}
						break;
				}
			} catch {
				this.timer2.Stop();
				this.textBox1.AppendText("No Internet Connection");
				Process.Start(Program.RecentFileLog, this.commandLine);
				base.Close();
			}
		}
		public void OverlayButtons(Image bitmap, Control.ControlCollection controls) {
			List<Image> images = ImageSlicer.SliceImage((Bitmap) bitmap, panel1.Size, new Size(pixelDensity, pixelDensity));
			for (int i = 0; i < controls.Count; i++) {
				controls[i].BackgroundImage = images[i];
			}
		}
		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
			try {
				using (StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "\\checkAdmin")) {
					streamWriter.WriteLine(DateTime.Today.ToString());
				}
			} catch {
				UACHelper.RestartProcessElevated(this.commandLine);
				this.textBox1.AppendText("Things are up to date.\r\n");
				Process.Start(Program.RecentFileLog, this.commandLine);
				base.Close();
			}
			string text = "release";
			bool flag = false;
			PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(text, new MD5CryptoServiceProvider().ComputeHash(Encoding.Unicode.GetBytes(text)));
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			rijndaelManaged.Key = passwordDeriveBytes.GetBytes(32);
			rijndaelManaged.IV = passwordDeriveBytes.GetBytes(16);
			rijndaelManaged.BlockSize = 128;
			rijndaelManaged.Padding = PaddingMode.PKCS7;
			using (ICryptoTransform cryptoTransform = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV)) {
				using (Stream stream = this.webClient.OpenRead("http://sebastianlawe.com/apps/si/updatepackage.ecrb")) {
					using (CryptoStream cryptoStream = new CryptoStream(stream, cryptoTransform, CryptoStreamMode.Read)) {
						using (GZipStream gZipStream = new GZipStream(cryptoStream, CompressionMode.Decompress)) {
							if (flag) {
								using (BinaryReader binaryReader = new BinaryReader(gZipStream)) {
									while (true) {
										string text2 = binaryReader.ReadString();
										if (text2.Length == 0) {
											break;
										}
										long num = binaryReader.ReadInt64();
										using (FileStream fileStream = new FileStream(Path.Combine(Application.StartupPath, Path.GetFileName(text2)), FileMode.Create, FileAccess.Write, FileShare.Read)) {
											byte[] array = new byte[4096];
											long num2 = 0L;
											int num3;
											while ((num3 = binaryReader.Read(array, 0, (int) Math.Min((long) array.Length, num - num2))) > 0) {
												fileStream.Write(array, 0, num3);
												num2 += (long) num3;
											}
										}
									}
								}
							} else {
								using (BinaryReader binaryReader = new BinaryReader(gZipStream)) {
									string a = binaryReader.ReadString();
									if (a == "a338c555-8b3a-4ddc-918d-b93776a58d17") {
										while (true) {
											string text2 = binaryReader.ReadString();
											if (text2.Length == 0) {
												break;
											}
											long num = binaryReader.ReadInt64();
											if (!File.Exists(string.Concat(new string[]
											{
												Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
												"\\",
												Application.CompanyName,
												"\\",
												Application.ProductName,
												"\\"
											}))) {
												Directory.CreateDirectory(string.Concat(new string[]
												{
													Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
													"\\",
													Application.CompanyName,
													"\\",
													Application.ProductName,
													"\\"
												}));
											}
											using (FileStream fileStream = new FileStream(Path.Combine(string.Concat(new string[]
											{
												Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
												"\\",
												Application.CompanyName,
												"\\",
												Application.ProductName,
												"\\"
											}), Path.GetFileName(text2)), FileMode.Create, FileAccess.Write, FileShare.Read)) {
												byte[] array = new byte[4096];
												long num2 = 0L;
												int num3;
												while ((num3 = binaryReader.Read(array, 0, (int) Math.Min((long) array.Length, num - num2))) > 0) {
													fileStream.Write(array, 0, num3);
													num2 += (long) num3;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			this.finishedDownload = true;
			this.textBox1.AppendText("Things are up to date.\r\n");
			Process.Start(Program.RecentFileLog, this.commandLine);
			base.Close();
		}
		private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) {
			this.progress = e.ProgressPercentage;
		}
		private void Form1_Load(object sender, EventArgs e) {
			GeneratePixels(30);
			OpenFileDialog(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sig.slif"));
			OverlayButtons(panel1.BackgroundImage, panel1.Controls);
		}
		private void textBox1_TextChanged(object sender, EventArgs e) {
		}
		private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e) {
			/*this.webBrowser1.Focus();
			SendKeys.Send("{TAB}");
			SendKeys.Send("{TAB}");
			SendKeys.Send("{TAB}");
			SendKeys.Send("{ENTER}");*/
		}
		private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
		}
		private void webBrowser1_NewWindow(object sender, CancelEventArgs e) {
			e.Cancel = true;
		}

		private void Launcher_Shown(object sender, EventArgs e) {
			timer1.Start();
		}
		private void OpenFileDialog(string filepath) {
			frames.Clear();
			frameProgress = 0;
			timer1.Stop();
			stopwatch.Stop();
			stopwatch.Reset();
			using (FileStream openStream = new FileStream(filepath, FileMode.Open, FileAccess.Read)) {
				using (BinaryReader reader = new BinaryReader(openStream)) {
					string version = reader.ReadString();
					if (version.Contains("v")) {
						GeneratePixels(pixelDensity = reader.ReadInt32());
						int frameCount;
						frameCount = reader.ReadInt32();
						for (int i = 0; i < frameCount; i++) {
							FrameData frame = new FrameData();
							frame.TimeStamp = reader.ReadInt32();
							int colourCount = reader.ReadInt32();
							for (int colorNumber = 0; colorNumber < colourCount; colorNumber++) {
								try {
									frame.Colours.Add(Color.FromArgb(reader.ReadInt32()));
								} catch {
									object test;
								}
							}
							frames.Add(frame);
						}
						try {
							//axWindowsMediaPlayer1.URL = reader.ReadString();
						} catch {

						}
					}
				}
			}
		}
		private void timer3_Tick(object sender, EventArgs e) {
			stopwatch.Stop();
			foreach (FrameData time in frames) {
				if (stopwatch.Elapsed == time.TimeStamp) {
					for (int i = 0; i < panel1.Controls.Count; i++) {
						panel1.Controls[i].BackColor = time.Colours[i];
						if (panel1.Controls.Count > 0) {
							try {
								panel1.Controls[i].BackColor = time.Colours[i];
							} catch {

							}
						}
					}
					frameProgress++;
				}
			}
			if (frameProgress >= frames.Count) {
				stopwatch.Reset();
				stopwatch.Start();
				frameProgress = 0;
			}
			stopwatch.Start();
		}
	}
}
