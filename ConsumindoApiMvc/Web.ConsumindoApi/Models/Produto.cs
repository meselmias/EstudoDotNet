using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.ConsumindoApi.Models
{
    public class Produto
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public System.DateTime dataCadastro { get; set; }
        public string preco { get; set; }
    }
}