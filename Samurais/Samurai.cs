using System.Collections.Generic;

namespace EF6Samurai.Domain
{
  public class Samurai
  {
    public Samurai() {
      Quotes = new List<Quote>();
    }

    public int Id { get; set; }
    public string Name { get; set; }

    public List<Quote> Quotes { get; set; }
  }
}