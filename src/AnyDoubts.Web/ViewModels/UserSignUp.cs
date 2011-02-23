using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AnyDoubts.Web.ViewModels
{
    public class UserSignUp
    {
        [Required]
        [Display(Name = "Nome de usuário")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Endereço de email")]
        [Email(ErrorMessage = "Não é um email válido.")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("Password", ErrorMessage = "A senha senha e a confirmação da senha não coincidem.")]
        public string ConfirmPassword { get; set; }

        #region Validation
        public class EmailAttribute : RegularExpressionAttribute
        {
            public EmailAttribute() :
                base(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$") { }
        }
        #endregion
    }
}