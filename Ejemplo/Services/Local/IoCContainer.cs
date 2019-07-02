using System;
using Core.ServiceConsumer;
using Microsoft.Extensions.DependencyInjection;

namespace Ejemplo.Services.Local
{
    public static class IoCContainer
    {
        public static ServiceProvider Container;

        public static void Configure ()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IServiceConsumer, ServiceConsumer>();
            Container = serviceCollection.BuildServiceProvider();
        }
    }
}
