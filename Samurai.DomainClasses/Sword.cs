using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF7Samurai.Domain
{
  public class Sword
  {
    public int Id { get; set; }
    public int WeightGrams { get; set; }
    public int MakerId { get; set; }
    public Maker Maker { get; set; }
    public int SamuraId { get; set; }
  }
}
