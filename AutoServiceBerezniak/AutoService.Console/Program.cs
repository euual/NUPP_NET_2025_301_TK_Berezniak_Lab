using AutoService.Infrastructure;
using AutoService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("=== Лабораторна робота №3 ===");
Console.WriteLine();

using var context = new AutoServiceContext();

Console.WriteLine("Шлях до БД:");
Console.WriteLine(context.Database.GetDbConnection().DataSource);

context.Database.EnsureCreated();

// якщо база порожня
if (!context.Clients.Any())
{
    var client = new ClientModel
    {
        FullName = "Іван Петренко",
        PhoneNumber = "+380501112233",
        Email = "ivan@gmail.com"
    };

    var mechanic = new MechanicModel
    {
        FullName = "Андрій Коваль",
        Specialization = "Двигун"
    };

    var car = new CarModel
    {
        Brand = "Toyota",
        Model = "Camry",
        Year = 2018
    };

    var passport = new CarPassportModel
    {
        PassportNumber = "AA123456",
        Car = car
    };

    var order = new RepairOrderModel
    {
        Description = "Заміна масла",
        Price = 2500,
        Client = client,
        Mechanic = mechanic,
        Car = car
    };

    context.Clients.Add(client);
    context.Mechanics.Add(mechanic);
    context.Cars.Add(car);
    context.CarPassports.Add(passport);
    context.RepairOrders.Add(order);

    context.SaveChanges();

    Console.WriteLine("Тестові дані додані у БД.");
}

Console.WriteLine();
Console.WriteLine("Список замовлень:");

foreach (var order in context.RepairOrders)
{
    Console.WriteLine($"{order.Description} - {order.Price} грн");
}

Console.WriteLine();
Console.WriteLine("База даних працює успішно.");