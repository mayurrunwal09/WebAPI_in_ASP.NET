using Microsoft.EntityFrameworkCore;
using webapi3.Model;

namespace webapi3.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MainDBContext _dbContext;

        public MovieRepository(MainDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> CreateMovie(Movie movie)
        {
            try
            {
                _dbContext.Movies.Add(movie);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteMovie(int id)
        {
            try
            {
                var movie = await _dbContext.Movies.FindAsync(id);
                if (movie != null)
                {
                    _dbContext.Movies.Remove(movie);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false; // Movie not found
            }
            catch
            {
                return false; // Error occurred during delete
            }
        }

        public IQueryable<Movie> GetAllMovies()
        {
            return _dbContext.Movies;
        }

        public async Task<Movie> GetMovieByID(int id)
        {
            return await _dbContext.Movies.FindAsync(id);
        }

        public async Task<Movie> GetMovieByName(string Name)
        {
            return await _dbContext.Movies.FirstOrDefaultAsync(m => m.Title == Name);
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> UpdateMovie(Movie movie)
        {
            try
            {
                _dbContext.Entry(movie).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false; // Error occurred during update
            }
        }
    }
}
