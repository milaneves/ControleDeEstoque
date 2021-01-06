using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleDeEstoque.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="informe o usuário")]
        [Display(Name ="Usuário")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "informe o usuário")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Lembrar Me")]
        public bool LembrarMe { get; set; }

    }
}