using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Controllers.DAO.Classes;
using WebAPI.Controllers.DAO.Interface;

namespace WebAPI.Controllers.DAO.Factory
{
    public abstract class AbstractFactory
    {
        public static class Factory
        {
            public static IPersonagemDAO GetPersonagemDAO()
            {
                return PersonagemDAO.GetInstance();
            }

            public static IPlanetaDAO GetPlanetaDAO()
            {
                return PlanetaDAO.GetInstance();
            }

            public static IRacaDAO GetRacaDAO()
            {
                return RacaDAO.GetInstance();
            }
        }
    }
}