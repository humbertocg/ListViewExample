using System;
using Ejemplo.ViewModels;
using Xamarin.Forms;

namespace Ejemplo
{
    public class BaseContentPage: ContentPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var vm = BindingContext as BaseViewModel;
            vm?.OnViewAppearing();
        }

        protected override void OnDisappearing()
        {
            var vm = BindingContext as BaseViewModel;
            vm?.OnViewDissappearing();
            base.OnDisappearing();
        }
    }
}
