using DeParaMoedaCotacao.Application.DAL;
using DeParaMoedaCotacao.Application.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DeParaMoedaCotacao.Application.BLL
{
    public class DeParaBLL
    {
        private DeParaDAL _dpDAL;
        private string strConnection = ConfigurationManager.ConnectionStrings["WiProItemFila"].ConnectionString;
        SqlConnection _sqlCon;

        public DeParaBLL()
        {
            _sqlCon = new SqlConnection(strConnection);
        }

        public void MontarListaDePara(IList<DadosMoeda> dadosMoedas, IList<DadosCotacao> dadosCotacoes)
        {
            List<DePara> deParas = new List<DePara>();

            if(dadosMoedas.Count != 0)
            {
                _sqlCon.Open();
                _dpDAL = new DeParaDAL(_sqlCon);

                foreach (var dadoMoeda in dadosMoedas)
                {
                    int id =_dpDAL.GetDeParaPorMoeda(dadoMoeda.ID_MOEDA);
                    decimal vlc = dadosCotacoes.Where(a => a.cod_cotacao == id).Select(a => a.vlr_cotacao).FirstOrDefault();

                    deParas.Add(new DePara()
                    {
                        ID_MOEDA = dadoMoeda.ID_MOEDA,
                        DATA_REF = dadoMoeda.DATA_REF,
                        VL_COTACAO = vlc
                    });
                }

                _sqlCon.Close();

                Exportar(deParas);
            }
            else
            {
                Console.WriteLine("Não Foram encontradas dados de Moedas correspondentes ao periodo informado!");
            }
        }


        private void Exportar(List<DePara> deParas)
        {

            List<object> listaDePara = deParas.ToList<object>();

            listaDePara.Insert(0, new string[3] { "ID_MOEDA", "DATA_REF", "VL_COTACAO" });

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < deParas.Count; i++)
            {
                List<string> dePara = ConverterLista(deParas[i]);
                for (int j = 0; j < dePara.Count; j++)
                {
                    sb.Append(dePara[j] + ',');
                }

                sb.Append("\r\n");
            }

            _dpDAL.SalvarDePara(sb);
        }

        private List<string> ConverterLista(DePara DePara)
        {
            List<string> dePara = new List<string>();
            dePara.Add(DePara.ID_MOEDA.ToString());
            dePara.Add(DePara.DATA_REF.ToString());
            dePara.Add(DePara.VL_COTACAO.ToString());

            return dePara;
        }
    }
}
