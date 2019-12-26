using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models.Interfaces;

namespace WebAPI.Models.Classes
{
    public class RacaDTO : IRacaDTO
    {
        private int id;
        private string nome;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
    }
}