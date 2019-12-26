using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.Interfaces
{
    public interface IPersonagemDTO
    {
        int Id { get; set; }
        IRacaDTO Raca { get; set; }
        string Nome { get; set; }
        IPlanetaDTO Planeta { get; set; }
    }
}