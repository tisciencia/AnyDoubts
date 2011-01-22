using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using AnyDoubts.Domain.Model;
using AnyDoubts.Domain.Repositoy;
using AnyDoubts.DAO;
using SharpTestsEx;

namespace AnyDoubts.Tests.Repository
{
    [TestFixture]
    public class QuestionRepositoryTests
    {
        [Test]
        public void PersistQuestion()
        {
            Question q = new Question("pergunta teste.");

            IQuestions questions = DAOFactory.Get<IQuestions>();

            questions.Add(q);
            //Question q1 = qr.QueryByExample(q);

                       
        }

        //[Test]
        //public void LoadQuestion()
        //{
        //    Question q = new Question("pergunta teste");

        //    try
        //    {

        //        QuestionRepository qr = new QuestionRepository();
        //        Question q1 = qr.GetAll().First();

        //        q1.Answer = "resposta teste.";

        //        qr.Update(q1);
        //        qr.Commit();

        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.Fail(ex.Message);
        //    }
        //}
    }
}
