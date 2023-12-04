using FirstWebApi.Models;

namespace FirstWebApi.Repository
{
    public interface IMovieRepository
    {
        IQueryable<Movie> GetAllMovies(); 
        Task<Movie> GetMovieById(int id);
        Task<Movie> GetMovieByMovieName(string movieName);
        Task<bool> CreateMovie(Movie movie);
        Task<bool> UpdateMovie(Movie movie);
        Task<bool> DeleteMovie(int id);
        Task Save(); 
    }
}
