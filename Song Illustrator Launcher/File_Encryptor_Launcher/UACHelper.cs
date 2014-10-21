using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;
namespace File_Encryptor_Launcher
{
	internal static class UACHelper
	{
		private const int BCM_FIRST = 5632;
		private const int BCM_SETSHIELD = 5644;
		internal static bool ProcessIsElevated
		{
			get
			{
				return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
			}
		}
		internal static void AddShieldToButton(Button button)
		{
			button.FlatStyle = FlatStyle.System;
			UACHelper.SendMessage(button.Handle, 5644u, 0u, 4294967295u);
		}
		internal static Process RestartProcessElevated(string arguments)
		{
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			processStartInfo.UseShellExecute = true;
			processStartInfo.WorkingDirectory = Environment.CurrentDirectory;
			processStartInfo.FileName = Application.ExecutablePath;
			processStartInfo.Arguments = arguments;
			processStartInfo.Verb = "runas";
			Process result;
			try
			{
				result = Process.Start(processStartInfo);
			}
			catch (Win32Exception)
			{
				result = null;
			}
			return result;
		}
		internal static void WaitForProcess(Process process)
		{
			if (process != null)
			{
				while (!process.HasExited)
				{
					Application.DoEvents();
				}
			}
		}
		[DllImport("user32")]
		private static extern uint SendMessage(IntPtr hWnd, uint msg, uint wParam, uint lParam);
	}
}
