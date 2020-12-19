using DeParaMoedaCotacao.Application.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DeParaMoedaCotacao.Application.DAL
{
    public class DadosMoedaDAL
    {
        private string path = "";
        public DadosMoedaDAL()
        {
            path = System.AppDomain.CurrentDomain.BaseDirectory.ToString().Replace("bin\\Debug\\", "FILEBASE\\DadosMoeda.csv");
        }

        public List<DadosMoeda> GetDadosMoeda(Item item)
        {
            List<DadosMoeda> listaMoeda = new List<DadosMoeda>();

            var lines = File.ReadAllLines(path).Select(c => c.Split(';')).ToList();

            for (var i = 0; i < lines.Count; i++)
            {
                if (i != 0)
                {
                    listaMoeda.Add(new DadosMoeda()
                    {
                        ID_MOEDA = lines[i][0],
                        DATA_REF = Convert.ToDateTime(lines[i][1]),
                    });
                }
            }

            return listaMoeda.Where(a => a.DATA_REF >= item.data_inicio && a.DATA_REF <= item.data_fim).Select(a => a).ToList();
        }
    }
}
