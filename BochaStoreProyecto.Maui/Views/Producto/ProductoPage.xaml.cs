namespace BochaStoreProyecto.Maui.Views.Producto;

using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using BochaStoreProyecto.Maui.Services;
using System.Collections.ObjectModel;

using Producto = BochaStoreProyecto.Maui.Models.Producto;

public partial class ProductoPage : ContentPage
{
    ObservableCollection<Producto> products;
    private readonly APIService _APIService;
    public ProductoPage(APIService apiservice)
    {
        InitializeComponent();
        _APIService = apiservice;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        string username = "BOCHASTORE";
        Username.Text = username;
        List<Producto> ListaProducts = await _APIService.GetProductos();
        products = new ObservableCollection<Producto>(ListaProducts);
        listaProductos.ItemsSource = products;

    }

    private async void OnClickNuevoProducto(object sender, EventArgs e)
    {
        var toast = Toast.Make("On Click Boton Nuevo Producto", ToastDuration.Short, 14);
        await toast.Show();
        await Navigation.PushAsync(new NuevoProducto(_APIService));

        //await Navigation.PushAsync(new NuevoProducto());
    }

    private async void OnClickShowDetails_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var toast = CommunityToolkit.Maui.Alerts.Toast.Make("Click en ver producto", ToastDuration.Short, 14);

        await toast.Show();
        Producto producto = e.SelectedItem as Producto;
        await Navigation.PushAsync(new DetailsProducto(_APIService)
        {
            BindingContext = producto,
        });
    }
}