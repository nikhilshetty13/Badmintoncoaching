using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Badminton_coaching_website.Model;

namespace Badminton_coaching_website.Data
{
    public class Badminton_coaching_websiteContext : DbContext
    {
        public Badminton_coaching_websiteContext (DbContextOptions<Badminton_coaching_websiteContext> options)
            : base(options)
        {
        }

        public DbSet<Badminton_coaching_website.Model.Coaching>? Coaching { get; set; }
    }
}
