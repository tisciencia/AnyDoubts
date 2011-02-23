using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnyDoubts.Infra.SimpleMail.Email
{
    public interface EmailBuilder
    {
	    EmailBuilder From(string address);

	    EmailBuilder To(params string[] addresses);

	    EmailBuilder Cc(params string[] addresses);

	    EmailBuilder Bcc(params string[] addresses);

	    EmailBuilder WithSubject(string subject);

	    EmailBuilder WithBody(string body);
	
	    EmailBuilder WithAttachment(params string[] attachments);

	    void Send();
    }
}
