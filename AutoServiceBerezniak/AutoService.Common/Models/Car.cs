
namespace AutoService.Common.Models;

public class Car : BaseEntity
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string LicensePlate { get; set; }
    public int Mileage { get; set; }

    private static readonly Random Random = new();

    public Car(string brand, string model, int year, string licensePlate, int mileage)
    {
        Brand = brand;
        Model = model;
        Year = year;
        LicensePlate = licensePlate;
        Mileage = mileage;
    }

    public static Car CreateNew()
    {
        string[] brands = { "Toyota", "BMW", "Audi", "Volkswagen", "Ford" };
        string[] models = { "Camry", "X5", "A6", "Golf", "Focus" };

        int index = Random.Next(brands.Length);

        return new Car(
            brands[index],
            models[index],
            Random.Next(2000, 2025),
            $"BI{Random.Next(1000, 9999)}AA",
            Random.Next(10000, 300000)
        );
    }

    public string GetCarInfo()
    {
        return $"{Brand} {Model}, {Year} рік, номер: {LicensePlate}, пробіг: {Mileage} км";
    }
}
