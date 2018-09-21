using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.ConsumindoApiMVC.Models
{
    [Table("Marcas")]
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