using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AnyDoubts.Infra.SimpleMail.Validation
{
    public class EmailAddressValidator
    {
        public bool validate(string emailAddress)
        {
            string pattern = @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$";                             
            return (emailAddress != null || Regex.IsMatch(emailAddress, pattern));
        }
    }
}
