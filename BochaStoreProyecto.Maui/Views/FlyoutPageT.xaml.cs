using BochaStoreProyecto.Maui.Models;
using BochaStoreProyecto.Maui.Services;

namespace BochaStoreProyecto.Maui.Views;

public partial class FlyoutPageT : FlyoutPage
{
    private readonly APIService _APIService;

    public FlyoutPageT(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;
        flyoutPage.collectionView.SelectionChanged += CollectionView_SelectionChanged;
    }
    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var item = e.CurrentSelection.FirstOrDefault() as FlyoutPageItem;
        if (item != null)
        {
            Page pageInstance = (Page)Activator.CreateInstance(item.TargetType, _APIService);
            Detail = new NavigationPage(pageInstance);
            IsPresented = false;
        }
    }
}