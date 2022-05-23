using Ninject.Modules;
using Services.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ApplicationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUSDRate>().To<USDRate>();
        }
    }
}
