using System.Data.Entity;
using Vidly.Models;

namespace Vidly.Database {

    public class MyDbContext : DbContext {

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public MyDbContext() {

        }
    }
}