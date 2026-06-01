using AutoService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoService.Infrastructure;

public class AutoServiceContext : DbContext
{
    public DbSet<ClientModel> Clients { get; set; }
    public DbSet<CarModel> Cars { get; set; }
    public DbSet<CarPassportModel> CarPassports { get; set; }
    public DbSet<MechanicModel> Mechanics { get; set; }
    public DbSet<RepairOrderModel> RepairOrders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=C:\\Users\\PC\\Desktop\\NUPP_NET_2025_301_TK_Berezniak_Lab\\AutoServiceBerezniak\\autoservice.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarModel>()
            .HasOne(c => c.Passport)
            .WithOne(p => p.Car)
            .HasForeignKey<CarPassportModel>(p => p.CarModelId);

        modelBuilder.Entity<ClientModel>()
            .HasMany(c => c.RepairOrders)
            .WithOne(r => r.Client);

        modelBuilder.Entity<CarModel>()
            .HasMany(c => c.RepairOrders)
            .WithOne(r => r.Car);

        modelBuilder.Entity<MechanicModel>()
            .HasMany(m => m.RepairOrders)
            .WithOne(r => r.Mechanic);
    }
}