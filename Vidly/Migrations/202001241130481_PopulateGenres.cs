using System.Data.Entity.Migrations;

namespace Vidly.Migrations {

    public partial class PopulateGenres : DbMigration {

        public override void Up() {
            Sql("INSERT INTO Genres(Id, Name) VALUES(1, 'Action')");
            Sql("INSERT INTO Genres(Id, Name) VALUES(2, 'Drama')");
            Sql("INSERT INTO Genres(Id, Name) VALUES(3, 'Horror')");
        }

        public override void Down() {

        }
    }
}
