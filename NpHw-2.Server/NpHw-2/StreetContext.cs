namespace NpHw_2
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StreetContext : DbContext
    {
        public StreetContext()
            : base("name=StreetContext")
        {
            Database.SetInitializer(new DataInitializer());
        }

        public DbSet<Street> Streets { get; set; }
    }
}