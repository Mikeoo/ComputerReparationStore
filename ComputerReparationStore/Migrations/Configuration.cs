namespace ComputerReparationStore.Migrations
{
    using ComputerReparationStore.Models;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ComputerReparationStore.DAL.ReparationOrderContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ComputerReparationStore.DAL.ReparationOrderContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Customers.AddOrUpdate(x => x.Id,
                new Models.Customer() { FirstName = "Jane" },
                new Models.Customer() { FirstName = "Piet" },
                new Models.Customer() { FirstName = "Rowan" });

            context.ReparationOrders.AddOrUpdate(x => x.Id,
                new ReparationOrder()
                {                  
                    StartDate = new System.DateTime(2020, 07, 07),
                    EndDate = new System.DateTime(2020, 07, 12),
                    Status = Status.Awaiting,
                    Customer = context.Customers.FirstOrDefault(c => c.FirstName == "Rowan")
                },
                new ReparationOrder()
                {
                    StartDate = new System.DateTime(2020, 07, 07),
                    EndDate = new System.DateTime(2020, 07, 10),
                    Status = Status.Awaiting,
                    Customer = context.Customers.FirstOrDefault(c => c.FirstName == "Jane")
                }
                );

        }
    }
}