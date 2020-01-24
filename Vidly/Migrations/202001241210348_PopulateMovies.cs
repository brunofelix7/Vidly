using System.Data.Entity.Migrations;

namespace Vidly.Migrations {

    public partial class PopulateMovies : DbMigration {

        public override void Up() {
            Sql("INSERT INTO Movies(Name, GenreId, DateAdded, ReleaseDate, NumberInStock, NumberAvailable) VALUES('Coringa', 2, '11-01-2019', '11-20-2019', 5, 5)");
            Sql("INSERT INTO Movies(Name, GenreId, DateAdded, ReleaseDate, NumberInStock, NumberAvailable) VALUES('Star Wars Episode IX', 1, '12-01-2019', '12-22-2019', 10, 5)");
            Sql("INSERT INTO Movies(Name, GenreId, DateAdded, ReleaseDate, NumberInStock, NumberAvailable) VALUES('Annabelle 3', 3, '10-01-2019', '10-15-2019', 7, 7)");
        }

        public override void Down() {

        }
    }
}
