namespace DeParaMoedaCotacao.Application.Models
{
    public class TabelaDePara
    {
        public TabelaDePara(string iD_MOEDA, int cOD_COTACAO)
        {
            ID_MOEDA = iD_MOEDA;
            COD_COTACAO = cOD_COTACAO;
        }

        public string ID_MOEDA { get; set; }
        public int COD_COTACAO { get; set; }
    }
}
