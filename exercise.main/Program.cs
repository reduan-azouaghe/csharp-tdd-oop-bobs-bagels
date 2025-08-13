using exercise.main;
using exercise.main.Objects.Discounts;
using exercise.main.Products;

Inventory TestInventory = new();
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

Basket TestBasket = new(99, TestInventory);
CoffeeBagelsDiscount d = new CoffeeBagelsDiscount();

TestBasket.AddProduct(new Bagel("BGLO", "Bagel", "Onion", 0.49m));
TestBasket.AddProduct(new Coffee("COFB", "Coffee", "Black", 0.99m));


TestBasket.ApplyDiscount(d);

Console.WriteLine(TestBasket);

