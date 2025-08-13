using exercise.main;
using exercise.main.Products;

namespace exercise.tests
{
    [TestFixture]
    public class CoreTests
    {
        private Basket TestBasket;
        private Inventory TestInventory;

        [SetUp]
        public void Setup()
        {
            TestInventory = new();
            TestInventory.AddToInventory(new Bagel("BGLO", "Bagel", "Onion", 0.49m));
            TestInventory.AddToInventory(new Bagel("BGLP", "Bagel", "Plain", 0.39m));
            TestInventory.AddToInventory(new Bagel("BGLE", "Bagel", "Everything", 0.49m));
            TestInventory.AddToInventory(new Bagel("BGLS", "Bagel", "Sesame", 0.49m));
            TestInventory.AddToInventory(new Coffee("COFB", "Coffee", "Black", 0.99m));
            TestInventory.AddToInventory(new Coffee("COFW", "Coffee", "White", 1.19m));
            TestInventory.AddToInventory(new Coffee("COFC", "Coffee", "Capuccino", 1.29m));
            TestInventory.AddToInventory(new Coffee("COFL", "Coffee", "Latte", 1.29m));
            TestInventory.AddToInventory(new Filling("FILB", "Filling", "Bacon", 0.12m));
            TestInventory.AddToInventory(new Filling("FILE", "Filling", "Egg", 0.12m));
            TestInventory.AddToInventory(new Filling("FILC", "Filling", "Cheese", 0.12m));
            TestInventory.AddToInventory(new Filling("FILX", "Filling", "Cream Cheese", 0.12m));
            TestInventory.AddToInventory(new Filling("FILS", "Filling", "Smoked Salmon", 0.12m));
            TestInventory.AddToInventory(new Filling("FILH", "Filling", "Ham", 0.12m));
            TestBasket = new(99, TestInventory);
        }

        [Test]
        public void AddProductEdgeCases_ProductInBasket()
        {
            TestBasket.ChangeCapacity(1);
            Assert.That(TestBasket.AddProduct(new Bagel("BGLO", "Bagel", "Onion", 0.49m)), Is.True);
        }

        [Test]
        public void AddProductEdgeCases_Overflow()
        {
            TestBasket.ChangeCapacity(0);
            Assert.Catch<OverflowException>(() => TestBasket.AddProduct(new Bagel("BGLO", "Bagel", "Onion", 0.49m)));
        }

        [Test]
        public void RemoveFromBasket_ProductIsRemoved()
        {
            TestBasket.ChangeCapacity(1);
            Coffee c = new("COFB", "Coffee", "Black", 0.99m);

            Assert.That(TestBasket.AddProduct(c), Is.True);
            Assert.That(TestBasket.Count(), Is.EqualTo(1));

            Assert.That(TestBasket.RemoveProduct(c), Is.True);
            Assert.That(TestBasket.Count(), Is.EqualTo(0));
        }

        [Test]
        public void RemoveFromBasket_ThrowsError()
        {
            Assert.Catch<KeyNotFoundException>(() => TestBasket.RemoveProduct(new Coffee("COFB", "Coffee", "Black", 0.99m)));
        }

        [Test]
        public void ExpandBasket_BasketIsLarger()
        {
            TestBasket.ChangeCapacity(1);
            Assert.That(TestBasket.AddProduct(new Bagel("BGLO", "Bagel", "Onion", 0.49m)), Is.True);
            Assert.Catch<OverflowException>(() => TestBasket.AddProduct(new Bagel("BGLO", "Bagel", "Onion", 0.49m)));

            TestBasket.ChangeCapacity(2);
            Assert.That(TestBasket.AddProduct(new Bagel("BGLO", "Bagel", "Onion", 0.49m)), Is.True);

            Assert.That(TestBasket.Count(), Is.EqualTo(2));
        }

        [Test]
        public void GetTotalCostOfBasket_CalculatesValue()
        {
            TestBasket.ChangeCapacity(2);

            Coffee c = new("COFW", "Coffee", "White", 1.19m);
            Bagel b = new("BGLO", "Bagel", "Onion", 0.49m);
            b.AddFilling(new Filling("FILX", "Filling", "Cream Cheese", 0.12m));
            b.AddFilling(new Filling("FILS", "Filling", "Smoked Salmon", 0.12m));

            TestBasket.AddProduct(c);
            TestBasket.AddProduct(b);

            Assert.That(TestBasket.GetTotalCost(), Is.EqualTo(1.92m));
        }

        [Test]
        public void GetPriceOfBagel_PriceOfBAgel()
        {
            Bagel b = new("BGLO", "Bagel", "Onion", 0.49m);
            b.AddFilling(new Filling("FILX", "Filling", "Cream Cheese", 0.12m));
            b.AddFilling(new Filling("FILS", "Filling", "Smoked Salmon", 0.12m));
            b.AddFilling(new Filling("FILB", "Filling", "Bacon", 0.12m));

            Assert.That(b.GetPrice(), Is.EqualTo(0.85m));
        }

        [Test]
        public void AddFillingToBagel_BagleHasFilling()
        {
            Filling f = new Filling("FILX", "Filling", "Cream Cheese", 0.12m);

            Bagel b = new("BGLO", "Bagel", "Onion", 0.49m);
            b.AddFilling(f);

            Assert.That(b.GetFillings()[0], Is.EqualTo(f));
        }

        [Test]
        public void FillingGetPrice_PriceOfFilling()
        {
            Filling f = new Filling("FILX", "Filling", "Cream Cheese", 0.12m);
            Assert.That(f.GetPrice, Is.EqualTo(0.12m));
        }

        [Test]
        public void CanOnlyAddProductsFromInventory_FakeProductsNotAdded()
        {
            TestBasket.ChangeCapacity(1);
            Assert.That(TestBasket.AddProduct(new Filling("MSFT", "Microsoft", "Windows", 0.01m)), Is.EqualTo(false));
        }
    }
}

