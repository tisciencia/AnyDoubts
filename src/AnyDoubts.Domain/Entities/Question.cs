using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnyDoubts.Domain.Entities
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
            get 
            {
                if (String.IsNullOrEmpty(_answer))
                    return false;
                else
                    return true;
            }
        }
        
        private Question() { }
        public Question(string message)
        {
            if (IsMessageValid(message))
                this._message = message;
            else
                throw new ArgumentException("Iinvalid message");
        }

        public bool IsMessageValid(string message)
        {
            if ((String.IsNullOrEmpty(message)) || (message.Trim().Length > MESSAGE_MAX_LENGTH))
                return false;
            else 
                return true;
        }        
    }
}
