using CoOp19.Dtb.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoOp19.Dtb
{
    public interface IDB19Context
    {
        DbSet<ConsumableResource> ConsumableResource { get; set; }
        DbSet<GenericResource> GenericResource { get; set; }
        DbSet<HealthResource> HealthResource { get; set; }
        DbSet<HealthResourceServices> HealthResourceServices { get; set; }
        DbSet<MapData> MapData { get; set; }
        DbSet<ShelterResource> ShelterResource { get; set; }
        DbSet<Users> Users { get; set; }
    }
}