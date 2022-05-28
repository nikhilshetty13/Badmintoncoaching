using System.Collections.Generic;

namespace Badminton_coaching_website.Model
{
    public class Coaching
    {
        
         public int Id { get; set; }
        public string? Levels { get; set; }

        public DateTime Datestart { get; set; }
        
        public int Hours { get; set; }

        public string? Timings { get; set; }
    }
}
