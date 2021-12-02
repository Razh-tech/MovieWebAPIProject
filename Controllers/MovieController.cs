using Microsoft.AspNetCore.Mvc;
using MovieWebAppProject.Models;

namespace MovieWebAppProject.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class MovieController : ControllerBase
    {
        private readonly MovieContext _context;

        public MovieController(MovieContext context)
        {
            _context = context;

            if (_context.Movies.Any()) return;

            MovieBase.InitData(context);
        }

        // Movie List API
        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IQueryable<Movie>> GetMovie()
        {
            var result = _context.Movies as IQueryable<Movie>;

            return Ok(result
                .OrderBy(m => m.MovieTitle));
        }

        // Movie Search API
        [HttpGet]
        [Route("{movieTitle}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Movie> GetMovieByMovieTitle([FromRoute] string movieTitle)
        {
            var movieDb = _context.Movies
                .FirstOrDefault(m => m.MovieTitle.Equals(movieTitle, StringComparison.InvariantCultureIgnoreCase));

            if (movieDb != null) return NotFound();

            return Ok(movieDb);
        }

        // Movie Upload API
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Movie> PostMovie([FromBody] Movie movie)
        {
            try
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();

                return new CreatedResult($"/movie/{movie.MovieTitle}", movie);
            }
            catch (Exception e)
            {
                return ValidationProblem(e.Message);
            }
        }

        // Movie Update API
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Movie> PutMovie([FromBody] Movie movie)
        {
            try
            {
                var movieDb = _context.Movies
                    .FirstOrDefault(m => m.MovieTitle.Equals(movie.MovieTitle, StringComparison.InvariantCultureIgnoreCase));

                if (movieDb == null) return NotFound();

                movieDb.MovieTitle = movie.MovieTitle;
                movieDb.Description = movie.Description;
                movieDb.Duration = movie.Duration;
                movieDb.Artists = movie.Artists;
                movieDb.Genres = movie.Genres;
                _context.SaveChanges();

                return Ok(movie);
            }
            catch (Exception e)
            {
                return ValidationProblem(e.Message);
            }
        }
    }
}
