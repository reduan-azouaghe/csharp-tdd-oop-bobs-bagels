namespace exercise.main.Interfaces;

public interface IProduct
{
    string Sku { get; set; }
    string Name { get; set; }
    string Variant { get; set; }
    int Id { get; }
    decimal GetPrice();
}
