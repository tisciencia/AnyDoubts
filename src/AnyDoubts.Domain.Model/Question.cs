using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnyDoubts.Domain.Model
{
    public class Question : EntityBase
    {
        private const int MESSAGE_MAX_LENGTH = 255;
		public Guid ID { get; private set; }
		public string Message { get; private set; }
		public string Answer { get; set; }
		public User From { get; private set; }
        public User To { get; private set; }
		
		public bool IsAnswered
		{
			get { return !String.IsNullOrEmpty(Answer); }
		}

        public bool IsAnonym
        {
            get { return (From == null); }
        }
			
		private Question() { }
		
		public Question(User from, User to, string message)
		{
			if (to == null)
			    throw new ArgumentException("The parameter 'User to' can not be null");
            if (!IsMessageValid(message))
                throw new ArgumentException("Iinvalid message");

			ID = Guid.NewGuid();
			To = to;
			From = from;
			Message = message;
		}

		public Question(User to, string message)
            : this(null, to, message)
		{			
		}

        public bool IsMessageValid(string message)
        {
            return (!(String.IsNullOrEmpty(message)) && (message.Trim().Length <= MESSAGE_MAX_LENGTH));
        }
			
		public override int GetHashCode()
		{            
			return ID.GetHashCode();
		}
	}
}
