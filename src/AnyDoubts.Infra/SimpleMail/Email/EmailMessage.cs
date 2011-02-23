using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnyDoubts.Infra.SimpleMail.Validation;
using AnyDoubts.Infra.SimpleMail.Transport;

namespace AnyDoubts.Infra.SimpleMail.Email
{
    public class EmailMessage : EmailBuilder, Email
    {
        private static EmailAddressValidator _EmailAddressValidator = new EmailAddressValidator();
        private static PostalService _PostalService = new PostalService();
        private string _FromAddress;
        private ICollection<string> _ToAddresses = new HashSet<String>();
        private ICollection<string> _CcAddresses = new HashSet<String>();
        private ICollection<string> _BccAddresses = new HashSet<String>();
        private ICollection<string> _Attachments = new HashSet<String>();
        private string _Subject;
        private string _Body;

        public void Send()
        {
            ValidateRequiredInfo();
            ValidateAddresses();
            SendMessage();
        }

        protected void ValidateRequiredInfo()
        {
            if (_FromAddress == null)
            {
                throw new ArgumentNullException("From address cannot be null");
            }
            if (_ToAddresses.Count == 0)
            {
                throw new ArgumentException("Email should have at least one to address");
            }
            if (_Subject == null)
            {
                throw new ArgumentNullException("Subject cannot be null");
            }
            if (_Body == null)
            {
                throw new ArgumentNullException("Body cannot be null");
            }
        }

        protected void SendMessage()
        {
            try
            {
                //postalService.Send(this);
            }
            catch (Exception e)
            {
                throw new Exception("Email could not be sent: " + e.Message, e);
            }
        }

        public EmailBuilder From(string address)
        {
            this._FromAddress = address;
            return this;
        }

        public EmailBuilder To(params string[] addresses)
        {
            for (int i = 0; i < addresses.Length; i++)
            {
                this._ToAddresses.Add(addresses[i]);
            }
            return this;
        }

        public EmailBuilder Cc(params string[] addresses)
        {
            for (int i = 0; i < addresses.Length; i++)
            {
                this._CcAddresses.Add(addresses[i]);
            }
            return this;
        }

        public EmailBuilder Bcc(params string[] addresses)
        {
            for (int i = 0; i < addresses.Length; i++)
            {
                this._BccAddresses.Add(addresses[i]);
            }
            return this;
        }

        public EmailBuilder WithSubject(string subject)
        {
            this._Subject = subject;
            return this;
        }

        public EmailBuilder WithBody(string body)
        {
            this._Body = body;
            return this;
        }

        public EmailBuilder WithAttachment(params string[] attachments)
        {
            for (int i = 0; i < attachments.Length; i++)
            {
                this._Attachments.Add(attachments[i]);
            }
            return this;
        }

        public string FromAddress()
        {
            return _FromAddress;
        }

        public ICollection<String> ToAddresses()
        {
            return _ToAddresses;
        }

        public ICollection<String> CcAddresses()
        {
            return _CcAddresses;
        }

        public ICollection<String> BccAddresses()
        {
            return _BccAddresses;
        }

        public ICollection<String> Attachments()
        {
            return _Attachments;
        }

        public string Subject()
        {
            return _Subject;
        }

        public string Body()
        {
            return _Body;
        }

        protected EmailBuilder ValidateAddresses()
        {
            if (!_EmailAddressValidator.validate(_FromAddress))
            {
                throw new ArgumentException("From: " + _FromAddress);
            }

            foreach (var email in _ToAddresses)
            {
                if (!_EmailAddressValidator.validate(email))
                {
                    throw new ArgumentException("To: " + email);
                }
            }

            return this;
        }
    }
}
