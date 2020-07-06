using ComputerReparationStore.Models;
using System.Data.Entity;

namespace ComputerReparationStore.DAL
{
    public class ReparationOrderContext : DbContext
    {
        public ReparationOrderContext() : base("DefaultConnection")
        {
        }

        public DbSet<ReparationOrder> ReparationOrders { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<ListAllParts> ListAllParts { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}