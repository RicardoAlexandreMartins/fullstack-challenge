using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models.Interfaces;

namespace WebAPI.Controllers.DAO.Interface
{
    public interface IPersonagemDAO
    {

        List<IPersonagemDTO> GetAll();
        IPersonagemDTO FindById(int id);
    }
}