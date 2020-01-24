using System.Data.Entity.Migrations;

namespace Vidly.Migrations {

    public partial class AddNameInMembershipTypes : DbMigration {

        public override void Up() {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String());
        }

        public override void Down() {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
