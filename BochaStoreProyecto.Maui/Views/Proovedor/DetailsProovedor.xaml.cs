namespace BochaStoreProyecto.Maui.Views.Proovedor;

using CommunityToolkit.Maui.Core;
using BochaStoreProyecto.Maui.Services;
using Proovedor = BochaStoreProyecto.Maui.Models.Proovedor;

public partial class DetailsProovedor : ContentPage
{
    private Proovedor _proovedor;
    private APIService _APIService;
    public DetailsProovedor(APIService apiservice)
	{   
		InitializeComponent();
        _APIService = apiservice;

    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _proovedor = BindingContext as Proovedor;
        Nombre.Text = _proovedor.nombreProovedor;
        PrecioImportacion.Text = _proovedor.precioImportacion.ToString();
        duracionContrato.Text = _proovedor.duracionContrato.ToString();
    }

    private async void Borrar_Clicked(object sender, EventArgs e)
    {
        await _APIService.DeleteProovedor(_proovedor.idProovedor);
        await Navigation.PopAsync();
    }

    private async void Editar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NuevoProovedor(_APIService)
        {
            BindingContext = _proovedor,
        });
    }
}