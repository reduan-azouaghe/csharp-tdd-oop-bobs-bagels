using System;
using exercise.main.Interfaces;
using exercise.main.Products;

namespace exercise.main.Objects.Discounts;

public class SixBagelsDiscount : IDiscount
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; set; } = "The Six Bagel Discount!";
    public string Description { get; set; } = "Get a discount when you buy 6 bagels. 6 of the same bagel for 2.49! What a deal!";

    public bool ApplyDiscount(Basket basket)
    {
        bool isSuccess = false;
        decimal _discount = 2.49m / 6;

        var groupedBySku = basket
            .GetBasket()
            .Where(p => !p.IsDiscounted())
            .GroupBy(p => p.Sku)
            .Where(g => g.Count() >= 6)
            .ToList();

        foreach (var group in groupedBySku)
        {
            if (group.First() is Bagel)
            {
                isSuccess = true;
                foreach (var b in group.Take(6))
                {
                    b.ApplyDiscount(b.GetPrice() - _discount);
                }
            }
        }

        return isSuccess;
    }
}
