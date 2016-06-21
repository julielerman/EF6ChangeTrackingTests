using EF6Samurai.Domain;
using System.Data.Entity;

namespace Samurais
{
  public class SamuraiContext : DbContext
  {
    public DbSet<Samurai> Samurais { get; set; }
  }
}