namespace AutoService.Common.Models;

public class Car : BaseEntity
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string LicensePlate { get; set; }

    // конструктор
    public Car(string brand, string model, int year, string licensePlate)
    {
        Brand = brand;
        Model = model;
        Year = year;
        LicensePlate = licensePlate;
    }

    // статичний метод
    public static Car CreateDefaultCar()
    {
        return new Car("Невідомо", "Невідомо", 2000, "AA0000AA");
    }

    // метод
    public string GetCarInfo()
    {
        return $"{Brand} {Model}, {Year} рік, номер: {LicensePlate}";
    }
}
