using System.Collections.Generic;

namespace MarvelHeroesXF.Models
{
    public class Character
    {
        public string name { get; set; }
        public string personName { get; set; }
        public int age { get; set; }
        public double weight { get; set; }
        public double height { get; set; }
        public string universe { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public Ability ability { get; set; }
        public List<Movie> movies { get; set; }
    }
}
