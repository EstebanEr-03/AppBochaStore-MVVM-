namespace BochaStoreProyecto.Maui.Views.Producto;
using CommunityToolkit.Maui.Core;
using BochaStoreProyecto.Maui.Services;
using Producto = BochaStoreProyecto.Maui.Models.Producto;
public partial class DetailsProducto : ContentPage
{
    private Producto _producto;
    private APIService _APIService;

    public DetailsProducto(APIService apiservice)
    {
        InitializeComponent();
        _APIService = apiservice;

    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _producto = BindingContext as Producto;
        Nombre.Text = _producto.nombreProducto;
        Descripcion.Text = _producto.descripcionProducto;
        Precio.Text = _producto.precio.ToString();
        Stock.Text = _producto.stock.ToString();
        idMarca.Text = _producto.idMarca.ToString();
        idProveedor.Text = _producto.idProovedor.ToString();
        fechaCreacion.Text = _producto.fechaCreacion.ToString();
    }
    private async void Borrar_Clicked(object sender, EventArgs e)
    {
        await _APIService.DeleteProducto(_producto.idProducto);
        await Navigation.PopAsync();

    }

    private async void Editar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NuevoProducto(_APIService)
        {
            BindingContext = _producto,
        });
    }
}