using AutoFixture;
using Moq;
using NUnit.Framework;

namespace BusinessRulesEngineTests
{
    public abstract class TestBase
    {
        protected Fixture _fixture { get; private set; }
        protected MockRepository MockRepository { get; private set; }

        [SetUp]
        public void TestInitialize()
        {
            MockRepository = new MockRepository(MockBehavior.Strict);
            _fixture = new Fixture();
        }
    }
}
