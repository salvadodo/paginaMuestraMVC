using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace consumoApiConsola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HttpClient ClientHttp = new HttpClient();
            ClientHttp.BaseAddress = new Uri("https://localhost:44325");
            var request = ClientHttp.GetAsync("api/Casas").Result;
            if(request.IsSuccessStatusCode)
            {
                var respuesta=request.Content.ReadAsStringAsync().Result;
                var listado=JsonConvert.DeserializeObject<List<Casas>>(respuesta);
                foreach(var item in listado)
                {
                    Console.WriteLine(item.Ubicacion);
                }
                Console.ReadLine();
            }
        }
    }
}
