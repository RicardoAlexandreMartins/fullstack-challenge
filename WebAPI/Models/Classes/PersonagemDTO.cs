using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Helpers;
using WebAPI.Models.Interfaces;

namespace WebAPI.Models.Classes
{
    public class PersonagemDTO : IPersonagemDTO
    {
        
        public int Id { get; set; }

        [JsonConverter(typeof(ConcreteConverter<RacaDTO>))]
        public IRacaDTO Raca { get; set; }
        public string Nome { get; set; }
        [JsonConverter(typeof(ConcreteConverter<PlanetaDTO>))]
        public IPlanetaDTO Planeta { get; set; }

    }
}