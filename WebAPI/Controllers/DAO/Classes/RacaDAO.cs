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
    public class RacaDAO : IRacaDAO
    {

        public static RacaDAO instance = null;
        private List<IRacaDTO> lista = new List<IRacaDTO>();

        private RacaDAO()
        {
        }

        public static RacaDAO GetInstance()
        {
            if (instance == null)
                instance = new RacaDAO();

            return instance;
        }

        private async Task RunAsync()
        {
            string url = ConfigurationManager.AppSettings["urlServicoRacas"];
            lista = new List<IRacaDTO>();
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
                        JObject deserialized = (JObject)JsonConvert.DeserializeObject(jsonString.Result);

                        tamanho = int.Parse(deserialized["count"].ToString());
                        url = deserialized["next"].ToString();

                        List<IRacaDTO> racas = RacaHelper.HandleRaca(deserialized);

                        lista.AddRange(racas);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public List<IRacaDTO> GetAll()
        {
            if (lista.Count() == 0)
                RunAsync().Wait();

            return lista;
        }

        public IRacaDTO FindById(int id)
        {
            if (lista.Count() == 0)
                RunAsync().Wait();

            return lista.Find(l => l.Id == id);
        }
    }
}