namespace AutoService.Infrastructure.Models;

public class ClientModel
{
    public string Email { get; set; }
    public int Id { get; set; }
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }

    public ICollection<RepairOrderModel> RepairOrders { get; set; } = new List<RepairOrderModel>();
}