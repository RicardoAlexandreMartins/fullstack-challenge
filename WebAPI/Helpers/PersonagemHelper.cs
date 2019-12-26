using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models.Factory;
using WebAPI.Models.Interfaces;

namespace WebAPI.Helpers
{
    public static class PersonagemHelper
    {
        public static List<IPersonagemDTO> HandlePersonagem(JObject json)
        {
            List<IPersonagemDTO> personagens = new List<IPersonagemDTO>();

            foreach(var p in json["results"])
            {
                IPersonagemDTO personagem = AbstractFactory.Factory.GetPersonagemDTO();
                personagem.Nome = p["name"].ToString();
                personagem.Id = Convert.ToInt32(p["url"].ToString().Replace("https://swapi.co/api/people/", "").Substring(0, 1));

                try
                {
                    personagem.Planeta = AbstractFactory.Factory.GetPlanetaDTO();
                    personagem.Planeta.Id = Convert.ToInt32(p["homeworld"].ToString().Replace("https://swapi.co/api/planets/", "").Substring(0, 1));
                }
                catch(Exception)
                {

                }

                try
                {
                    personagem.Raca = AbstractFactory.Factory.GetRacaDTO();
                    personagem.Raca.Id = Convert.ToInt32(p["species"][0].ToString().Replace("https://swapi.co/api/species/", "").Substring(0, 1));
                }
                catch(Exception)
                {

                }

                personagens.Add(personagem);
            }


            return personagens;
        }

        public static List<IPersonagemDTO> HandlePersonagem(JArray json)
        {
            List<IPersonagemDTO> personagens = new List<IPersonagemDTO>();

            foreach (var p in json)
            {
                IPersonagemDTO personagem = AbstractFactory.Factory.GetPersonagemDTO();
                personagem.Nome = p["Nome"].ToString();
                personagem.Id = Convert.ToInt32(p["Id"]);

                try
                {
                    personagem.Planeta = AbstractFactory.Factory.GetPlanetaDTO();
                    personagem.Planeta.Id = Convert.ToInt32(p["Planeta"]["Id"]);
                    personagem.Planeta.Nome = p["Planeta"]["Nome"].ToString();
                }
                catch (Exception)
                {

                }

                try
                {
                    personagem.Raca = AbstractFactory.Factory.GetRacaDTO();
                    personagem.Raca.Id = Convert.ToInt32(p["Raca"]["Id"]);
                    personagem.Raca.Nome = p["Raca"]["Nome"].ToString();
                }
                catch (Exception)
                {

                }

                personagens.Add(personagem);
            }


            return personagens;
        }
    }
}