# GH900-97941 — My Amazing Console Application

A demonstration project built for the **GH-900 course**. It models a simple order-management
domain (customers, orders, and order items) and shows how to design clean C# class libraries with
XML documentation, repository-pattern data access, and xUnit unit tests.

---

## Goal

The goal of this project is to demonstrate:

- Domain modelling with plain C# classes and enums (`Customer`, `Order`, `OrderItem`, `OrderStatus`)
- The **Repository Pattern** through a well-defined interface (`IOrderRepository`) and an
  in-memory implementation (`InMemoryOrderRepository`)
- XML documentation comments on every public API so that IDEs and documentation generators can
  produce rich, accurate help text
- Unit testing with **xUnit** to guard business rules (e.g. negative quantities are rejected)

---

## Project Structure

```marmaid
graph TD
    root["GH900-97941/"]
    slnx["MyAmazingApp.slnx"]
    console["MyAmazingConsole/"]
    program["Program.cs"]
    models["Models/"]
    customer["Customer.cs"]
    order["Order.cs"]
    orderitem["OrderItem.cs"]
    orderstatus["OrderStatus.cs"]
    repos["Repositories/"]
    iorderrepo["IOrderRepository.cs"]
    inmemrepo["InMemoryOrderRepository.cs"]
    tests["MyAmazingConsole.Tests/"]
    unittest["UnitTest1.cs"]

    root --> slnx
    root --> console
    root --> tests

    console --> program
    console --> models
    console --> repos

    models --> customer
    models --> order
    models --> orderitem
    models --> orderstatus

    repos --> iorderrepo
    repos --> inmemrepo

    tests --> unittest
```

---

## How to Use

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download) or later

### Build

```bash
dotnet build MyAmazingApp.slnx
```

### Run the console application

```bash
dotnet run --project MyAmazingConsole
```

### Run the tests

```bash
dotnet test MyAmazingApp.slnx
```

---

## Key Concepts

| Type | Description |
|---|---|
| `Customer` | Stores a customer's first name, last name, and delivery address. |
| `Order` | Aggregates `OrderItem` objects for a single customer; tracks total cost and status. |
| `OrderItem` | A product line with a SKU code, description, quantity (≥ 0), and unit cost. |
| `OrderStatus` | Enum with values `Created`, `Completed`, `Shipped`, and `Closed`. |
| `IOrderRepository` | Interface for CRUD operations on `Order` objects. |
| `InMemoryOrderRepository` | Dictionary-backed implementation of `IOrderRepository`; ideal for tests and demos. |
