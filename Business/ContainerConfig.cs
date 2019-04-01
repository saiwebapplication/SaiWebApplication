using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            //Register all business objects
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(Business)))
                .Where(dir => dir.Namespace.Contains("Utilities"))
                .As(interfs => interfs.GetInterfaces().FirstOrDefault(interf => interf.Name == "I" + interfs.Name));


            //Register all data objects
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(DataAccess)))
                .As(interfs => interfs.GetInterfaces().FirstOrDefault(interf => interf.Name == "I" + interfs.Name));

            return builder.Build();
        }
    }
}
