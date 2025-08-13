using System;
using exercise.main.Interfaces;
using exercise.main.Products;

namespace exercise.main.Objects.Discounts;

public class CoffeeBagelsDiscount : IDiscount
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; set; } = "The Coffe & Bagel Discount!";
    public string Description { get; set; } = "Buy a coffee and a bagle for just 1.25!";

    public bool ApplyDiscount(Basket basket)
    {
        bool isSuccess = false;

        var availableItems = basket
            .GetBasket()
            .Where(p => !p.IsDiscounted())
            .ToList();

        var bagel = availableItems.OfType<Bagel>().FirstOrDefault();
        var coffee = availableItems.OfType<Coffee>().FirstOrDefault();

        if (bagel != null && coffee != null)
        {
            decimal totalComboPrice = Math.Max(bagel.GetPrice() + coffee.GetPrice() - 1.25m, 0);
            decimal bagelDiscount = bagel.GetPrice();
            decimal coffeeDiscount = coffee.GetPrice();

            if (totalComboPrice != 0)
            {
                bagelDiscount = bagel.GetPrice() - (totalComboPrice / 2);
                coffeeDiscount = coffee.GetPrice() - (totalComboPrice / 2);
            }

            bagel.ApplyDiscount(bagel.GetPrice()-bagelDiscount);
            coffee.ApplyDiscount(coffee.GetPrice()-coffeeDiscount);

            isSuccess = true;
        }

        return isSuccess;
    }

}
