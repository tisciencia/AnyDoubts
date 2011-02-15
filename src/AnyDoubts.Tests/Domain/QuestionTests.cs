using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SharpTestsEx;
using AnyDoubts.Domain.Model;

namespace AnyDoubts.Tests.Domain
{
    [TestFixture]
    public class QuestionTests
    {
        public const int MESSAGE_MAX_LENGTH = 255;

        [Test]
        public void QuestionMessageShouldBeValid()
        {
            Question question = new Question(new User(), "Olá tudo bem?");
            question.Message.Should().Be("Olá tudo bem?");
        }

        [Test]
        public void QuestionAnswerShouldBeAnswered()
        {
            Question question = new Question(new User(), "Olá tudo bem?");
            question.Answer = "Sim, obrigado.";
            
            question.IsAnswered.Should().Be(true);
        }

        [Test]
        public void QuestionAnswerShouldBeNotAnswered()
        {
            Question question = new Question(new User(), "Olá tudo bem?");
            
            question.IsAnswered.Should().Be(false);
        }

        [Test]
        public void QuestionObjectShouldBeDiff()
        {
            Question question1 = new Question(new User(), "Olá tudo bem?");
            Question question2 = new Question(new User(), "Olá tudo bem?");

            question1.Equals(question2).Should().Be(false);
        }
        [Test]
        [ExpectedException("System.ArgumentException")]
        public void QuestionMessageShouldBeInvalidWhenEmpty()
        {
            Question question = new Question(new User(), "");            
        }
		
		[Test]
        [ExpectedException("System.ArgumentException")]
        public void QuestionMessageShouldBeInvalidWhenToNull()
        {
            Question question = new Question(null, "Olá tudo bem?");            
        }

		[Test]        
        public void QuestionShouldBeToUserTiago()
        {		
			User tiago = new User("Tiago");
            Question question = new Question(null, tiago, "Olá tudo bem?");
			question.To.Should().Be(tiago);
        }
		
		[Test]        
        public void QuestionShouldBeFromUserVintemToAnyUser()
        {		
			User tiago = new User("Tiago");
			User vintem = new User("Vintem");
            Question question = new Question(vintem, tiago, "Olá tudo bem?");
			question.From.Should().Be(vintem);
        }
		
        [Test]
        [ExpectedException("System.ArgumentException")]
        public void QuestionMessageShouldBeInvalidWhenNull()
        {
            Question question = new Question(new User(), null);
        }

        [Test]
        [ExpectedException("System.ArgumentException")]
        public void QuestionMessageShouldBeInvalidWithMessage256()
        {
            char[] charArrayOverMaxLength = new char[MESSAGE_MAX_LENGTH + 1];
            for (int i = 0; i < MESSAGE_MAX_LENGTH + 1; i++)
                charArrayOverMaxLength[i] = '.';

            string messageOverMaxLength = new string(charArrayOverMaxLength);
            Question question = new Question(new User(), messageOverMaxLength);
        }

        [Test]
        public void QuestionMessageShouldBeValidWithMessage255()
        {
            char[] charArrayMaxLength = new char[MESSAGE_MAX_LENGTH];
            for (int i = 0; i < MESSAGE_MAX_LENGTH; i++)
                charArrayMaxLength[i] = '.';

            string messageMaxLength = new string(charArrayMaxLength);
            Question question = new Question(new User(), messageMaxLength);

            question.Message.Length.Should().Be(MESSAGE_MAX_LENGTH);
        }
		
		[Test]        
        public void QuestionShouldBeAnonym()
        {	
			User tiago = new User("Tiago");
            Question question = new Question(null, tiago, "Olá tudo bem?");
			question.IsAnonymous.Should().Be(true);
        }
		
		[Test]        
        public void QuestionShouldNotBeAnonym()
        {	
			User tiago = new User("Tiago");
			User vintem = new User("Vintem");
            Question question = new Question(vintem, tiago, "Olá tudo bem?");
			question.IsAnonymous.Should().Be(false);
        }
    }
}