using BochaStoreProyecto.Maui.Models;
using BochaStoreProyecto.Maui.Services;
using BochaStoreProyecto.Maui.Views.Producto;
using CommunityToolkit.Maui.Alerts;

namespace BochaStoreProyecto.Maui.Views;

public partial class LoginPage : ContentPage
{
    private readonly APIService _APIService;
    public LoginPage(APIService apiservice)
    {
        InitializeComponent();
        _APIService = apiservice;
    }

    private  async void Login_Clicked(object sender, EventArgs e)
    {
        string userName = txtUserName.Text;
        string password = txtPassword.Text;
        if(userName == null || password == null)
        {
            await DisplayAlert("Peligro", "Ingrese el usuario y la contraseña", "Ok");
            return;
        }
        Usuario usuario = await _APIService.Login(userName, password);
        if (usuario != null) 
        {
            await Navigation.PushAsync(new NavigationPage(new FlyoutPageT(_APIService)));
        }
        else
        {
            await DisplayAlert("Warning", "Username or Password is incorrect", "Ok");
        }
    }
}