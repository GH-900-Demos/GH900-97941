// Entry point for My Amazing Console Application.
// Demonstrates usage of Customer, Order, OrderItem, OrderStatus, and InMemoryOrderRepository.
using MyAmazingConsole.Models;
using MyAmazingConsole.Repositories;

Console.WriteLine("Welcome to My Amazing Console Application!");
Console.WriteLine();

// --- 1. Create customers ---
var alice = new Customer("Alice", "Smith", "123 Maple Street");
var bob   = new Customer("Bob",   "Jones", "456 Oak Avenue");
Console.WriteLine($"Created customers: {alice.FirstName} {alice.LastName}, {bob.FirstName} {bob.LastName}");

// --- 2. Create orders and add items ---
var aliceOrder = new Order(alice);
aliceOrder.AddItem(new OrderItem("WIDGET-01", "Blue Widget",  2, 9.99m));
aliceOrder.AddItem(new OrderItem("GADGET-07", "Turbo Gadget", 1, 49.95m));

var bobOrder = new Order(bob);
bobOrder.AddItem(new OrderItem("WIDGET-01", "Blue Widget", 5, 9.99m));

Console.WriteLine($"\nAlice's order ({aliceOrder.Id}) total: {aliceOrder.TotalCost:C}");
Console.WriteLine($"Bob's order   ({bobOrder.Id}) total: {bobOrder.TotalCost:C}");

// --- 3. Persist orders in the repository ---
var repository = new InMemoryOrderRepository();
repository.Add(aliceOrder);
repository.Add(bobOrder);
Console.WriteLine($"\nAdded {repository.GetAll().Count} orders to the repository.");

// --- 4. Retrieve an order by ID ---
var retrieved = repository.GetById(aliceOrder.Id);
Console.WriteLine($"\nRetrieved by ID: order for {retrieved?.Customer.FirstName} {retrieved?.Customer.LastName}, status: {retrieved?.Status}");

// --- 5. Update order status ---
aliceOrder.UpdateStatus(OrderStatus.Shipped);
repository.Update(aliceOrder);
bobOrder.UpdateStatus(OrderStatus.Completed);
repository.Update(bobOrder);
Console.WriteLine($"\nUpdated statuses — Alice: {aliceOrder.Status}, Bob: {bobOrder.Status}");

// --- 6. Filter orders by status ---
var shippedOrders   = repository.GetByStatus(OrderStatus.Shipped);
var completedOrders = repository.GetByStatus(OrderStatus.Completed);
Console.WriteLine($"\nShipped orders: {shippedOrders.Count}, Completed orders: {completedOrders.Count}");

// --- 7. Remove an item from an order ---
aliceOrder.RemoveItem("WIDGET-01");
repository.Update(aliceOrder);
Console.WriteLine($"\nAlice's order after removing WIDGET-01 — items: {aliceOrder.Items.Count}, new total: {aliceOrder.TotalCost:C}");

// --- 8. Delete an order ---
repository.Delete(bobOrder.Id);
Console.WriteLine($"\nDeleted Bob's order. Repository now contains {repository.GetAll().Count} order(s).");

Console.WriteLine("\nDone.");

var sqlConnectionString="";