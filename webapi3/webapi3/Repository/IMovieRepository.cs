using webapi3.Model;

namespace webapi3.Repository
{
    public interface IMovieRepository
    {
     public  IQueryable<Movie> GetAllMovies();
     public  Task<Movie> GetMovieByID(int id);
     public  Task<Movie> GetMovieByName(string Name);
     public  Task<bool> CreateMovie(Movie movie);
     public  Task<bool> UpdateMovie(Movie movie);
     public  Task<bool> DeleteMovie(int id);
     public  Task Save();
     
    }
}
