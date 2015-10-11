using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;


namespace E.Initializer
{
    public static class Configuration
    {
        public static void Execute()
        {
            ObjectFactory.Configure(i =>
            {
                i.AddRegistry<RegistrationServices>();
            });
        }
    }
}
