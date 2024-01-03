namespace BochaStoreProyecto.Maui.Views.Marca;

using BochaStoreProyecto.Maui.Services;
using Marca = BochaStoreProyecto.Maui.Models.Marca;

public partial class NuevaMarca : ContentPage
{

    private Marca _marca;
    private readonly APIService _APIService;

    public NuevaMarca(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;

    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _marca = BindingContext as Marca;
        if (_marca != null)
        {
            EntryNombre.Text = _marca.nombreMarca;
        }
    }

    private async void OnClickGuardarNuevaMarca(object sender, EventArgs e)
    {

        if (_marca != null)
        {

            _marca.nombreMarca = EntryNombre.Text;

            await _APIService.PutMarca(_marca.idMarca,_marca);
        }
        else
        {
            int id = Utils.Utils.ProductosList.Count + 1;

            Marca marca = new Marca
            {
                idMarca = 0,
                nombreMarca = EntryNombre.Text,
            };
            //Utils.Utils.ProductosList.Add(producto);
            await _APIService.PostMarca(marca);
        }
        await Navigation.PopAsync();
    }
}