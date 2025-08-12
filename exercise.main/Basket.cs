using System;
using System.Dynamic;
using exercise.main.Interfaces;
using exercise.main.Products;

namespace exercise.main;

public class Basket(int MaxSize, Inventory ProductSelection)
{
    private List<IProduct> _basket = [];
    private Inventory _inventory = ProductSelection;
    private int _basketMaxSize = MaxSize;

    public bool AddProduct(IProduct Product)
    {
        if (!_inventory.HasProduct(Product))
            return false;
        if (_basket.Count >= _basketMaxSize)
            throw new OverflowException($"Basket is full!");
        else
            _basket.Add(Product);

        return true;
    }

    public int Count()
    {
        return _basket.Count;
    }

    public bool AddFillingToBagel(Bagel Bagel, Filling Filling)
    {
        IProduct? b = _basket.Find(p => p.Id == Bagel.Id);

        if (b is Bagel bagelItem && b != null)
        {
            bagelItem.AddFilling(Filling);
            return true;
        }

        return false;
    }

    public decimal GetTotalCost()
    {
        return _basket.Sum(p => p.GetPrice());
    }

    public decimal GetCostOfSku(string sku)
    {
        return _basket.Where(p => p.Sku == sku).Sum(p => p.GetPrice());
    }

    public void ChangeCapacity(int NewCapacity)
    {
        _basketMaxSize = NewCapacity;
    }

    public bool RemoveProduct(IProduct Product)
    {
        if (_basket.IndexOf(Product) == -1) throw new KeyNotFoundException("Product does not exist in basket!");
        else _basket.Remove(Product);

        return true;
    }

    public bool RemoveAllProduct(string Sku)
    {
        if (_basket.Find(p => p.Sku == Sku) == null) throw new KeyNotFoundException("Product does not exist in basket!");
        else _basket.RemoveAll(p => p.Sku == Sku);

        return true;
    }

    public bool IsFull()
    {
        return _basket.Count >= _basketMaxSize;
    }

    public bool ValidateProductExists(IProduct product)
    {
        return _basket.Contains(product);
    }
}
