using DeParaMoedaCotacao.Application.DAL;
using DeParaMoedaCotacao.Application.Models;
using System.Collections.Generic;

namespace DeParaMoedaCotacao.Application.BLL
{
    public class DadosMoedaBLL
    {
        private DadosMoedaDAL _dmDAL;
        public DadosMoedaBLL()
        {
            _dmDAL = new DadosMoedaDAL();
        }

        public List<DadosMoeda> GetDadosMoeda(Item item)
        {
            return _dmDAL.GetDadosMoeda(item);
        }
    }
}
