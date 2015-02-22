using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Text;

namespace SongIllustrator {
	static class Program {
		private static string _defaultPath = string.Concat(new string[]
		{
			Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
			"\\",
			Application.CompanyName,
			"\\",
			Application.ProductName,
			"\\"
		});
		private static string _scriptTempFilename;
		private static bool _isDefaultPath = false;
		private static bool _forceRedownload = false;
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args) {
			//Application.EnableVisualStyles();
			//Application.SetCompatibleTextRenderingDefault(false);
			//Debugger.Break();
			_isDefaultPath = AppDomain.CurrentDomain.BaseDirectory == _defaultPath;
#if DEBUG
			_isDefaultPath = true;
#endif
			_isDefaultPath = true;
			if (!_isDefaultPath) {
				CreateShortcut(Path.Combine(Environment.GetFolderPath(
					Environment.SpecialFolder.DesktopDirectory),
					Path.GetFileName(Application.ProductName) + ".lnk"), Path.Combine(_defaultPath,
					Application.ProductName.Replace(" ", null) + ".exe"), "");
			}
			bool errorCheck = DownloadFiles(CheckMissingFiles(_defaultPath), @"http://www.sebastianlawe.com/apps/si/windows/", _defaultPath);
			if (_isDefaultPath && errorCheck && !_forceRedownload) {
				if (args.Length > 0) {
					//Application.Run(new Form(args[0]));
					new MainForm(FactoryLoader.LoadFactory());
				} else {
					new MainForm(FactoryLoader.LoadFactory());
					//Application1.Run();
				}
			} else {
				if (!_isDefaultPath && errorCheck) {
					//SelfCopy(_defaultPath);
					Process.Start(Path.Combine(_defaultPath, Application.ProductName.Replace(" ", null) + ".exe"));
				}
			}
		}

		private static void SelfCopy(string destination) {
			using (FileStream openStream = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Application.ProductName.Replace(" ", null) + ".exe"), FileMode.Open, FileAccess.Read)) {
				if (!Directory.Exists(destination)) {
					Directory.CreateDirectory(destination);
				}
				using (FileStream saveStream = new FileStream(Path.Combine(destination, Application.ProductName.Replace(" ", null) + ".exe"), FileMode.Create, FileAccess.Write)) {
					openStream.CopyTo(saveStream);
				}
			}
		}
		private static List<string> CheckMissingFiles(string directory) {
			WebClient client = new WebClient();
			List<string> missingFiles = new List<string>();
			try {
				using (StreamReader reader = new StreamReader(client.OpenRead(@"http://www.sebastianlawe.com/apps/si/version.txt"))) {
					_forceRedownload = reader.ReadLine() != Application.ProductVersion;
				}
			} catch (WebException) {
			}
			try {
				if (_forceRedownload && _isDefaultPath) {
					SelfCopy(Environment.GetEnvironmentVariable("TEMP"));
					DownloadFiles(CheckMissingFiles(Path.Combine(Environment.GetEnvironmentVariable("TEMP"))), @"http://www.sebastianlawe.com/apps/si/windows/", Path.Combine(Environment.GetEnvironmentVariable("TEMP")));
					Process.Start(Path.Combine(Environment.GetEnvironmentVariable("TEMP"), Application.ProductName.Replace(" ", null) + ".exe"));
					Process.GetCurrentProcess().Kill();
				} else {
					using (StreamReader reader = new StreamReader(client.OpenRead(@"http://www.sebastianlawe.com/apps/si/windows/assetList.txt"))) {
						while (!reader.EndOfStream) {
							string file = Path.Combine(directory, reader.ReadLine());
							if (!File.Exists(file) || _forceRedownload) {
								missingFiles.Add(file);
							} else {
								//string fileName = Path.GetFileName(file);
								//if (client.OpenRead(file).GetHashCode() != client.OpenRead(@"http://www.sebastianlawe.com/apps/si/windows/" + fileName).GetHashCode()) {
								//  missingFiles.Add(file);
								//}
							}
						}
					}
				}
			} catch (WebException) {
			}
			return missingFiles;
		}
		private static bool DownloadFiles(List<string> files, string uri, string directory) {
			try {
				WebClient client = new WebClient();
				if (files.Count > 0) {
					if (!Directory.Exists(directory)) {
						Directory.CreateDirectory(directory);
					}
					foreach (string file in files) {
						string fileName = Path.GetFileName(file);
						Stream webDownload = client.OpenRead(uri + fileName);
						using (FileStream stream = new FileStream(Path.Combine(directory, file), FileMode.Create, FileAccess.Write)) {
							webDownload.CopyTo(stream);
						}
					}
				}
				try {
					client.OpenRead(string.Format(@"http://www.sebastianlawe.com/apps/si/tracker.aspx?version=" + Application.ProductVersion + "&os=" + Environment.OSVersion + "&ram=" + Environment.SystemPageSize + "&cpu=" + Environment.ProcessorCount + ""));
				} catch (WebException) {
				}
				return true;
			} catch (WebException) {
				MessageBox.Show("Failed to download assets. An internet connection is required for first time use, or when files are missing.");
				return false;
			}
		}
		public static void CreateShortcut(string path, string target, string arguments) {
			// Check if link path ends with LNK or URL
			string extension = Path.GetExtension(path).ToUpper();
			if (extension != ".LNK" && extension != ".URL") {
				throw new ArgumentException("The path of the shortcut must have the extension .lnk or .url.");
			}

			// Get temporary file name with correct extension
			_scriptTempFilename = Path.GetTempFileName();
			File.Move(_scriptTempFilename, _scriptTempFilename += ".vbs");

			// Generate script and write it in the temporary file
			File.WriteAllText(_scriptTempFilename, String.Format(@"Dim WSHShell
      Set WSHShell = WScript.CreateObject({0}WScript.Shell{0})
      Dim Shortcut
      Set Shortcut = WSHShell.CreateShortcut({0}{1}{0})
      Shortcut.TargetPath = {0}{2}{0}
      Shortcut.WorkingDirectory = {0}{3}{0}
      Shortcut.Arguments = {0}{4}{0}
      Shortcut.Save",
			"\"", path, target, Path.GetDirectoryName(target), arguments),
			Encoding.Unicode);

			// Run the script and delete it after it has finished
			Process process = new Process();
			process.StartInfo.FileName = _scriptTempFilename;
			process.Start();
			process.WaitForExit();
			File.Delete(_scriptTempFilename);
		}
	}
}
