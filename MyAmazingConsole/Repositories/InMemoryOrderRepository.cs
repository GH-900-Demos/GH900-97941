using MyAmazingConsole.Models;

namespace MyAmazingConsole.Repositories;

public class InMemoryOrderRepository : IOrderRepository
{
    private readonly Dictionary<Guid, Order> _orders = new();

    public void Add(Order order)
    {
        if (_orders.ContainsKey(order.Id))
            throw new InvalidOperationException($"An order with ID {order.Id} already exists.");

        _orders[order.Id] = order;
    }

    public Order? GetById(Guid id)
    {
        _orders.TryGetValue(id, out var order);
        return order;
    }

    public IReadOnlyList<Order> GetAll()
    {
        return _orders.Values.ToList().AsReadOnly();
    }

    public IReadOnlyList<Order> GetByStatus(OrderStatus status)
    {
        return _orders.Values
            .Where(o => o.Status == status)
            .ToList()
            .AsReadOnly();
    }

    public void Update(Order order)
    {
        if (!_orders.ContainsKey(order.Id))
            throw new KeyNotFoundException($"Order with ID {order.Id} was not found.");

        _orders[order.Id] = order;
    }

    public void Delete(Guid id)
    {
        if (!_orders.Remove(id))
            throw new KeyNotFoundException($"Order with ID {id} was not found.");
    }
}
