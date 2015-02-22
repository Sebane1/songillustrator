using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using ControlFactory;
using SongIllustrator;

namespace MediaPlayerModuleBase {
	public class MediaPlayerLoader {
		public static IMediaPlayer LoadMediaPlayer(IFactory factory, IFormView formView) {
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
				try {
					foreach (var type in assembly.GetTypes()) {
						if (typeof(IMediaPlayer).IsAssignableFrom(type)) {
							var moduleInstance = (IMediaPlayer) Activator.CreateInstance(type);
							if (moduleInstance.SupportedOS == os) {
								return moduleInstance;
							}
						}
					}
				} catch {
					return new WavPlayerControl(factory, formView);
				}
			}
			return new WavPlayerControl(factory, formView);
		}
	}
}
