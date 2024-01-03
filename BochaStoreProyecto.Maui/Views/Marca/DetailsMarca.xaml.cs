namespace BochaStoreProyecto.Maui.Views.Marca;

using BochaStoreProyecto.Maui.Services;
using Marca = BochaStoreProyecto.Maui.Models.Marca;

public partial class DetailsMarca : ContentPage
{
    private Marca _marca;
    private APIService _APIService;
    public DetailsMarca(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;

    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _marca = BindingContext as Marca;
        Nombre.Text = _marca.nombreMarca;
        Id.Text = "Id: "+_marca.idMarca.ToString();
    }
    private async void Borrar_Clicked(object sender, EventArgs e)
    {
        await _APIService.DeleteMarca(_marca.idMarca);
        await Navigation.PopAsync();
    }

    private async void Editar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NuevaMarca(_APIService)
        {
            BindingContext = _marca,
        });
    }
}