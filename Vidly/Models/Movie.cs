namespace Vidly.Models {

    public class Movie {

        public int Id { get; set; }

        public string Name { get; set; }

        public Movie() {

        }

        public Movie(string name) {
            this.Name = name;
        }
    }
}