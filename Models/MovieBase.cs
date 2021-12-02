namespace MovieWebAppProject.Models
{
    public static class MovieBase
    {
        public static void InitData(MovieContext context)
        {
            var movieTitle = new[] { "All too Well", "Buggs Bunny", "Chariot", "Dickinson", "End Point" };
            var description = new[] { "Taylor Swift short movie", "Cartoon Animated short movie", "Random tragedy short movie", "poet biography short movie", "life expectancy short movie" };
            var duration = new[] { 13, 15, 17, 19, 21 };
            var artists = new[] { new[] { "Sadie Sink", "Taylor Swift" }, new [] { "Unknown", "Itself" }, new[] { "Himself", "Herself" }, new[] { "Hailee Steinfield", "Ella Hunt" }, new[] { "John Doe", "Jane Doe"} };
            var genres = new[] { new[] { "drama", "romance" }, new[] { "Comedy", "Animated", "Kids" }, new[] { "Thriller", "Horror" }, new[] { "Biography", "History", "Drama" }, new[] { "Drama", "Reality" } };

            context.SaveChanges();
        }
    }
}
