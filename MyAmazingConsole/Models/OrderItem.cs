namespace MyAmazingConsole.Models;

public class OrderItem
{
    public string Code { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
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
