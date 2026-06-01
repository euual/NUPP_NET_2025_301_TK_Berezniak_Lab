using AutoService.Common.Models;

namespace AutoService.Common.Extensions;

public static class RepairOrderExtensions
{
    // метод розширення
    public static string ToShortInfo(this RepairOrder order)
    {
        return $"{order.Car.Brand} {order.Car.Model} — {order.Description}, {order.Price} грн";
    }
}
