using System;
using exercise.main.Interfaces;

namespace exercise.main.Products;

public class Bagel : IProduct
{
    private List<Filling> _fillings = [];
    private decimal _basePrice;
    private bool _isDiscounted = false;
    public Guid Id { get; } = Guid.NewGuid();

    public Bagel(string ProductSku, string ProductName, string ProductVariant, decimal ProductBasePrice)
    {
        this.Sku = ProductSku;
        this.Name = ProductName;
        this.Variant = ProductVariant;
        this._basePrice = ProductBasePrice;
    }

    public string Sku { get; set; }
    public string Name { get; set; }
    public string Variant { get; set; }

    public decimal GetPrice()
    {
        if (_fillings.Count == 0) return _basePrice;

        return _basePrice + _fillings.Sum(f => f.GetPrice());
    }

    public bool ApplyDiscount(decimal discount)
    {
        if (_isDiscounted) return false;

        _basePrice = Math.Max(_basePrice - discount, 0);

        _isDiscounted = true;

        return true;
    }

    public bool IsDiscounted()
    {
        return _isDiscounted;
    }

    public List<Filling> GetFillings()
    {
        return _fillings;
    }

    public void AddFilling(Filling BagelFilling)
    {
        _fillings.Add(BagelFilling);
    }
}
