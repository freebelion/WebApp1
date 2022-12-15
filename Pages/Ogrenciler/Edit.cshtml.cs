using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp1.Data;
using WebApp1.Models;

namespace WebApp1.Pages.Ogrenciler
{
    public class EditModel : PageModel
    {
        private readonly WebApp1.Data.WebApp1Context _context;

        public EditModel(WebApp1.Data.WebApp1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Ogrenci Ogrenci { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Ogrenci == null)
            {
                return NotFound();
            }

            var ogrenci =  await _context.Ogrenci.FirstOrDefaultAsync(m => m.Id == id);
            if (ogrenci == null)
            {
                return NotFound();
            }
            Ogrenci = ogrenci;
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

            _context.Attach(Ogrenci).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OgrenciExists(Ogrenci.Id))
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

        private bool OgrenciExists(int id)
        {
          return (_context.Ogrenci?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
