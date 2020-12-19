using Dapper;
using DeParaMoedaCotacao.Application.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace DeParaMoedaCotacao.Application.DAL
{
    public class DeParaDAL
    {
        private string path = "";
        private SqlConnection _conexaoBD;
        
        public DeParaDAL(SqlConnection sqlConnection)
        {
            path = System.AppDomain.CurrentDomain.BaseDirectory.ToString().Replace("bin\\Debug\\", "FILEBASE\\");
            _conexaoBD = sqlConnection;
        }

        public int GetDeParaPorMoeda(string IdMoeda)
        {
            int codCotacao = 0;
            try
            {
                codCotacao = _conexaoBD.Query<int>($@"SELECT COD_COTACAO FROM DePara WHERE ID_MOEDA = '{IdMoeda}'").FirstOrDefault();
                
                return codCotacao;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void SalvarDePara(StringBuilder sb)
        {
            var dtn = DateTime.Now;
            path = path + "Resultado_" + dtn.Year.ToString() + dtn.Month.ToString() + dtn.Day.ToString() + "_" + dtn.Hour.ToString() + dtn.Minute.ToString() + dtn.Second.ToString() + ".csv";
            File.WriteAllText(path, sb.ToString());
        }

        private List<TabelaDePara> ListaDePara()
        {
            List<TabelaDePara> TDP = new List<TabelaDePara>();

            TDP.Add(new TabelaDePara("AFN",	66));
            TDP.Add(new TabelaDePara("ALL",	49));
            TDP.Add(new TabelaDePara("ANG",	33));
            TDP.Add(new TabelaDePara("ARS",	3 ));
            TDP.Add(new TabelaDePara("AWG",	6 ));
            TDP.Add(new TabelaDePara("BOB",	56));
            TDP.Add(new TabelaDePara("BYN",	64));
            TDP.Add(new TabelaDePara("CAD",	25));
            TDP.Add(new TabelaDePara("CDF",	58));
            TDP.Add(new TabelaDePara("CLP",	16));
            TDP.Add(new TabelaDePara("COP", 37));
            TDP.Add(new TabelaDePara("CRC",	52));
            TDP.Add(new TabelaDePara("CUP",	8 )); 
            TDP.Add(new TabelaDePara("CVE",	51));
            TDP.Add(new TabelaDePara("CZK", 29));
            TDP.Add(new TabelaDePara("DJF",	36));
            TDP.Add(new TabelaDePara("DZD",	54));
            TDP.Add(new TabelaDePara("EGP",	12));
            TDP.Add(new TabelaDePara("EUR", 20));
            TDP.Add(new TabelaDePara("FJD",	38));
            TDP.Add(new TabelaDePara("GBP", 22)); 
            TDP.Add(new TabelaDePara("GEL",	48));
            TDP.Add(new TabelaDePara("GIP", 18));
            TDP.Add(new TabelaDePara("HTG",	63));
            TDP.Add(new TabelaDePara("ILS", 40));
            TDP.Add(new TabelaDePara("IRR",	17));
            TDP.Add(new TabelaDePara("ISK", 11));
            TDP.Add(new TabelaDePara("JPY",	9 )); 
            TDP.Add(new TabelaDePara("KES", 21));
            TDP.Add(new TabelaDePara("KMF",	19));
            TDP.Add(new TabelaDePara("LBP", 42));
            TDP.Add(new TabelaDePara("LSL",	4 ));
            TDP.Add(new TabelaDePara("MGA",	35));
            TDP.Add(new TabelaDePara("MGB",	26)); 
            TDP.Add(new TabelaDePara("MMK", 69));
            TDP.Add(new TabelaDePara("MRO",	53));
            TDP.Add(new TabelaDePara("MRU",	15));
            TDP.Add(new TabelaDePara("MUR",	7 ));
            TDP.Add(new TabelaDePara("MXN", 41));
            TDP.Add(new TabelaDePara("MZN",	43));
            TDP.Add(new TabelaDePara("NIO", 23));
            TDP.Add(new TabelaDePara("NOK",	62));
            TDP.Add(new TabelaDePara("OMR",	34));
            TDP.Add(new TabelaDePara("PEN",	45));
            TDP.Add(new TabelaDePara("PGK",	2 ));
            TDP.Add(new TabelaDePara("PHP",	24));
            TDP.Add(new TabelaDePara("RON", 5 ));
            TDP.Add(new TabelaDePara("SAR",	44));
            TDP.Add(new TabelaDePara("SBD",	32));
            TDP.Add(new TabelaDePara("SGD",	70));
            TDP.Add(new TabelaDePara("SLL", 10));
            TDP.Add(new TabelaDePara("SOS",	61));
            TDP.Add(new TabelaDePara("SSP", 47));

            return TDP;
        }
    }
}
