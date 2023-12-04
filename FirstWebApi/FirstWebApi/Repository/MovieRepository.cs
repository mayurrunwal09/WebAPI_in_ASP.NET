using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWebApi.Models;
using FirstWebApi.Models.Context;
using FirstWebApi.Repository;
using Microsoft.EntityFrameworkCore;

public class MovieRepository : IMovieRepository
{
        private readonly MovieDbContext _dbContext;

        public MovieRepository(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

    public IQueryable<Movie> GetAllMovies()
    {
        return _dbContext.Movies;
    }

    public async Task<Movie> GetMovieById(int id)
    {
        return await _dbContext.Movies.FindAsync(id);
    }

    public async Task<Movie> GetMovieByMovieName(string movieName)
    {
        return await _dbContext.Movies.FirstOrDefaultAsync(m => m.Moviename == movieName);
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


    public async Task Save()
    {
        await _dbContext.SaveChangesAsync();
    }
}
