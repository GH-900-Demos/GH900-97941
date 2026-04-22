namespace MyAmazingConsole.Models;

/// <summary>
/// Represents a customer order, aggregating one or more <see cref="OrderItem"/> objects
/// and tracking the order lifecycle through its <see cref="OrderStatus"/>.
/// </summary>
public class Order
{
    /// <summary>Gets the unique identifier for this order, assigned on creation.</summary>
    public Guid Id { get; }

    /// <summary>Gets or sets the customer who placed this order.</summary>
    public Customer Customer { get; set; }

    /// <summary>Gets a read-only view of the line items contained in this order.</summary>
    public IReadOnlyList<OrderItem> Items => _items.AsReadOnly();

    /// <summary>
    /// Gets the total cost of all line items in the order,
    /// calculated as the sum of each <see cref="OrderItem.TotalCost"/>.
    /// </summary>
    public decimal TotalCost => _items.Sum(item => item.TotalCost);

    /// <summary>Gets the current processing status of this order.</summary>
    public OrderStatus Status { get; private set; }

    /// <summary>Gets the UTC date and time at which the order was created.</summary>
    public DateTime CreatedAt { get; }

    private readonly List<OrderItem> _items = new();

    /// <summary>
    /// Initializes a new <see cref="Order"/> for the given customer.
    /// The order is assigned a new unique <see cref="Id"/>, set to
    /// <see cref="OrderStatus.Created"/>, and timestamped with the current UTC time.
    /// </summary>
    /// <param name="customer">The customer who is placing the order.</param>
    public Order(Customer customer)
    {
        Id = Guid.NewGuid();
        Customer = customer;
        Status = OrderStatus.Created;
        CreatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Adds a line item to the order.
    /// </summary>
    /// <param name="item">The <see cref="OrderItem"/> to add.</param>
    public void AddItem(OrderItem item)
    {
        _items.Add(item);
    }

    /// <summary>
    /// Removes all line items whose <see cref="OrderItem.Code"/> matches the specified product code.
    /// </summary>
    /// <param name="productCode">The product code identifying the items to remove.</param>
    public void RemoveItem(string productCode)
    {
        _items.RemoveAll(i => i.Code == productCode);
    }

    /// <summary>
    /// Updates the processing status of the order.
    /// </summary>
    /// <param name="status">The new <see cref="OrderStatus"/> to apply.</param>
    public void UpdateStatus(OrderStatus status)
    {
        Status = status;
    }
}
