using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Badminton_coaching_website.Data;
using Badminton_coaching_website.Model;

namespace Badminton_coaching_website.Pages.coaching
{
    public class IndexModel : PageModel
    {
        private readonly Badminton_coaching_website.Data.Badminton_coaching_websiteContext _context;

        public IndexModel(Badminton_coaching_website.Data.Badminton_coaching_websiteContext context)
        {
            _context = context;
        }

        public IList<Coaching> Coaching { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Coaching != null)
            {
                Coaching = await _context.Coaching.ToListAsync();
            }
        }
    }
}
