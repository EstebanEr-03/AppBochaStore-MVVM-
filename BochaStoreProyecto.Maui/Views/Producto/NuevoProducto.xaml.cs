    namespace BochaStoreProyecto.Maui.Views.Producto;
using BochaStoreProyecto.Maui.Services;

using static System.Runtime.InteropServices.JavaScript.JSType;

using Producto = BochaStoreProyecto.Maui.Models.Producto;

public partial class NuevoProducto : ContentPage
{
    private Producto _producto;
    private readonly APIService _APIService;
    public NuevoProducto(APIService apiservice)
    {
        InitializeComponent();
        _APIService = apiservice;

    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _producto = BindingContext as Producto;
        if (_producto != null)
        {
            EntryNombre.Text = _producto.nombreProducto;
            EntryDescripcion.Text = _producto.descripcionProducto;
            EntryPrecio.Text = _producto.precio.ToString();
            Entrystock.Text = _producto.stock.ToString();
            EntryidProovedor.Text = _producto.idProovedor.ToString();
            EntryidMarca.Text = _producto.idMarca.ToString();
            EntryfechaCreacion.Text = _producto.fechaCreacion.ToString();

        }
    }
    private async void OnClickGuardarNuevoProducto(object sender, EventArgs e)
    {

        if (_producto != null)
        {

            _producto.nombreProducto = EntryNombre.Text;
            _producto.descripcionProducto = EntryDescripcion.Text;
            _producto.precio = double.Parse(EntryPrecio.Text);
            _producto.stock = Int32.Parse(Entrystock.Text);
            _producto.idProovedor = Int32.Parse(EntryidProovedor.Text);
            _producto.idMarca = Int32.Parse(EntryidMarca.Text);
            _producto.fechaCreacion = DateTime.Now;
            await _APIService.PutProducto(_producto.idProducto, _producto);
        }
        else
        {
            int id = Utils.Utils.ProductosList.Count + 1;

            Producto producto = new Producto
            {
                idProducto = 0,
                nombreProducto = EntryNombre.Text,
                descripcionProducto = EntryDescripcion.Text,
                precio = double.Parse(EntryPrecio.Text),
                stock = Int32.Parse(Entrystock.Text),
                idProovedor= Int32.Parse(EntryidProovedor.Text),
                idMarca= Int32.Parse(EntryidMarca.Text),
                fechaCreacion = DateTime.Now
            };
            //Utils.Utils.ProductosList.Add(producto);
            await _APIService.PostProducto(producto);
        }
        await Navigation.PopAsync();
    }
}