using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.Web.Pipeline;
using StructureMap.Pipeline;
using E.AppServices.Interface;
using E.AppServices;

namespace E.Initializer
{
    public class RegistrationServices : Registry
    {
        public RegistrationServices()
        {
            For<IImageServices>().LifecycleIs<HttpContextLifecycle>().Use<ImageServices>();
        }
    }
}
