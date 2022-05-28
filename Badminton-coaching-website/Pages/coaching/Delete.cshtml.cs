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
    public class DeleteModel : PageModel
    {
        private readonly Badminton_coaching_website.Data.Badminton_coaching_websiteContext _context;

        public DeleteModel(Badminton_coaching_website.Data.Badminton_coaching_websiteContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Coaching Coaching { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Coaching == null)
            {
                return NotFound();
            }

            var coaching = await _context.Coaching.FirstOrDefaultAsync(m => m.Id == id);

            if (coaching == null)
            {
                return NotFound();
            }
            else 
            {
                Coaching = coaching;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Coaching == null)
            {
                return NotFound();
            }
            var coaching = await _context.Coaching.FindAsync(id);

            if (coaching != null)
            {
                Coaching = coaching;
                _context.Coaching.Remove(Coaching);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
