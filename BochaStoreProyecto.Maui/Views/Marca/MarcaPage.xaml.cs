namespace BochaStoreProyecto.Maui.Views.Marca;

using BochaStoreProyecto.Maui.Services;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Collections.ObjectModel;
using Marca = BochaStoreProyecto.Maui.Models.Marca;

public partial class MarcaPage : ContentPage
{
    ObservableCollection<Marca> marcas;
    private readonly APIService _APIService;
    public MarcaPage(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;

    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        string username = "BOCHASTORE";
        Username.Text = username;
        List<Marca> ListaMarcas = await _APIService.GetMarca();
        marcas = new ObservableCollection<Marca>(ListaMarcas);
        listaMarcas.ItemsSource = marcas;

    }

    private async void OnClickNuevaMarca(object sender, EventArgs e)
    {
        var toast = Toast.Make("On Click Boton Nueva marca", ToastDuration.Short, 14);
        await toast.Show();
        await Navigation.PushAsync(new NuevaMarca(_APIService));
    }
    private async void listaMarcas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var toast = CommunityToolkit.Maui.Alerts.Toast.Make("Click en ver marca", ToastDuration.Short, 14);

        await toast.Show();
        Marca marca = e.SelectedItem as Marca;
        await Navigation.PushAsync(new DetailsMarca(_APIService)
        {
            BindingContext = marca,
        });
    }
}