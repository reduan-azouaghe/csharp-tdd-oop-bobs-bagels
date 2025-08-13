using System.Text;
using exercise.main.Interfaces;
using exercise.main.Products;

namespace exercise.main;

public class Basket(int maxSize, Inventory productSelection)
{
    private readonly Inventory _inventory = productSelection;
    private readonly List<IProduct> _basket = [];
    private int _basketMaxSize = maxSize;

    public bool AddProduct(IProduct product)
    {
        if (!_inventory.HasProduct(product)) return false;
        if (_basket.Count >= _basketMaxSize) throw new OverflowException("Basket is full!");
        _basket.Add(product);
        return true;
    }

    public bool ApplyDiscount(IDiscount discount) => discount.ApplyDiscount(this);

    public int Count() => _basket.Count;

    public bool AddFillingToBagel(Bagel bagel, Filling filling)
    {
        var b = _basket.Find(p => p.Id == bagel.Id);
        if (b is Bagel bagelItem)
        {
            bagelItem.AddFilling(filling);
            return true;
        }
        return false;
    }

    public decimal GetTotalCost() => _basket.Sum(p => p.GetPrice());

    public decimal GetCostOfSku(string sku) =>
        _basket.Where(p => p.Sku == sku).Sum(p => p.GetPrice());

    public void ChangeCapacity(int newCapacity) => _basketMaxSize = newCapacity;

    public bool RemoveProduct(IProduct product)
    {
        if (!_basket.Remove(product)) throw new KeyNotFoundException("Product does not exist in basket!");
        return true;
    }

    public bool RemoveAllProduct(string sku)
    {
        if (!_basket.Any(p => p.Sku == sku)) throw new KeyNotFoundException("Product does not exist in basket!");
        _basket.RemoveAll(p => p.Sku == sku);
        return true;
    }

    public bool IsFull() => _basket.Count >= _basketMaxSize;

    public bool ValidateProductExists(IProduct product) => _basket.Contains(product);

    public List<IProduct> GetBasket() => _basket;

    public override string ToString()
    {
        StringBuilder s = new();

        s.Append("\n~~~ Bob's Bagels ~~~");
        s.Append($"\n{DateTime.Now}");
        s.Append("\n------");

        _basket
            .GroupBy(p => p.Sku)
            .ToList()
            .ForEach(g =>
                s.Append($"\n{g.First().Name} {g.Count()} {g.Sum(p => p.GetPrice()):C}")
            );

        s.Append("\n------");
        s.Append($"\nTotal: {this.GetTotalCost()}");
        s.Append("\nThank you");
        s.Append("\nfor your order!");

        return s.ToString();
    }
}
