using MyAmazingConsole.Models;

namespace MyAmazingConsole.Repositories;

/// <summary>
/// Defines the contract for persisting and retrieving <see cref="Order"/> objects.
/// Implementations may use any backing store (in-memory, database, file system, etc.).
/// </summary>
public interface IOrderRepository
{
    /// <summary>
    /// Adds a new order to the repository.
    /// </summary>
    /// <param name="order">The order to add. Its <see cref="Order.Id"/> must be unique within the repository.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown when an order with the same <see cref="Order.Id"/> already exists.
    /// </exception>
    void Add(Order order);

    /// <summary>
    /// Retrieves an order by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the order to retrieve.</param>
    /// <returns>
    /// The matching <see cref="Order"/>, or <c>null</c> if no order with that ID exists.
    /// </returns>
    Order? GetById(Guid id);

    /// <summary>
    /// Returns all orders currently held in the repository.
    /// </summary>
    /// <returns>A read-only list of all <see cref="Order"/> objects.</returns>
    IReadOnlyList<Order> GetAll();

    /// <summary>
    /// Returns all orders that match the specified <see cref="OrderStatus"/>.
    /// </summary>
    /// <param name="status">The status to filter by.</param>
    /// <returns>A read-only list of orders whose <see cref="Order.Status"/> equals <paramref name="status"/>.</returns>
    IReadOnlyList<Order> GetByStatus(OrderStatus status);

    /// <summary>
    /// Replaces the stored order with the updated version supplied.
    /// The order is matched by its <see cref="Order.Id"/>.
    /// </summary>
    /// <param name="order">The updated order. An order with the same ID must already exist.</param>
    /// <exception cref="KeyNotFoundException">
    /// Thrown when no order with the given ID is found in the repository.
    /// </exception>
    void Update(Order order);

    /// <summary>
    /// Permanently removes the order with the specified identifier from the repository.
    /// </summary>
    /// <param name="id">The unique identifier of the order to delete.</param>
    /// <exception cref="KeyNotFoundException">
    /// Thrown when no order with the given ID is found in the repository.
    /// </exception>
    void Delete(Guid id);
}
