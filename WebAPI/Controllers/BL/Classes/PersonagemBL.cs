using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Controllers.BL.Interfaces;
using WebAPI.Controllers.DAO.Factory;
using WebAPI.Models.Interfaces;

namespace WebAPI.Controllers.BL.Classes
{
    public class PersonagemBL : IPersonagemBL
    {
        public static PersonagemBL instance = null;
       

        private PersonagemBL()
        {
        }

        public static PersonagemBL GetInstance()
        {
            if (instance == null)
                instance = new PersonagemBL();

            return instance;
        }


        public List<IPersonagemDTO> GetAll()
        {
            // Conecta ao serviço e busca todos os personagens
            List<IPersonagemDTO> personagens = AbstractFactory.Factory.GetPersonagemDAO().GetAll();

            // Percorre os personagens para preencher o planeta e a espécie
            foreach (IPersonagemDTO personagem in personagens)
            {
                try {
                    personagem.Planeta = AbstractFactory.Factory.GetPlanetaDAO().FindById(personagem.Planeta.Id);
                    personagem.Raca = AbstractFactory.Factory.GetRacaDAO().FindById(personagem.Raca.Id);
                }
                catch(Exception)
                {

                }
            }

            return personagens;
        }

        public List<IPersonagemDTO> FindByName(string name)
        {
            // Conecta ao serviço e busca todos os personagens
            List<IPersonagemDTO> personagens = AbstractFactory.Factory.GetPersonagemDAO().GetAll();

            // Percorre os personagens para preencher o planeta e a espécie
            foreach (IPersonagemDTO personagem in personagens)
            {
                // Como no enunciado só exibe o planeta, não vou buscar a raça
                personagem.Planeta = AbstractFactory.Factory.GetPlanetaDAO().FindById(personagem.Planeta.Id);
            }

            // Retona os personagens que contenham o nome iniciado com o texto informado
            return personagens.FindAll(p => p.Nome.ToUpper().StartsWith(name.ToUpper()));
        }

    }
}