using System;
using System.Threading.Tasks;
using Core.ServiceConsumer;
using Ejemplo.Services.Local;
using MvvmHelpers;
using Xamarin.Forms;

namespace Ejemplo.ViewModels
{
    public class BaseViewModel: MvvmHelpers.BaseViewModel
    {
        public INavigation Navigation { get; private set; }
        public IDependencyService DependencyServices { get; private set; }
        public IServiceConsumer ServiceConsumer { get; private set; }
        public Page CurrentPage { get; set; }
        public BaseViewModel(INavigation navigation): this(new LocalDependencyService())
        {
            Navigation = navigation;
        }

        public BaseViewModel(IDependencyService dependecyService)
        {
            DependencyServices = dependecyService;
            ServiceConsumer = DependencyServices.Get<IServiceConsumer>();
            
        }

        public virtual async Task OnViewAppearing()
        {
            CurrentPage = Application.Current.MainPage;
        }

        public virtual async Task OnViewDissappearing()
        {

        }
    }
}
