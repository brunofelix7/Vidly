using System.Data.Entity.Migrations;

namespace Vidly.Migrations {

    public partial class PopulateCustomers : DbMigration {
        public override void Up() {
            Sql("INSERT INTO Customers (Name, IsSubscribedToNewsletter, MembershipTypeId) VALUES ('Bruno Felix', 0, 1)");
            Sql("INSERT INTO Customers (Name, IsSubscribedToNewsletter, MembershipTypeId) VALUES ('Alexa Lins', 0, 2)");
        }

        public override void Down() {

        }
    }
}
