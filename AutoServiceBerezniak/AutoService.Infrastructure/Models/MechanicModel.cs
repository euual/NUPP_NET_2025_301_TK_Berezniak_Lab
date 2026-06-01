namespace AutoService.Infrastructure.Models;

public class MechanicModel
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Specialization { get; set; }

    public ICollection<RepairOrderModel> RepairOrders { get; set; } = new List<RepairOrderModel>();
}