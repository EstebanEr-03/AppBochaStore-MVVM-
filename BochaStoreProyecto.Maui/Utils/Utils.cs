using BochaStoreProyecto.Maui.Models;
using BochaStoreProyecto.Maui.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BochaStoreProyecto.Maui.Utils
{
    public static class Utils
    {
        static public APIService apiservice = new APIService();

        public static List<Producto> ProductosList = new List<Producto>(){};
        public static List<Proovedor> ProovedoresList = new List<Proovedor>(){};
    }
}
