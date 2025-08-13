using System;
using exercise.main.Interfaces;
using exercise.main.Products;

namespace exercise.main.Objects.Discounts;

public class TwelveBagelsDiscount : IDiscount
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; set; } = "The Twelve Bagel Discount!";
    public string Description { get; set; } = "Get a discount when you buy 12 bagels. 12 of the same bagel for 3.99! What a deal!";

    public bool ApplyDiscount(Basket basket)
    {
        bool isSuccess = false;
        decimal _discount = 3.99m / 12;

        var groupedBySku = basket
            .GetBasket()
            .Where(p => !p.IsDiscounted())
            .GroupBy(p => p.Sku)
            .Where(g => g.Count() >= 12)
            .ToList();

        foreach (var group in groupedBySku)
        {
            if (group.First() is Bagel)
            {
                isSuccess = true;
                foreach (var b in group.Take(12))
                {
                    b.ApplyDiscount(b.GetPrice() - _discount);
                }
            }
        }

        return isSuccess;
    }
}
