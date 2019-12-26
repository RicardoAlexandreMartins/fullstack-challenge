using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Controllers.BL.Classes;
using WebAPI.Controllers.BL.Interfaces;

namespace WebAPI.Controllers.BL.Factory
{
    public abstract class AbstractFactory
    {
        public static class Factory
        {
            public static IPersonagemBL GetPersonagemBL()
            {
                return PersonagemBL.GetInstance();
            }
        }
    }
}