using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LengaburuTraffic
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IConfigReader>().To<ConfigReader>();
        }
    }
}
