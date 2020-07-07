namespace ComputerReparationStore.Migrations
{
    using ComputerReparationStore.DAL;
    using ComputerReparationStore.Models;
    using System.Data.Entity.Migrations;

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
                new Models.Customer() { Id = 1, FirstName = "Jane" },
                new Models.Customer() { Id = 2, FirstName = "Piet" },
                new Models.Customer() { Id = 3, FirstName = "Jane" }
        );
            context.ReparationOrders.AddOrUpdate(x => x.Id,
                new ReparationOrder()
                {
                    StartDate = new System.DateTime(2020, 07, 07),
                    EndDate = new System.DateTime(2020, 07, 07),
                    Status = Status.Awaiting
                }
                );
        }
            
    }
}