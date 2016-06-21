using System.Collections.Generic;
using System;

namespace EF7Samurai.Domain
{
    public class Battle
    {
    public Battle() {
      //is empty ctor still required by EF (would think so)
    }
    public Battle(string name, DateTime start,DateTime end) {
      Name = name;
      StartDate = start;
      EndDate = end;
     
    }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
       
        public Location Location { get; set; }
    public List<SamuraiBattle> SamuraiBattles { get; set; }


  }
}