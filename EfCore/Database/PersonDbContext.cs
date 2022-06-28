using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EfCore.Database;

public class PersonDbContext : DbContext
{
    public DbSet<Person> Personen { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer($"Server=localhost; Database=Person; uid=sa; pwd=Maiki1511#;");
    }
}