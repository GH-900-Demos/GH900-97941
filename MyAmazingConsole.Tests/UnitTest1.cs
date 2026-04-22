using MyAmazingConsole.Models;

namespace MyAmazingConsole.Tests;

public class OrderItemTests
{
    [Fact]
    public void Constructor_WhenQuantityIsNegative_ThrowsArgumentOutOfRangeException()
    {
        var action = () => new OrderItem("SKU-1", "Sample", -1, 10m);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }

    [Fact]
    public void Constructor_WhenQuantityIsNonNegative_CreatesOrderItem()
    {
        var item = new OrderItem("SKU-1", "Sample", 0, 10m);

        Assert.Equal(0, item.Quantity);
    }
}
