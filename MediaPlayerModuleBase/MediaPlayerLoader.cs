using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace MediaPlayerModuleBase {
	public class MediaPlayerLoader {
		public static MediaPlayer LoadMediaPlayer(string name) {
			OperatingSystem os = OperatingSystem.None;
			switch (Environment.OSVersion.Platform) {
				case PlatformID.Win32Windows:
					os = OperatingSystem.Windows;
					break;
				case PlatformID.Win32NT:
					os = OperatingSystem.Windows;
					break;
				case PlatformID.Unix:
					os = OperatingSystem.Linux;
					break;
				case PlatformID.MacOSX:
					os = OperatingSystem.Mac;
					break;
			}
			var modulesPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
			foreach (var moduleFileName
				in Directory.GetFiles(modulesPath, "*.Player.dll", SearchOption.TopDirectoryOnly)) {
				var assembly = Assembly.Load(AssemblyName.GetAssemblyName(moduleFileName));
				foreach (var type in assembly.GetTypes()) {
					if (typeof(MediaPlayer).IsAssignableFrom(type)) {
						try {
							var moduleInstance = (MediaPlayer) Activator.CreateInstance(type);
							if (moduleInstance.SupportedOS == os) {
								return moduleInstance;
							}
						} catch {
							return new WavPlayerControl();
						}
					}
				}
			}
			return new WavPlayerControl();
		}
	}
}
