using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using WebAPI.Controllers.DAO.Interface;
using WebAPI.Helpers;
using WebAPI.Models.Interfaces;

namespace WebAPI.Controllers.DAO.Classes
{
    public class PlanetaDAO : IPlanetaDAO
    {

        public static PlanetaDAO instance = null;
        private List<IPlanetaDTO> lista = new List<IPlanetaDTO>();

        private PlanetaDAO()
        {
        }

        public static PlanetaDAO GetInstance()
        {
            if (instance == null)
                instance = new PlanetaDAO();

            return instance;
        }

        private async Task RunAsync()
        {
            string url = ConfigurationManager.AppSettings["urlServicoPlanetas"];
            lista = new List<IPlanetaDTO>();
            int tamanho = 1;

            while (lista.Count() < tamanho)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new System.Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = client.GetAsync("");
                    if (response.Result.IsSuccessStatusCode)
                    {  //GET
                        var jsonString = response.Result.Content.ReadAsStringAsync();
                        jsonString.Wait();
                        JObject deserialized = (JObject)JsonConvert.DeserializeObject(jsonString.Result) ;

                        tamanho = int.Parse(deserialized["count"].ToString());
                        url = deserialized["next"].ToString();

                        List<IPlanetaDTO> planetas = PlanetaHelper.HandlePlaneta(deserialized);

                        lista.AddRange(planetas);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public List<IPlanetaDTO> GetAll()
        {
            if (lista.Count() == 0)
                RunAsync().Wait();

            return lista;
        }

        public IPlanetaDTO FindById(int id)
        {
            if (lista.Count() == 0)
                RunAsync().Wait();

            return lista.Find(l => l.Id == id);
        }
    }
}