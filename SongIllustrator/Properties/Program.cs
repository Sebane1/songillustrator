using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Win32Factory.Wrappers;

namespace SongIllustrator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length > 0)
            {
                //Application.Run(new Form(args[0]));
				new MainForm(FactoryLoader.LoadFactory());
            }
            else {
				new MainForm(FactoryLoader.LoadFactory());
               //Application.Run();
            }
        }
    }
}
