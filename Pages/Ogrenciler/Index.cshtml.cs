using System;
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
    public class IndexModel : PageModel
    {
        private readonly WebApp1.Data.WebApp1Context _context;

        public IndexModel(WebApp1.Data.WebApp1Context context)
        {
            _context = context;
        }

        public IList<Ogrenci> Ogrenci { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Ogrenci != null)
            {
                Ogrenci = await _context.Ogrenci.ToListAsync();
            }
        }
    }
}
