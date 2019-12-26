using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models.Classes;
using WebAPI.Models.Interfaces;

namespace WebAPI.Models.Factory
{
    public abstract class AbstractFactory
    {
        public static class Factory
        {
            public static IPersonagemDTO GetPersonagemDTO()
            {
                return new PersonagemDTO();
            }

            public static IPlanetaDTO GetPlanetaDTO()
            {
                return new PlanetaDTO();
            }

            public static IRacaDTO GetRacaDTO()
            {
                return new RacaDTO();
            }
        }
    }
}