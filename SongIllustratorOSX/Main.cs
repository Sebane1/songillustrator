using System;
using System.Drawing;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;
using SongIllustrator;

namespace SongIllustratorOSX
{
	class MainClass
	{
		static void Main (string[] args)
		{
			NSApplication.Init ();
			//NSApplication.Main (args);
			MainForm form = new MainForm(FactoryLoader.LoadFactory());
		}
	}
}

