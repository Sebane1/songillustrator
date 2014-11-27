using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using ControlFactory;

namespace SongIllustrator {
	public class FactoryLoader {
		public static IFactory LoadFactory() {
			var modulesPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
			foreach (var moduleFileName
				in Directory.GetFiles(modulesPath, "*.Factory.dll", SearchOption.TopDirectoryOnly)) {
				var assembly = Assembly.Load(AssemblyName.GetAssemblyName(moduleFileName));
				foreach (var type in assembly.GetTypes()) {
					if (typeof(IFactory).IsAssignableFrom(type)) {
						try {
							var moduleInstance = (IFactory) Activator.CreateInstance(type);
							return moduleInstance;
						} catch {
							return new DummyFactory();
						}
					}
				}
			}
			return new DummyFactory();
		}
	}
}
