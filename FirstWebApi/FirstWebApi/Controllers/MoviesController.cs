using System.Linq;
using FirstWebApi.Models;
using FirstWebApi.Repository;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly IMovieRepository _movieRepository;

    public MoviesController(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    [HttpGet]
    public IActionResult GetAllMovies()
    {
        var movies = _movieRepository.GetAllMovies();
        return Ok(movies);
    }

    [HttpGet("{id}")]
    public IActionResult GetMovieById(int id)
    {
        var movie = _movieRepository.GetMovieById(id);
        if (movie == null)
        {
            return NotFound($"Movie with ID {id} not found.");
        }
        return Ok(movie);
    }

    [HttpGet("byname/{movieName}")]
    public IActionResult GetMovieByMovieName(string movieName)
    {
        var movie = _movieRepository.GetMovieByMovieName(movieName);
        if (movie == null)
        {
            return NotFound($"Movie with name {movieName} not found.");
        }
        return Ok(movie);
    }


    [HttpPost]
    public async Task<IActionResult> CreateMovie(Movie movie)
    {
        var success = await _movieRepository.CreateMovie(movie);
        if (success)
        {
            return CreatedAtAction(nameof(GetMovieById), new { id = movie.MovieId }, movie);
        }
        return BadRequest("Failed to create movie.");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMovie(int id, [FromBody] Movie updatedMovie)
    {
        if (id != updatedMovie.MovieId)
        {
            return BadRequest("Movie ID mismatch.");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var existingMovie = await _movieRepository.GetMovieById(id);
        if (existingMovie == null)
        {
            return NotFound($"Movie with ID {id} not found.");
        }

        existingMovie.Moviename = updatedMovie.Moviename;
        existingMovie.Releasedate = updatedMovie.Releasedate;
        existingMovie.DirectorName = updatedMovie.DirectorName;

        var success = await _movieRepository.UpdateMovie(existingMovie);
        if (success)
        {
            return NoContent();
        }

        return BadRequest("Failed to update movie.");
    }




    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMovie(int id)
    {
        var success = await _movieRepository.DeleteMovie(id);
        if (success)
        {
            return NoContent();
        }
        return NotFound($"Movie with ID {id} not found or failed to delete.");

    }

}
