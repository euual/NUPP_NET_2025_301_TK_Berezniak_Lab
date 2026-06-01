namespace AutoService.Infrastructure.Models;

public class CarPassportModel
{
    public int Id { get; set; }
    public string PassportNumber { get; set; }

    public int CarModelId { get; set; }
    public CarModel Car { get; set; }
}