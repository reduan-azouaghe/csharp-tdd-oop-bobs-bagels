using System;
using exercise.main.Interfaces;

namespace exercise.main;

public class Inventory
{
    private List<IProduct> _products = [];

    public void AddToInventory(IProduct product)
    {
        _products.Add(product);
    }

    public decimal GetProductPrice(string sku)
    {
        IProduct p = (IProduct)_products.Where(p => p.Sku.Equals(sku));

        if (p == null) throw new KeyNotFoundException($"SKU '{sku}', does not exist in inventory!");

        return p.GetPrice();
    }

    public bool HasSku(string sku)
    {
        IProduct? p = _products.FirstOrDefault(p => p.Sku.Equals(sku));
        return p != null;
    }

    public bool HasProduct(IProduct product)
    {
        IProduct? p = _products.FirstOrDefault(p => p.Sku.Equals(product.Sku));
        if (p == null || !p.Name.Equals(product.Name) || !p.Variant.Equals(product.Variant)) return false;
        return true;
    }
}
