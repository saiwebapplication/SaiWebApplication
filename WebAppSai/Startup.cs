using Autofac;

namespace WebAppSai
{
    public static class Startup
    {
        private static bool alreadyConfigured = false;
        public static IContainer Container { get; set; }

        public static void Configure()
        {
            if (!alreadyConfigured)
            {
                Container = Business.ContainerConfig.Configure();
                alreadyConfigured = true;
            }
        }
    }
}