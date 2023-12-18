using UnitTests.Services;

namespace ChatClientUnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            var client = new Client("Vasya", "172.0.0.1", 12345);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}