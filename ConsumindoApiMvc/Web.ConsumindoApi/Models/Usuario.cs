using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.ConsumindoApi.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public String Nome { get; set; }

        [MaxLength(50)]
        public String Email { get; set; }

        [MaxLength(10)]
        public String Login { get; set; }
        [MaxLength(8)]
        [MinLength(6)]
        public String Senha { get; set; }
    }
}