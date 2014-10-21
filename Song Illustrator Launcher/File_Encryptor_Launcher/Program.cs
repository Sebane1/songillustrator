using System;
using System.Windows.Forms;
namespace File_Encryptor_Launcher
{
	internal static class Program
	{
		private static string _recentFileLog = string.Concat(new string[]
		{
			Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
			"\\",
			Application.CompanyName,
			"\\",
			Application.ProductName,
			"\\SongIllustrator.exe"
		});
		public static string RecentFileLog
		{
			get
			{
				return Program._recentFileLog;
			}
			set
			{
				Program._recentFileLog = value;
			}
		}
        public static string Version {
            get {
                return "0.0.0.0";
            }
        }
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Launcher launcher = new Launcher();
			if (args.Length != 0)
			{
				launcher.CommandLine = args[0];
			}
			Application.Run(launcher);
		}
	}
}