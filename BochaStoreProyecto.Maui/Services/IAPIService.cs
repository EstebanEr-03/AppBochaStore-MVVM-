using BochaStoreProyecto.Maui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BochaStoreProyecto.Maui.Services
{
    internal interface IAPIService
    {
        //Producto
        public Task<List<Producto>> GetProductos();

        public Task<Producto> GetProducto(int id);
        public Task<Producto> PostProducto(Producto producto);
        public Task<Producto> PutProducto(int IdProducto, Producto producto);
        public Task<Boolean> DeleteProducto(int IdProducto);


        //Proovedor
        public Task<List<Proovedor>> GetProovedor();

        public Task<Proovedor> GetProovedor(int id);
        public Task<Proovedor> PostProovedor(Proovedor proovedor);
        public Task<Proovedor> PutProovedor(int IdProovedor, Proovedor proovedor);
        public Task<Boolean> DeleteProovedor(int IdProovedor);

        //Marca

        public Task<List<Marca>> GetMarca();

        public Task<Marca> GetMarca(int id);
        public Task<Marca> PostMarca(Marca marca);
        public Task<Marca> PutMarca(int IdMarca, Marca marca);
        public Task<Boolean> DeleteMarca(int IdMarca);

        //Usuario
        public Task<List<Usuario>> GetUsuario();

        public Task<Usuario> GetUsuario(int id);
        public Task<Usuario> PostMarca(Usuario usuario);
        public Task<Usuario> Login(string userName, string password);

    }
}
