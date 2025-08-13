using System;

namespace exercise.main.Interfaces;

public interface IDiscount
{
    Guid Id { get; }
    string Name { get; set; }
    string Description { get; set; }

    bool ApplyDiscount(Basket basket);
}
