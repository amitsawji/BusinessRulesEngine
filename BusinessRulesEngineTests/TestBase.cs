using AutoFixture;
using NUnit.Framework;

namespace BusinessRulesEngineTests
{
    public abstract class TestBase
    {
        protected Fixture _fixture { get; private set; }

        [SetUp]
        public void TestInitialize()
        {
            _fixture = new Fixture();
        }
    }
}
