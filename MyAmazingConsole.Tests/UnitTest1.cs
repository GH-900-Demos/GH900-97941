using MyAmazingConsole.Models;

namespace MyAmazingConsole.Tests;

/// <summary>
/// Unit tests for the <see cref="OrderItem"/> class, covering validation and construction behavior.
/// </summary>
public class OrderItemTests
{
    /// <summary>
    /// Verifies that passing a negative quantity to the <see cref="OrderItem"/> constructor
    /// causes an <see cref="ArgumentOutOfRangeException"/> to be thrown.
    /// </summary>
    [Fact]
    public void Constructor_WhenQuantityIsNegative_ThrowsArgumentOutOfRangeException()
    {
        var action = () => new OrderItem("SKU-1", "Sample", -1, 10m);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }

    /// <summary>
    /// Verifies that a non-negative quantity (including zero) is accepted by the
    /// <see cref="OrderItem"/> constructor and stored correctly.
    /// </summary>
    [Fact]
    public void Constructor_WhenQuantityIsNonNegative_CreatesOrderItem()
    {
        var item = new OrderItem("SKU-1", "Sample", 0, 10m);

        Assert.Equal(0, item.Quantity);
    }
}
