using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebAPI.Models.Classes;
using WebAPI.Models.Interfaces;

namespace WebAPI.Controllers
{
    public class PersonagemController : Controller
    {
        public ActionResult Index()
        {
            List<IPersonagemDTO> personagens = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44386/api/personagem/");
                //HTTP GET
                var responseTask = client.GetAsync("consultar");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    //var readTask = result.Content.ReadAsAsync<List<IPersonagemDTO>>();
                    var jsonString = result.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    JArray deserialized = (JArray)JsonConvert.DeserializeObject(jsonString.Result);
                    personagens = WebAPI.Helpers.PersonagemHelper.HandlePersonagem(deserialized);

                    //readTask.Wait();

                    //personagens = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    personagens = null;

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(personagens);
        }
    }
}