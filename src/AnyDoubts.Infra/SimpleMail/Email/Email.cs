using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnyDoubts.Infra.SimpleMail.Email
{
    public interface Email
    {
        string FromAddress();

        ICollection<string> ToAddresses();

        ICollection<string> CcAddresses();

        ICollection<string> BccAddresses();

        ICollection<string> Attachments();

        string Subject();

        string Body();
    }
}
