using System.Collections.Generic;
namespace EF7Samurai.Domain
{
  public class Maker
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Sword> Swords { get; set; }
  }
}