using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Controllers.BL.Factory;
using WebAPI.Controllers.BL.Interfaces;
using WebAPI.Models.Interfaces;

namespace WebAPI.Controllers.api
{
    [RoutePrefix("api/personagem")]
    public class PersonagemController : ApiController
    {
        static readonly IPersonagemBL repositorio = AbstractFactory.Factory.GetPersonagemBL();


        [AcceptVerbs("GET")]
        [Route("consultar")]
        public IHttpActionResult GetAllPersonagens()
        {
            List<IPersonagemDTO> personagens = repositorio.GetAll();

            if (personagens.Count() == 0)
                return NotFound();
            else
                return Ok(personagens);
        }
    }
}
