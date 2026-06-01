using AutoService.Common.Models;
using AutoService.Common.Services;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("=== Лабораторна робота №2 ===");
Console.WriteLine("Багатопотоковість. Асинхронність. LINQ.");
Console.WriteLine();

var service = new CrudServiceAsync<Car>("cars.json");

object locker = new object();
int count = 0;

// приклад lock + Parallel.For
Parallel.For(0, 1000, i =>
{
    var car = Car.CreateNew();

    service.CreateAsync(car).GetAwaiter().GetResult();

    lock (locker)
    {
        count++;
    }
});

Console.WriteLine($"Створено автомобілів: {count}");

var cars = (await service.ReadAllAsync()).ToList();

Console.WriteLine();
Console.WriteLine("LINQ аналіз пробігу:");
Console.WriteLine($"Мінімальний пробіг: {cars.Min(x => x.Mileage)} км");
Console.WriteLine($"Максимальний пробіг: {cars.Max(x => x.Mileage)} км");
Console.WriteLine($"Середній пробіг: {cars.Average(x => x.Mileage):F2} км");

Console.WriteLine();
Console.WriteLine("Приклад пагінації — перші 10 авто:");

var page = await service.ReadAllAsync(1, 10);

foreach (var car in page)
{
    Console.WriteLine(car.GetCarInfo());
}

// приклад SemaphoreSlim
var semaphore = new SemaphoreSlim(1, 1);
await semaphore.WaitAsync();
try
{
    Console.WriteLine();
    Console.WriteLine("SemaphoreSlim використано для синхронізації доступу.");
}
finally
{
    semaphore.Release();
}

// приклад AutoResetEvent
var autoResetEvent = new AutoResetEvent(false);

Task.Run(() =>
{
    Thread.Sleep(500);
    autoResetEvent.Set();
});

autoResetEvent.WaitOne();

Console.WriteLine("AutoResetEvent спрацював успішно.");

await service.SaveAsync();

Console.WriteLine();
Console.WriteLine("Колекцію збережено у файл cars.json");
Console.WriteLine("Лабораторна робота №2 виконана успішно.");