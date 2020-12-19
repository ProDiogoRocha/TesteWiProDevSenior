using DeParaMoedaCotacao.Application.BLL;
using DeParaMoedaCotacao.Application.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;

namespace DeParaMoedaCotacao.Application
{
    class Program
    {
        public static string ApiBaseUrl = "https://localhost:44358/api/itemfila/getitemfila";
        static void Main(string[] args)
        {
            var laco = true;

            while (laco)
            {
                Console.WriteLine("Iniciando execução da rotina!");
                
                Item item = null;

                var stopwatch = new Stopwatch();
                stopwatch.Start();

                Console.WriteLine("Consultando existência de novos itens na Fila");

                item = RequestResponseItemFila();
                if(item == null)
                {
                    Console.WriteLine("A Fila está vazia!");
                }
                else
                {
                    Console.WriteLine("Buscando dados de Moeda!");
                    IList<DadosMoeda> dadosMoedaLista = new DadosMoedaBLL().GetDadosMoeda(item);

                    Console.WriteLine("Buscando dados de Cotação!");
                    IList<DadosCotacao> dadoslista = new DadosCotacaoBLL().GetDadosCotacao(item);

                    Console.WriteLine("Montando arquivo de resposta");
                    stopwatch.Stop();
                    new DeParaBLL().MontarListaDePara(dadosMoedaLista, dadoslista);

                    Console.WriteLine("Arquivo salvo no diretório FILEBASE");
                    Console.WriteLine($@"Tempo total da execução: {stopwatch.Elapsed}");
                }
                Thread.Sleep(TimeSpan.FromMinutes(2));
            }

            Console.ReadKey();
        }

        static Item RequestResponseItemFila()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiBaseUrl);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            var streamReader = new StreamReader(httpResponse.GetResponseStream());

            return JsonConvert.DeserializeObject<Item>(streamReader.ReadToEnd());
        }
    }
}
