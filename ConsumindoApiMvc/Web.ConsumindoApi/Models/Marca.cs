using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.ConsumindoApi.Models
{
    public class Marca
    {
        #region Propriedades 

        public int Id { get; set; }
        public String Nome { get; set; }

        #endregion

        #region Relacionamentos

        public ICollection<Produto> Produtos { get; set; }

        #endregion
    }
}