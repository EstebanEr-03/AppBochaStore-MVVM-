namespace BochaStoreProyecto.Maui.Views.Proovedor;

using BochaStoreProyecto.Maui.Services;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Collections.ObjectModel;
using Proovedor = BochaStoreProyecto.Maui.Models.Proovedor;

public partial class ProovedorPage : ContentPage
{
    ObservableCollection<Proovedor> proovedores;
    private readonly APIService _APIService;

    public ProovedorPage(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        string username = "BOCHASTORE";
        Username.Text = username;
        List<Proovedor> ListaProovedores = await _APIService.GetProovedor();
        proovedores = new ObservableCollection<Proovedor>(ListaProovedores);
        listaProveedores.ItemsSource = proovedores;

    }

    private async void OnClickNuevoProveedor(object sender, EventArgs e)
    {
        var toast = Toast.Make("On Click Boton Nuevo Producto", ToastDuration.Short, 14);
        await toast.Show();
        await Navigation.PushAsync(new NuevoProovedor(_APIService));
    }

    private async void OnClickShowDetails_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var toast = CommunityToolkit.Maui.Alerts.Toast.Make("Click en ver producto", ToastDuration.Short, 14);

        await toast.Show();
        Proovedor producto = e.SelectedItem as Proovedor;
        await Navigation.PushAsync(new DetailsProovedor(_APIService)
        {
            BindingContext = producto,
        });
    }
}