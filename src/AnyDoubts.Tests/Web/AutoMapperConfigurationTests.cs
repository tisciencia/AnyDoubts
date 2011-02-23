using AnyDoubts.Web;
using AutoMapper;
using NUnit.Framework;

namespace AnyDoubts.Tests.Web
{
    [TestFixture]
    public class AutoMapperConfigurationTests
    {
        [Test]
        public void Should_map_entities()
        {
            AutoMapperConfiguration.Configure();
            Mapper.AssertConfigurationIsValid();
        }
    }
}
