using Lab3.Model;
using Microsoft.EntityFrameworkCore;

namespace Lab3.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
             : base(options)
        {
        }


        public DbSet<Model.Route> Routes { get; set; } = default!;
        public DbSet<Stop> Stops { get; set; } = default!;
        public DbSet<StopSchedule> StopSchedule { get; set; } = default!;

    }
}
