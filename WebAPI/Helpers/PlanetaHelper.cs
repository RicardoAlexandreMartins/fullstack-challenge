using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models.Factory;
using WebAPI.Models.Interfaces;

namespace WebAPI.Helpers
{
    public static class PlanetaHelper
    {
        public static List<IPlanetaDTO> HandlePlaneta(JObject json)
        {
            List<IPlanetaDTO> planetas = new List<IPlanetaDTO>();

            foreach (var p in json["results"])
            {
                IPlanetaDTO planeta = AbstractFactory.Factory.GetPlanetaDTO();
                planeta.Nome = p["name"].ToString();
                planeta.Id = Convert.ToInt32(p["url"].ToString().Replace("https://swapi.co/api/planets/", "").Substring(0, 1));

                planetas.Add(planeta);
            }


            return planetas;
        }
    }
}