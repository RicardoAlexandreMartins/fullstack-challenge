using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models.Interfaces;

namespace WebAPI.Controllers.BL.Interfaces
{
    public interface IPersonagemBL
    {
        List<IPersonagemDTO> GetAll();
    }
}