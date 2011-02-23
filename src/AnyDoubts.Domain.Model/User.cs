using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnyDoubts.Domain.Model
{
    public class User : EntityBase
    {
        public string Username { get; set; }
        public string Email { get; set; }
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
    }   
}
