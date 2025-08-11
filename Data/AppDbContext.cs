using CRUD_FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_FilmesAPI.Data;

public class AppDbContext : DbContext
{
    public DbSet<Filmes> Filme { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Filme.Sqlite");
        base.OnConfiguring(optionsBuilder);
    }
}