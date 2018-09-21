﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.ConsumindoApi.Models
{
    public class Produto
    {
        #region Propriedades

        public int Id { get; set; }
        public String Nome { get; set; }
        public string Preco { get; set; }
        public int MarcaId { get; set; }

        #endregion

        #region Relacionamentos

        public virtual Marca Marca { get; set; }

        #endregion
    }
}