namespace exercise.main.Interfaces;

public interface IProduct
{
    string Sku { get; set; }
    string Name { get; set; }
    string Variant { get; set; }
    Guid Id { get; }
    decimal GetPrice();
    bool ApplyDiscount(decimal discount);
    bool IsDiscounted();
}
