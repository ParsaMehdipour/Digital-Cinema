using Domain.Entities.Casts;
using Domain.Entities.Cinemas;
using Domain.Entities.Cities;
using Domain.Entities.Genres;
using Domain.Entities.Halls;
using Domain.Entities.MovieCasts;
using Domain.Entities.MovieGenres;
using Domain.Entities.MoviePlays;
using Domain.Entities.Movies;
using Domain.Entities.States;
using Domain.Entities.Tickets;
using Domain.Entities.Trailers;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistence;


/// <remarks>
/// Add migrations using the following command inside the 'Persistence' project directory:
///
/// dotnet ef migrations add --startup-project WebApi --context ApplicationDdContext [migration-name]
/// </remarks>
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {

    }

    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {

    }

    public DbSet<Cast> Casts => Set<Cast>();
    public DbSet<Cinema> Cinemas => Set<Cinema>();
    public DbSet<City> Cities => Set<City>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<Hall> Halls => Set<Hall>();
    public DbSet<MovieCast> MovieCasts => Set<MovieCast>();
    public DbSet<MovieGenre> MovieGenres => Set<MovieGenre>();
    public DbSet<MoviePlay> MoviePlays => Set<MoviePlay>();
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<State> States => Set<State>();
    public DbSet<Ticket> Tickets => Set<Ticket>();
    public DbSet<Trailer> Trailers => Set<Trailer>();

    /// <summary>
    /// Apply entity configurations
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
