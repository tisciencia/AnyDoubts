using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnyDoubts.Domain.Model
{
    public class Question
    {
        private const int MESSAGE_MAX_LENGTH = 255;
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
        
        private Question() { }
        public Question(string message)
        {
            if (!IsMessageValid(message))
		throw new ArgumentException("Iinvalid message");                
		
	    this._message = message;                
        }

        public bool IsMessageValid(string message)
        {
            return (!(String.IsNullOrEmpty(message)) && (message.Trim().Length <= MESSAGE_MAX_LENGTH));
        }        
    }
}
