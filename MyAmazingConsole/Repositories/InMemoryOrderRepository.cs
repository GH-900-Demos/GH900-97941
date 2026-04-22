using MyAmazingConsole.Models;

namespace MyAmazingConsole.Repositories;

/// <summary>
/// An in-memory implementation of <see cref="IOrderRepository"/> that stores orders
/// in a <see cref="Dictionary{TKey,TValue}"/> keyed by <see cref="Order.Id"/>.
/// This implementation is suitable for testing and lightweight scenarios where
/// persistence across application restarts is not required.
/// </summary>
public class InMemoryOrderRepository : IOrderRepository
{
    private readonly Dictionary<Guid, Order> _orders = new();

    /// <summary>
    /// Adds the given order to the in-memory store.
    /// </summary>
    /// <param name="order">The order to add. Its <see cref="Order.Id"/> must not already exist.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown when an order with the same <see cref="Order.Id"/> is already present.
    /// </exception>
    public void Add(Order order)
    {
        if (_orders.ContainsKey(order.Id))
            throw new InvalidOperationException($"An order with ID {order.Id} already exists.");

        _orders[order.Id] = order;
    }

    /// <summary>
    /// Looks up an order by its unique identifier.
    /// </summary>
    /// <param name="id">The <see cref="Guid"/> of the order to retrieve.</param>
    /// <returns>The matching <see cref="Order"/>, or <c>null</c> if not found.</returns>
    public Order? GetById(Guid id)
    {
        _orders.TryGetValue(id, out var order);
        return order;
    }

    /// <summary>
    /// Returns every order currently held in the in-memory store.
    /// </summary>
    /// <returns>A read-only list of all stored <see cref="Order"/> objects.</returns>
    public IReadOnlyList<Order> GetAll()
    {
        return _orders.Values.ToList().AsReadOnly();
    }

    /// <summary>
    /// Filters the in-memory store and returns all orders with the specified status.
    /// </summary>
    /// <param name="status">The <see cref="OrderStatus"/> to filter by.</param>
    /// <returns>
    /// A read-only list of <see cref="Order"/> objects whose <see cref="Order.Status"/>
    /// matches <paramref name="status"/>.
    /// </returns>
    public IReadOnlyList<Order> GetByStatus(OrderStatus status)
    {
        return _orders.Values
            .Where(o => o.Status == status)
            .ToList()
            .AsReadOnly();
    }

    /// <summary>
    /// Replaces the stored order entry with the supplied updated order, matched by ID.
    /// </summary>
    /// <param name="order">The updated order. An entry with the same ID must already exist.</param>
    /// <exception cref="KeyNotFoundException">
    /// Thrown when no order with the given <see cref="Order.Id"/> is found.
    /// </exception>
    public void Update(Order order)
    {
        if (!_orders.ContainsKey(order.Id))
            throw new KeyNotFoundException($"Order with ID {order.Id} was not found.");

        _orders[order.Id] = order;
    }

    /// <summary>
    /// Removes the order with the specified identifier from the in-memory store.
    /// </summary>
    /// <param name="id">The <see cref="Guid"/> of the order to delete.</param>
    /// <exception cref="KeyNotFoundException">
    /// Thrown when no order with the given ID is found.
    /// </exception>
    public void Delete(Guid id)
    {
        if (!_orders.Remove(id))
            throw new KeyNotFoundException($"Order with ID {id} was not found.");
    }
}
