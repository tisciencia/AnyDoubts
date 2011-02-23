using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnyDoubts.Infra.SimpleMail.Transport;
using AnyDoubts.Infra.SimpleMail.Email;

namespace AnyDoubts.Tests.Infra
{
    public class SimpleMailTests
    {
        string[] yourAddress = new string[] { "tisciencia@gmail.com" };
        
        //EmailTransportConfiguration.configure("smtp.server.com", true, false, "username", "password");

        //EmailMessage mail = new EmailMessage()
        //    .From("demo@tisciencia.com")
        //    .To("tisciencia@gmail.com")
        //    .WithSubject("Fluent Mail API")
        //    .WithAttachment("file_name")
        //    .WithBody("Demo message")
        //    .Send();
    }
}
