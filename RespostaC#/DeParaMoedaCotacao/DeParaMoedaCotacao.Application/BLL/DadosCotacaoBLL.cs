
using DeParaMoedaCotacao.Application.DAL;
using DeParaMoedaCotacao.Application.Models;
using System.Collections.Generic;

namespace DeParaMoedaCotacao.Application.BLL
{
    public class DadosCotacaoBLL
    {
        private DadosCotacaoDAL _dcDAL;
        public DadosCotacaoBLL()
        {
            _dcDAL = new DadosCotacaoDAL();
        }
        
        public List<DadosCotacao> GetDadosCotacao(Item item)
        {
            return _dcDAL.GetDadosCotacao(item);
        }
    }
}
