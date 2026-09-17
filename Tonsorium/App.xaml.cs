using Microsoft.Extensions.DependencyInjection;

namespace Tonsorium
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            InitializeComponent();
            MainPage = new NavigationPage(new Views.BoasVindas());
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);
            window.Width = 400;
            window.Height = 750;
            return window;
        }
    }
}