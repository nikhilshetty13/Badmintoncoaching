using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Badminton_coaching_website.Data;
using Badminton_coaching_website.Model;

namespace Badminton_coaching_website.Pages.coaching
{
    public class EditModel : PageModel
    {
        private readonly Badminton_coaching_website.Data.Badminton_coaching_websiteContext _context;

        public EditModel(Badminton_coaching_website.Data.Badminton_coaching_websiteContext context)
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

            var coaching =  await _context.Coaching.FirstOrDefaultAsync(m => m.Id == id);
            if (coaching == null)
            {
                return NotFound();
            }
            Coaching = coaching;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Coaching).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoachingExists(Coaching.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CoachingExists(int id)
        {
          return (_context.Coaching?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
