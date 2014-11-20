using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace SongIllustrator {
	public class MidiDriverLoader {
		private List<MidiDriver> _modules;

		#region Properties

		//**********************************************************************************************
		public IEnumerable<MidiDriver> Modules {
			get {
				foreach (var module in _modules) {
					yield return module;
				}
			}
		}

		#endregion Properties

		#region Methods

		//**********************************************************************************************
		internal void LoadModules() {
			_modules = new List<MidiDriver>();

			var modulesPath = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "Modules");
			foreach (var moduleFileName
				in Directory.GetFiles(modulesPath, "*.Module.dll", SearchOption.TopDirectoryOnly)) {

				var assembly = Assembly.Load(AssemblyName.GetAssemblyName(moduleFileName));
				foreach (var type in assembly.GetTypes()) {
					if (typeof(MidiDriver).IsAssignableFrom(type)) {
						var moduleInstance = (MidiDriver) Activator.CreateInstance(type, this);

						_modules.Add(moduleInstance);
					}
				}
			}
		}

		//**********************************************************************************************
		public static MidiDriver LoadMIDIDriver(string name) {
			MidiDriver.OperatingSystem os = MidiDriver.OperatingSystem.None;
			switch (Environment.OSVersion.Platform) {
				case PlatformID.Win32Windows:
					os = MidiDriver.OperatingSystem.Windows;
					break;
				case PlatformID.Win32NT:
					os = MidiDriver.OperatingSystem.Windows;
					break;
				case PlatformID.Unix:
					os = MidiDriver.OperatingSystem.Linux;
					break;
				case PlatformID.MacOSX:
					os = MidiDriver.OperatingSystem.Mac;
					break;
			}
			var modulesPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
			foreach (var moduleFileName
				in Directory.GetFiles(modulesPath, "*.Driver.dll", SearchOption.TopDirectoryOnly)) {
				var assembly = Assembly.Load(AssemblyName.GetAssemblyName(moduleFileName));
				foreach (var type in assembly.GetTypes()) {
					if (typeof(MidiDriver).IsAssignableFrom(type)) {
						try {
							var moduleInstance = (MidiDriver) Activator.CreateInstance(type, name);
							if (moduleInstance.SupportedOS == os) {
								return moduleInstance;
							}
						} catch {
							return new DummyDriver();
						}
					}
				}
			}
			return new DummyDriver();
		}
		//**********************************************************************************************
		internal void InitializeModules() {
			foreach (var module in _modules) {

			}
		}

		#endregion Methods

	}
}
