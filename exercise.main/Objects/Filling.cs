using System;
using exercise.main.Interfaces;

namespace exercise.main.Products;

public class Filling : IProduct
{
    private static int GLOBALID = 0;
    private decimal _basePrice;
    public string Sku { get; set; }
    public string Name { get; set; }
    public string Variant { get; set; }
    public int Id { get; }

    public Filling(string ProductSku, string ProductName, string ProductVariant, decimal ProductBasePrice)
    {
        this.Sku = ProductSku;
        this.Name = ProductName;
        this.Variant = ProductVariant;
        this._basePrice = ProductBasePrice;
        this.Id = GLOBALID;
        GLOBALID++;
    }

    public decimal GetPrice()
    {
        return _basePrice;
    }
}
