using BochaStoreProyecto.Maui.Services;
using BochaStoreProyecto.Maui.Views.Producto;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Producto = BochaStoreProyecto.Maui.Models.Producto;





namespace BochaStoreProyecto.Maui.ViewModels.ProductoViewModel
{
    public class ProductoPageViewModel : INotifyPropertyChanged
    {
        private readonly APIService _APIService;

        public ObservableCollection<Producto> Products { get; set; }
        public string Username { get; set; }

        public ICommand NuevoProductoCommand { get; set; }
        public ICommand VerProductoCommand { get; set; }

        public ProductoPageViewModel(APIService apiservice)
        {
            _APIService = apiservice;
            Products = new ObservableCollection<Producto>();
            NuevoProductoCommand = new Command(OnClickNuevoProducto);
            VerProductoCommand = new Command<Producto>(OnClickVerProducto);
        }

        public async void LoadData()
        {
            Username = "BOCHASTORE";
            OnPropertyChanged(nameof(Username));

            var ListaProducts = await _APIService.GetProductos();
            foreach (var producto in ListaProducts)
            {
                Products.Add(producto);
            }
            OnPropertyChanged(nameof(Products));
        }

        public async void OnClickNuevoProducto()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new NuevoProducto(_APIService));
        }

        public async void OnClickVerProducto(Producto producto)
        {

            await Application.Current.MainPage.Navigation.PushAsync(new Views.Producto.DetailsProducto(_APIService)
            {
                BindingContext = producto,
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
