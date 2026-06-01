namespace AutoService.Common.Models;

// делегат
public delegate void RepairStatusChangedHandler(string message);

public class RepairOrder : BaseEntity
{
    public Client Client { get; set; }
    public Car Car { get; set; }
    public Mechanic Mechanic { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public bool IsCompleted { get; set; }

    // подія
    public event RepairStatusChangedHandler? RepairStatusChanged;

    // конструктор
    public RepairOrder(Client client, Car car, Mechanic mechanic, string description, decimal price)
    {
        Client = client;
        Car = car;
        Mechanic = mechanic;
        Description = description;
        Price = price;
        IsCompleted = false;
    }

    // метод
    public void CompleteRepair()
    {
        IsCompleted = true;
        Client.AddLoyaltyPoints(50);

        RepairStatusChanged?.Invoke($"Ремонт автомобіля {Car.Brand} {Car.Model} завершено.");
    }

    // метод
    public string GetOrderInfo()
    {
        string status = IsCompleted ? "Завершено" : "У процесі";
        return $"Замовлення: {Description}, авто: {Car.GetCarInfo()}, клієнт: {Client.FullName}, механік: {Mechanic.FullName}, ціна: {Price} грн, статус: {status}";
    }
}
