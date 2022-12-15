﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp1.Data;
using WebApp1.Models;

namespace WebApp1.Pages.Ogrenciler
{
    public class DeleteModel : PageModel
    {
        private readonly WebApp1.Data.WebApp1Context _context;

        public DeleteModel(WebApp1.Data.WebApp1Context context)
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

            var ogrenci = await _context.Ogrenci.FirstOrDefaultAsync(m => m.Id == id);

            if (ogrenci == null)
            {
                return NotFound();
            }
            else 
            {
                Ogrenci = ogrenci;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Ogrenci == null)
            {
                return NotFound();
            }
            var ogrenci = await _context.Ogrenci.FindAsync(id);

            if (ogrenci != null)
            {
                Ogrenci = ogrenci;
                _context.Ogrenci.Remove(Ogrenci);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
