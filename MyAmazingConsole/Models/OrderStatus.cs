namespace MyAmazingConsole.Models;

/// <summary>
/// Defines the possible processing states of an <see cref="Order"/> as it moves
/// through the order lifecycle.
/// </summary>
public enum OrderStatus
{
    /// <summary>The order has been created but not yet processed.</summary>
    Created,

    /// <summary>All items in the order have been fulfilled and the order is complete.</summary>
    Completed,

    /// <summary>The order has been dispatched and is on its way to the customer.</summary>
    Shipped,

    /// <summary>The order is closed and no further changes are permitted.</summary>
    Closed
}
