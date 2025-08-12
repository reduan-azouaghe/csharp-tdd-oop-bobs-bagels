using System;
using exercise.main.Interfaces;

namespace exercise.main.Products;

public class Bagel : IProduct
{
    private List<Filling> _fillings = [];
    private decimal _basePrice;

    private static int GLOBALID = 0;
    public int Id { get; }

    public Bagel(string ProductSku, string ProductName, string ProductVariant, decimal ProductBasePrice)
    {
        this.Sku = ProductSku;
        this.Name = ProductName;
        this.Variant = ProductVariant;
        this._basePrice = ProductBasePrice;
        this.Id = GLOBALID;
        GLOBALID++;
    }

    public string Sku { get; set; }
    public string Name { get; set; }
    public string Variant { get; set; }
    public decimal GetPrice()
    {
        if (_fillings.Count == 0) return _basePrice;

        return _basePrice + _fillings.Sum(f => f.GetPrice());
    }

    public List<Filling> GetFillings()
    {
        return _fillings;
    }

    public void AddFilling(IProduct BagelFilling)
    {
        _fillings.Add((Filling)BagelFilling);
    }
}
