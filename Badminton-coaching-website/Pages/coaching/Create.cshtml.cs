using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Badminton_coaching_website.Data;
using Badminton_coaching_website.Model;

namespace Badminton_coaching_website.Pages.coaching
{
    public class CreateModel : PageModel
    {
        private readonly Badminton_coaching_website.Data.Badminton_coaching_websiteContext _context;

        public CreateModel(Badminton_coaching_website.Data.Badminton_coaching_websiteContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Coaching Coaching { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Coaching == null || Coaching == null)
            {
                return Page();
            }

            _context.Coaching.Add(Coaching);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
