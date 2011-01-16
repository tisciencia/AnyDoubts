using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SharpTestsEx;
using AnyDoubts.Domain.Entities;

namespace AnyDoubts.Tests.Domain
{
    [TestFixture]
    public class QuestionTests
    {
        public const int MESSAGE_MAX_LENGTH = 255;

        [Test]
        public void QuestionMessageShouldBeValid()
        {
            Question question = new Question("Olá tudo bem?");
            question.Message.Should().Be("Olá tudo bem?");
        }

        [Test]
        [ExpectedException("System.ArgumentException")]
        public void QuestionMessageShouldBeInvalidWhenEmpty()
        {
            Question question = new Question("");      
        }

        [Test]
        [ExpectedException("System.ArgumentException")]
        public void QuestionMessageShouldBeInvalidWhenNull()
        {
            Question question = new Question(null);
        }

        [Test]        
        public void QuestionMessageShouldBeValidWithMessage255()
        {
            char[] charArrayMaxLength = new char[MESSAGE_MAX_LENGTH];
            for (int i = 0; i < MESSAGE_MAX_LENGTH; i++)
                charArrayMaxLength[i] = '.';
            
            string messageMaxLength = new string(charArrayMaxLength);
            Question question = new Question(messageMaxLength);

            question.Message.Length.Should().Be(MESSAGE_MAX_LENGTH);
        }

        [Test]
        [ExpectedException("System.ArgumentException")]
        public void QuestionMessageShouldBeInvalidWithMessage256()
        {
            char[] charArrayOverMaxLength = new char[MESSAGE_MAX_LENGTH + 1];
            for (int i = 0; i < MESSAGE_MAX_LENGTH + 1; i++)
                charArrayOverMaxLength[i] = '.';

            string messageOverMaxLength = new string(charArrayOverMaxLength);
            Question question = new Question(messageOverMaxLength);
        }

        [Test]
        public void QuestionAnswerShouldBeAnswered()
        {
            Question question = new Question("Olá tudo bem?");
            question.Answer = "Sim obrigado.";
            
            question.IsAnswered.Should().Be(true);
        }

        [Test]
        public void QuestionAnswerShouldBeNotAnswered()
        {
            Question question = new Question("Olá tudo bem?");
            
            question.IsAnswered.Should().Be(false);
        }
    }
}
