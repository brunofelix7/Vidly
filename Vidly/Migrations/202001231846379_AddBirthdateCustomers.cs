using System.Data.Entity.Migrations;

namespace Vidly.Migrations {

    public partial class AddBirthdateCustomers : DbMigration {

        public override void Up() {
            AddColumn("dbo.Customers", "Birthdate", c => c.DateTime());
        }

        public override void Down() {
            DropColumn("dbo.Customers", "Birthdate");
        }
    }
}
