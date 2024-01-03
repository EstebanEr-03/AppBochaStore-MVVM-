using BochaStoreProyecto.Maui.Services;
using BochaStoreProyecto.Maui.Views;
using BochaStoreProyecto.Maui.Views.Proovedor;

namespace BochaStoreProyecto.Maui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            APIService apiservice = new APIService();
            //MainPage = new NavigationPage(new LoginPage(apiservice));
            MainPage = new FlyoutPageT(apiservice);
            //MainPage = new NavigationPage(new ProovedorPage(apiservice));
        }
    }
}
