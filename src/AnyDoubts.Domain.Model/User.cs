using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AnyDoubts.Domain.Model
{
    public class User : EntityBase
    {
        [Required]
        [Display(Name = "User name")]
        public string Username { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        [Email(ErrorMessage = "Not a valid email.")]
        public string Email { get; set; }

        [Required]        
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public User() { }

        public User(string username)
        {
            Username = username;
        }

        public User(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }

        public override int GetHashCode()
        {
            return Username.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}", Username);
        }

        #region Validation
        public class EmailAttribute : RegularExpressionAttribute
        {
            public EmailAttribute() :
                base(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$") { }
        }
        #endregion
    }

    public class UserSingUp : User
    {
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public UserSingUp()
        { 
        }
    }

    public class UserSignIn
    {
        [Required]
        [Display(Name = "User name")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public UserSignIn()
        {
        }
    }
}
