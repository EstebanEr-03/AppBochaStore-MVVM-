namespace BochaStoreProyecto.Maui.Views.Proovedor;

using BochaStoreProyecto.Maui.Services;
using Proovedor = BochaStoreProyecto.Maui.Models.Proovedor	;

public partial class NuevoProovedor : ContentPage
{
    private Proovedor _proovedor;
    private readonly APIService _APIService;

    public NuevoProovedor(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;

    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _proovedor = BindingContext as Proovedor;
        if (_proovedor != null)
        {
            EntryNombre.Text = _proovedor.nombreProovedor;
            EntryprecioImportacion.Text = _proovedor.precioImportacion.ToString();
            EntryDuracionContrato.Text = _proovedor.duracionContrato.ToString();

        }
    }

    private async void OnClickGuardarNuevoProducto(object sender, EventArgs e)
    {
        if (_proovedor != null)
        {

            _proovedor.nombreProovedor = EntryNombre.Text;
            _proovedor.duracionContrato = Int32.Parse(EntryDuracionContrato.Text);
            _proovedor.precioImportacion = double.Parse(EntryprecioImportacion.Text);

            await _APIService.PutProovedor(_proovedor.idProovedor, _proovedor);

        }
        else
        {
            int id = Utils.Utils.ProovedoresList.Count + 1;

            Proovedor proovedor = new Proovedor
            {
                idProovedor = 0,//posible error
                nombreProovedor = EntryNombre.Text,
                duracionContrato = Int32.Parse(EntryDuracionContrato.Text),
                precioImportacion = double.Parse(EntryprecioImportacion.Text),
            };
            //Utils.Utils.ProductosList.Add(producto);
            await _APIService.PostProovedor(proovedor);
        }
        await Navigation.PopAsync();
    }
}