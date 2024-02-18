using Domain.Entities.Movies;
using Domain.Repositories.BaseRepositories;

namespace Domain.Repositories;
public interface IMovieRepository : IRepository<Movie>
{
}
