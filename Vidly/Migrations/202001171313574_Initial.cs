using System.Data.Entity.Migrations;

namespace Vidly.Migrations {

    public partial class Initial : DbMigration {

        public override void Up() {
            CreateTable(
                "dbo.Customers",
                c => new {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Movies",
                c => new {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down() {
            DropTable("dbo.Movies");
            DropTable("dbo.Customers");
        }
    }
}
