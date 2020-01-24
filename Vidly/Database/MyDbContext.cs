using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Vidly.Models;

namespace Vidly.Database {

    public class MyDbContext : DbContext {

        public MyDbContext() : base("MyContext") {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }

    }
}