namespace MyAmazingConsole.Models;

public class OrderItem
{
    public string Code { get; set; }
    public string Description { get; set; }
    private int _quantity;
    public int Quantity
    {
        get => _quantity;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Quantity cannot be negative.");
            }

            _quantity = value;
        }
    }
    public decimal UnitCost { get; set; }
    public decimal TotalCost => UnitCost * Quantity;

    public OrderItem(string code, string description, int quantity, decimal unitCost)
    {
        Code = code;
        Description = description;
        Quantity = quantity;
        UnitCost = unitCost;
    }
}
