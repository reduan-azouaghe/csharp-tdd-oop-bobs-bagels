using exercise.main;
using exercise.main.Objects.Discounts;
using exercise.main.Products;

namespace exercise.tests
{
    [TestFixture]
    public class ExtensionTests
    {
        private Basket TestBasket;
        private Inventory TestInventory;

        [SetUp]
        public void Setup()
        {
            TestInventory = new();
            TestBasket = new(99, TestInventory);
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
        }

        [Test]
        public void Reciept()
        {
            TestBasket.AddProduct(new Bagel("BGLO", "Bagel", "Onion", 0.49m));
            TestBasket.AddProduct(new Bagel("BGLO", "Bagel", "Onion", 0.49m));
            TestBasket.AddProduct(new Bagel("BGLO", "Bagel", "Onion", 0.49m));
            TestBasket.AddProduct(new Bagel("BGLO", "Bagel", "Onion", 0.49m));
            TestBasket.AddProduct(new Bagel("BGLO", "Bagel", "Onion", 0.49m));
            TestBasket.AddProduct(new Bagel("BGLO", "Bagel", "Onion", 0.49m));
            TestBasket.AddProduct(new Bagel("BGLO", "Bagel", "Onion", 0.49m));
            TestBasket.AddProduct(new Bagel("BGLO", "Bagel", "Onion", 0.49m));
            TestBasket.AddProduct(new Bagel("BGLO", "Bagel", "Onion", 0.49m));
            TestBasket.AddProduct(new Coffee("COFC", "Coffee", "Capuccino", 1.29m));
            TestBasket.AddProduct(new Coffee("COFC", "Coffee", "Capuccino", 1.29m));
            TestBasket.AddProduct(new Coffee("COFC", "Coffee", "Capuccino", 1.29m));

            Assert.That(TestBasket.ToString(), Is.Not.Null);
        }

        [Test]
        public void SixDiscount()
        {
            SixBagelsDiscount _sixDisc = new SixBagelsDiscount();

            TestBasket.AddProduct(new Bagel("BGLO", "Bagel", "Onion", 0.49m));
            TestBasket.AddProduct(new Bagel("BGLO", "Bagel", "Onion", 0.49m));
            TestBasket.AddProduct(new Bagel("BGLO", "Bagel", "Onion", 0.49m));
            TestBasket.AddProduct(new Bagel("BGLO", "Bagel", "Onion", 0.49m));
            TestBasket.AddProduct(new Bagel("BGLO", "Bagel", "Onion", 0.49m));
            TestBasket.AddProduct(new Bagel("BGLO", "Bagel", "Onion", 0.49m));
            TestBasket.ApplyDiscount(_sixDisc);

            Assert.That(TestBasket.GetTotalCost(), Is.EqualTo(2.49m));
        }

        [Test]
        public void TwelveDiscount()
        {
            TwelveBagelsDiscount _twelveDisc = new TwelveBagelsDiscount();

            TestBasket.AddProduct(new Bagel("BGLO", "Bagel", "Onion", 0.49m));
            TestBasket.AddProduct(new Bagel("BGLO", "Bagel", "Onion", 0.49m));
            TestBasket.AddProduct(new Bagel("BGLO", "Bagel", "Onion", 0.49m));
            TestBasket.AddProduct(new Bagel("BGLO", "Bagel", "Onion", 0.49m));
            TestBasket.AddProduct(new Bagel("BGLO", "Bagel", "Onion", 0.49m));
            TestBasket.AddProduct(new Bagel("BGLO", "Bagel", "Onion", 0.49m));
            TestBasket.AddProduct(new Bagel("BGLO", "Bagel", "Onion", 0.49m));
            TestBasket.AddProduct(new Bagel("BGLO", "Bagel", "Onion", 0.49m));
            TestBasket.AddProduct(new Bagel("BGLO", "Bagel", "Onion", 0.49m));
            TestBasket.AddProduct(new Bagel("BGLO", "Bagel", "Onion", 0.49m));
            TestBasket.AddProduct(new Bagel("BGLO", "Bagel", "Onion", 0.49m));
            TestBasket.AddProduct(new Bagel("BGLO", "Bagel", "Onion", 0.49m));

            TestBasket.ApplyDiscount(_twelveDisc);

            Assert.That(TestBasket.GetTotalCost(), Is.EqualTo(3.99m));
        }

        [Test]
        public void CoffeBagelDisc()
        {
            CoffeeBagelsDiscount _cbdisc = new CoffeeBagelsDiscount();

            TestBasket.AddProduct(new Bagel("BGLO", "Bagel", "Onion", 0.49m));
            TestBasket.AddProduct(new Coffee("COFB", "Coffee", "Black", 0.99m));

            TestBasket.ApplyDiscount(_cbdisc);

            Assert.That(TestBasket.GetTotalCost(), Is.EqualTo(1.25m));
        }
    }
}

