using AutoService.Common.Extensions;
using AutoService.Common.Models;
using AutoService.Common.Services;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("=== Лабораторна робота №1 ===");
Console.WriteLine("Тема: Автосервіс");
Console.WriteLine();

// створення CRUD сервісу
var clientService = new CrudService<Client>();
var carService = new CrudService<Car>();
var mechanicService = new CrudService<Mechanic>();
var orderService = new CrudService<RepairOrder>();

// створення об'єктів
var client1 = new Client("Іван Петренко", "+380501112233", 30, "ivan@gmail.com");
var client2 = new Client("Олег Шевченко", "+380671234567", 25, "oleg@gmail.com");

var car1 = new Car("Toyota", "Camry", 2018, "BI1234AA");
var car2 = new Car("Volkswagen", "Golf", 2015, "BI5678BC");

var mechanic1 = new Mechanic("Андрій Коваль", "+380931112244", 40, "Двигуни", 12, 30000);
var mechanic2 = new Mechanic("Сергій Мельник", "+380991234321", 35, "Ходова частина", 8, 25000);

// додавання через CRUD
clientService.Create(client1);
clientService.Create(client2);
carService.Create(car1);
carService.Create(car2);
mechanicService.Create(mechanic1);
mechanicService.Create(mechanic2);

var order1 = new RepairOrder(client1, car1, mechanic1, "Заміна масла та фільтрів", 2500);
var order2 = new RepairOrder(client2, car2, mechanic2, "Ремонт підвіски", 6200);

// підписка на подію
order1.RepairStatusChanged += message =>
{
    Console.WriteLine($"ПОДІЯ: {message}");
};

orderService.Create(order1);
orderService.Create(order2);

Console.WriteLine("Список клієнтів:");
foreach (var client in clientService.ReadAll())
{
    Console.WriteLine(client.GetInfo());
}

Console.WriteLine();
Console.WriteLine("Список автомобілів:");
foreach (var car in carService.ReadAll())
{
    Console.WriteLine(car.GetCarInfo());
}

Console.WriteLine();
Console.WriteLine("Список механіків:");
foreach (var mechanic in mechanicService.ReadAll())
{
    Console.WriteLine(mechanic.GetInfo());
}

Console.WriteLine();
Console.WriteLine("Список замовлень:");
foreach (var order in orderService.ReadAll())
{
    Console.WriteLine(order.GetOrderInfo());
}

Console.WriteLine();
Console.WriteLine("Коротка інформація про замовлення через метод розширення:");
Console.WriteLine(order1.ToShortInfo());

Console.WriteLine();
Console.WriteLine("Завершення ремонту першого замовлення:");
order1.CompleteRepair();

Console.WriteLine();
Console.WriteLine("Оновлена інформація про перше замовлення:");
Console.WriteLine(order1.GetOrderInfo());

Console.WriteLine();
Console.WriteLine($"Кількість створених клієнтів: {Client.ClientsCount}");

Console.WriteLine();
Console.WriteLine("Видалення другого замовлення...");
orderService.Remove(order2);

Console.WriteLine();
Console.WriteLine("Замовлення після видалення:");
foreach (var order in orderService.ReadAll())
{
    Console.WriteLine(order.GetOrderInfo());
}

Console.WriteLine();
Console.WriteLine("Роботу програми завершено.");
