using Domain.Interfaces;
using Infrastructure.LocaSMS;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendSMS
{
    static class Program
    {
        private static Container container;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Bootstrap();
            Application.Run(container.GetInstance<FrmMain>());
        }

        private static void Bootstrap()
        {
            container = new Container();

            container.Register<ILocaSMS, LocaSMS>();
            container.Register<IViaNett, ViaNett>();

            container.Verify();
        }
    }
}
