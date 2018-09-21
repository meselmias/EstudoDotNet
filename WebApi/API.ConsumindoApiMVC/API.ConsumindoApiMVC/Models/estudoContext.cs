﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace API.ConsumindoApiMVC.Models
{
    public class estudoContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos{ get; set; }
        public DbSet<Marca> Marcas { get; set; }
    }
}