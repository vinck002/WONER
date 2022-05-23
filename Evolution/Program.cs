using Ninject;
using Services.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evolution
{
    static class Program 
    {
        public static  bool _SwichDemo= false;  // si esta falsa entrara a base de datos en vivo , pero no para Real Estate
        public static bool SwichDemo { get { return _SwichDemo; }  }

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //para uso de injeccion de dependencia
            //StandardKernel _Kernal = new StandardKernel();
            //_Kernal.Load(Assembly.GetExecutingAssembly());
            //IUSDRate _IUSDRate = _Kernal.Get<IUSDRate>();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new Forms.Mainmenu());



        }
    }
}
