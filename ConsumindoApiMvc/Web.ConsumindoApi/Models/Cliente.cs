using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.ConsumindoApi.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo {0} é requerido")]
        [MaxLength(50, ErrorMessage = "você está ultrapassando o maximo de 50 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo {0} é requerido")]
        [MaxLength(18, ErrorMessage = "você está ultrapassando o maximo de 18 caracteres")]
        public string Cnpj { get; set; }
        [Required(ErrorMessage = "Campo {0} é requerido")]
        [MaxLength(40, ErrorMessage = "você está ultrapassando o maximo de 40 caracteres")]
        public string Endereco { get; set; }
        [Required(ErrorMessage = "Campo {0} é requerido")]
        [MaxLength(40, ErrorMessage = "você está ultrapassando o maximo de 40 caracteres")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo {0} é requerido")]
        [MaxLength(11, ErrorMessage = "você está ultrapassando o maximo de 11 caracteres")]
        public string Telefone { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}