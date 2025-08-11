using exercise.main;
using exercise.main.Products;
namespace exercise.tests
{
    [TestFixture]
    public class CoreTests
    {
        private Basket _basket;

        [SetUp]
        public void Setup()
        {
            _basket = new();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass(_basket.addProduct(new Bagel()));
        }
    }
}

