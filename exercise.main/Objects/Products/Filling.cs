using System;
using exercise.main.Interfaces;

namespace exercise.main.Products;

public class Filling : IProduct
{
    private decimal _basePrice;
    private bool _isDiscounted = false;
    public string Sku { get; set; }
    public string Name { get; set; }
    public string Variant { get; set; }
    public Guid Id { get; } = Guid.NewGuid();

    public Filling(string ProductSku, string ProductName, string ProductVariant, decimal ProductBasePrice)
    {
        this.Sku = ProductSku;
        this.Name = ProductName;
        this.Variant = ProductVariant;
        this._basePrice = ProductBasePrice;
    }

    public decimal GetPrice()
    {
        return _basePrice;
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

}
