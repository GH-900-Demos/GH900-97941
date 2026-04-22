namespace MyAmazingConsole.Models;

/// <summary>
/// Represents a single line item within an <see cref="Order"/>,
/// identified by a product code and carrying quantity and pricing information.
/// </summary>
public class OrderItem
{
    /// <summary>Gets or sets the unique product code (SKU) for this item.</summary>
    public string Code { get; set; }

    /// <summary>Gets or sets a human-readable description of the product.</summary>
    public string Description { get; set; }

    private int _quantity;

    /// <summary>
    /// Gets or sets the number of units ordered.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when the value is set to a negative number.
    /// </exception>
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

    /// <summary>Gets or sets the cost per individual unit.</summary>
    public decimal UnitCost { get; set; }

    /// <summary>
    /// Gets the total cost for this line item, calculated as
    /// <see cref="UnitCost"/> multiplied by <see cref="Quantity"/>.
    /// </summary>
    public decimal TotalCost => UnitCost * Quantity;

    /// <summary>
    /// Initializes a new <see cref="OrderItem"/> with the specified product details.
    /// </summary>
    /// <param name="code">The unique product code (SKU).</param>
    /// <param name="description">A human-readable description of the product.</param>
    /// <param name="quantity">The number of units to order. Must be zero or greater.</param>
    /// <param name="unitCost">The cost per unit.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="quantity"/> is negative.
    /// </exception>
    public OrderItem(string code, string description, int quantity, decimal unitCost)
    {
        Code = code;
        Description = description;
        Quantity = quantity;
        UnitCost = unitCost;
    }
}
