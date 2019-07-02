using System;
using Microsoft.Extensions.DependencyInjection;

namespace Ejemplo.Services.Local
{
    public interface IDependencyService
    {
        T Get<T>() where T : class;
    }

    public class LocalDependencyService : IDependencyService
    {
        public T Get<T>() where T : class
        {
            return IoCContainer.Container.GetRequiredService<T>();
        }
    }

}
