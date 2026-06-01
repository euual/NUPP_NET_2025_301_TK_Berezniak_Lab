namespace AutoService.Infrastructure.Models;

public class CarModel
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    public CarPassportModel Passport { get; set; }

    public ICollection<RepairOrderModel> RepairOrders { get; set; } = new List<RepairOrderModel>();
}