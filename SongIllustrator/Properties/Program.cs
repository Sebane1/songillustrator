using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
					Form form = new Form();
					BaseForm abstractionLayer = new BaseForm(new Win32Factory());
					form.Width = abstractionLayer.ControlWidth;
					form.Height = abstractionLayer.ControlHeight;
					foreach (Control control in abstractionLayer.FormControls) {
						if (control != null) {
							form.Controls.Add(control);
						}
					}
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length > 0)
            {
                //Application.Run(new Form(args[0]));
            }
            else {
                Application.Run(form);
            }
        }
    }
}
