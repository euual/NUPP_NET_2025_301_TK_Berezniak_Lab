namespace AutoService.Infrastructure.Models;

public class RepairOrderModel
{
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    public int ClientModelId { get; set; }
    public ClientModel Client { get; set; }

    public int CarModelId { get; set; }
    public CarModel Car { get; set; }

    public int MechanicModelId { get; set; }
    public MechanicModel Mechanic { get; set; }
}