using Crud.Infra;
using System;
using Crud.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();

            FormResolve.Wire(FormModule.Create());
            Application.Run(FormResolve.Resolve<FormMenu>());


        }
    }
}
