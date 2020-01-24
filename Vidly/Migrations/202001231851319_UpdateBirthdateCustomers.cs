using System.Data.Entity.Migrations;

namespace Vidly.Migrations {

    public partial class UpdateBirthdateCustomers : DbMigration {

        public override void Up() {
            Sql("UPDATE Customers SET Birthdate = '11/06/1989' WHERE Id = 1");
            Sql("UPDATE Customers SET Birthdate = '05/06/1997' WHERE Id = 2");
        }

        public override void Down() {

        }
    }
}
