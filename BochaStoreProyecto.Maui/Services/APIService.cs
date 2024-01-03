using BochaStoreProyecto.Maui.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace BochaStoreProyecto.Maui.Services
{
    public class APIService
    {
        public static string _baseUrl;
        public HttpClient _httpClient;
        public APIService()
        {

            //_baseUrl = "https://apibochastore20231213042546.azurewebsites.net/";
            _baseUrl = "http://10.0.2.2:5149";
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseUrl);
        }
        // P R O D U C T O
        public async Task<bool> DeleteProducto(int IdProducto)
        {
            var response = await _httpClient.DeleteAsync($"/api/Producto/{IdProducto}");
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        }

        public async Task<Producto> GetProducto(int IdProducto)
        {
            var response = await _httpClient.GetAsync($"/api/Producto/{IdProducto}");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Producto producto = JsonConvert.DeserializeObject<Producto>(json_response);
                return producto;
            }
            return new Producto();
        }

        public async Task<List<Producto>> GetProductos()
        {
            var response = await _httpClient.GetAsync("/api/Producto");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(json_response);
                return productos;
            }
            return new List<Producto>();

        }

        public async Task<Producto> PostProducto(Producto producto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(producto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/Producto/", content);
            //Debug.WriteLine(content);
            //Debug.WriteLine(response);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Producto producto2 = JsonConvert.DeserializeObject<Producto>(json_response);
                return producto2;
            }
            return new Producto();
        }

        public async Task<Producto> PutProducto(int IdProducto, Producto producto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(producto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/Producto/{IdProducto}", content);
            Debug.WriteLine(content);
            Debug.WriteLine(response);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Producto producto2 = JsonConvert.DeserializeObject<Producto>(json_response);
                return producto2;
            }
            return new Producto();
        }

        public Usuario PostUsuario(Usuario usuario)
        {
            if (usuario != null)
            {
                if (usuario.username.Equals("Carlos") && usuario.password.Equals("1234"))
                {
                    return new Usuario
                    {
                        //SOLO REGRESA ID O TOKEN
                        idUsuario = 100,
                        username = usuario.username,
                        password = "",
                    };
                }

            }

            return null;
        }

        // P R O O V E D O R

        public async Task<bool> DeleteProovedor(int IdProovedor)
        {
            var response = await _httpClient.DeleteAsync($"/api/Proovedor/{IdProovedor}");
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        }

        public async Task<Proovedor> GetProovedor(int IdProovedor)
        {
            var response = await _httpClient.GetAsync($"/api/Proovedor/{IdProovedor}");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Proovedor proovedor = JsonConvert.DeserializeObject<Proovedor>(json_response);
                return proovedor;
            }
            return new Proovedor();
        }

        public async Task<List<Proovedor>> GetProovedor()
        {
            var response = await _httpClient.GetAsync("/api/Proovedor");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                List<Proovedor> proovedor = JsonConvert.DeserializeObject<List<Proovedor>>(json_response);
                return proovedor;
            }
            return new List<Proovedor>();

        }

        public async Task<Proovedor> PostProovedor(Proovedor proovedor)
        {
            var content = new StringContent(JsonConvert.SerializeObject(proovedor), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/Proovedor/", content);
            //Debug.WriteLine(content);
            //Debug.WriteLine(response);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Proovedor proovedor2 = JsonConvert.DeserializeObject<Proovedor>(json_response);
                return proovedor2;
            }
            return new Proovedor();
        }

        public async Task<Proovedor> PutProovedor(int IdProovedor, Proovedor proovedor)
        {
            var content = new StringContent(JsonConvert.SerializeObject(proovedor), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/Proovedor/{IdProovedor}", content);
            Debug.WriteLine(content);
            Debug.WriteLine(response);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Proovedor proovedor2 = JsonConvert.DeserializeObject<Proovedor>(json_response);
                return proovedor2;
            }
            return new Proovedor();
        }

        // M A R C A

        public async Task<bool> DeleteMarca(int IdMara)
        {
            var response = await _httpClient.DeleteAsync($"/api/Marca/{IdMara}");
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        }

        public async Task<Marca> GetMarca(int IdMarca)
        {
            var response = await _httpClient.GetAsync($"/api/Marca/{IdMarca}");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Marca marca = JsonConvert.DeserializeObject<Marca>(json_response);
                return marca;
            }
            return new Marca();
        }

        public async Task<List<Marca>> GetMarca()
        {
            var response = await _httpClient.GetAsync("/api/Marca");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                List<Marca> marca = JsonConvert.DeserializeObject<List<Marca>>(json_response);
                return marca;
            }
            return new List<Marca>();

        }

        public async Task<Marca> PostMarca(Marca marca)
        {
            var content = new StringContent(JsonConvert.SerializeObject(marca), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/Marca/", content);
            //Debug.WriteLine(content);
            //Debug.WriteLine(response);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Marca marca2 = JsonConvert.DeserializeObject<Marca>(json_response);
                return marca2;
            }
            return new Marca();
        }

        public async Task<Marca> PutMarca(int IdMarca, Marca marca)
        {
            var content = new StringContent(JsonConvert.SerializeObject(marca), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/Marca/{IdMarca}", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Marca marca2 = JsonConvert.DeserializeObject<Marca>(json_response);
                return marca2;
            }
            return new Marca();
        }
        // U S U A R I O

        public async Task<Usuario> Login(string userName, string password)
        {
            var userInfo = new List<Usuario>();

            // Reutiliza el HttpClient ya creado en la clase APIService
            var client = _httpClient;

            string url = $"/api/Usuarios/{userName}/{password}";

            // Utiliza el método GetAsync con la URL construida
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                userInfo = JsonConvert.DeserializeObject<List<Usuario>>(content);
                return userInfo.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        /*public async Task<Usuario> Login(string userName, string password)
        {
            var userInfo = new List<Usuario>();
            var client = new HttpClient();
            string url = "http://10.0.2.2:5149/api/Usuarios/"+userName+"/"+password;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                userInfo = JsonConvert.DeserializeObject<List<Usuario>>(content);
                return await Task.FromResult(userInfo.FirstOrDefault());
            }
            else 
            {
                return null;
            }
        }*/
    }
}
