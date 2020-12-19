using System;

namespace DeParaMoedaCotacao.Application.Models
{
    public class DePara
    {
        public string ID_MOEDA { get; set; }
        public DateTime DATA_REF { get; set; }
        public decimal VL_COTACAO { get; set; }
    }
}
