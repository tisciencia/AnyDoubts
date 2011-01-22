using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using AnyDoubts.Domain.Model;
using AnyDoubts.Domain.Repositoy;
using AnyDoubts.Infra.Repository.Repositories;
using AnyDoubts.Infra.Repository;
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
            Question q2 = new Question("pergunta teste.");
            try
            {
                QuestionRepository qr = new QuestionRepository();
                Question q1 = qr.QueryByExample(q);

                ISessionManager session = SessionManagerFactory.GetInstance();

                if (qr.IsStored(q1))
                {                     
                }
                

                qr.Add(q);


                if (qr.IsStored(q1))
                {
                }
                
                //Assert.True(q1.Equals(q2));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
                
        //[Test]
        //public void LoadQuestion()
        //{
        //    Question q = new Question("pergunta teste");

        //    try
        //    {
        //        ObjectContainerManager container = new ObjectContainerManager();

        //        QuestionRepository qr = new QuestionRepository(container);

        //        List<Question> lista = qr.GetAll();

        //        lista.Count.Should().Be(2);
                
        //        RepositoryContext rc = new RepositoryContext(container);
        //        rc.SaveChanges();
        //        rc.Terminate();
        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.Fail(ex.Message);
        //    }
        //}
    }
}
