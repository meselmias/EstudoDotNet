using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.ConsumindoApiMVC.Models
{
    [Table("Produtos")]
    public class Produto
    {
        #region Propriedades

        public int Id { get; set; }
        public String  Nome { get; set; }
        public string Preco { get; set; }
        public int MarcaId { get; set; }

        #endregion

        #region Relacionamentos

        public virtual Marca Marca { get; set; }

        #endregion

    }
}