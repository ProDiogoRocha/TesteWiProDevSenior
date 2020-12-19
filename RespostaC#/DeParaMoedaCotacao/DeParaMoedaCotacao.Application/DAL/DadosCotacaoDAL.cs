using DeParaMoedaCotacao.Application.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DeParaMoedaCotacao.Application.DAL
{
    public class DadosCotacaoDAL
    {
        private string path = "";
        public DadosCotacaoDAL()
        {
            path = System.AppDomain.CurrentDomain.BaseDirectory.ToString().Replace("bin\\Debug\\", "FILEBASE\\DadosCotacao.csv");
        }

        public List<DadosCotacao> GetDadosCotacao(Item item)
        {
            List<DadosCotacao> listaDadosCotacao = new List<DadosCotacao>();

            var lines = File.ReadAllLines(path).Select(c => c.Split(';')).ToList();

            for(var i=0;i<lines.Count; i++)
            {
                if(i != 0)
                {
                    listaDadosCotacao.Add(new DadosCotacao()
                    {
                        vlr_cotacao = Convert.ToDecimal(lines[i][0]),
                        cod_cotacao = Convert.ToInt16(lines[i][1]),
                        dat_cotacao = Convert.ToDateTime(lines[i][2])
                    });
                }
            }

            return listaDadosCotacao;
        }
    }
}
