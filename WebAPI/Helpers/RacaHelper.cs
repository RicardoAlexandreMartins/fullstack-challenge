using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models.Factory;
using WebAPI.Models.Interfaces;

namespace WebAPI.Helpers
{
    public static class RacaHelper
    {
        public static List<IRacaDTO> HandleRaca(JObject json)
        {
            List<IRacaDTO> racas = new List<IRacaDTO>();

            foreach(var p in json["results"])
            {
                IRacaDTO raca = AbstractFactory.Factory.GetRacaDTO();
                raca.Nome = p["name"].ToString();
                raca.Id = Convert.ToInt32(p["url"].ToString().Replace("https://swapi.co/api/species/", "").Substring(0, 1));

                racas.Add(raca);
            }


            return racas;
        }
    }
}