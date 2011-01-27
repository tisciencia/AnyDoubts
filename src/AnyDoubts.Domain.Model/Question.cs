using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnyDoubts.Domain.Model
{
    public class Question : EntityBase
    {
        private const int MESSAGE_MAX_LENGTH = 255;

        private Guid _id;
        private string _message;
        private string _answer;
        
        public string Message
        {
            get { return _message; }            
        }
        public string Answer
        {
            get { return _answer; }
            set { _answer = value; }
        }
        public bool IsAnswered
        {
            get { return !String.IsNullOrEmpty(_answer); }
        }

        public int UserId { get; set; }

        private Question() { }
        public Question(string message)
        {
            if (!IsMessageValid(message))
		        throw new ArgumentException("Iinvalid message");
                        
            this._id = Guid.NewGuid();
	        this._message = message;                
        }

        public bool IsMessageValid(string message)
        {
            return (!(String.IsNullOrEmpty(message)) && (message.Trim().Length <= MESSAGE_MAX_LENGTH));
        }
        
        public override int GetHashCode()
        {            
            return _id.GetHashCode();
        }
    }
}
