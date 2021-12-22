using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LotTrackerApp.Data.Contexts;
using LotTrackerApp.Data.Entities;

namespace LotTrackerApp.Pages.PaisesPages
{
    public class DeleteModel : PageModel
    {
        private readonly LotTrackerApp.Data.Contexts.LoteTrackerDbContext _context;

        public DeleteModel(LotTrackerApp.Data.Contexts.LoteTrackerDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pais Paises { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Paises = await _context.Paises.FirstOrDefaultAsync(m => m.CodPais == id);

            if (Paises == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Paises = await _context.Paises.FindAsync(id);

            if (Paises != null)
            {
                _context.Paises.Remove(Paises);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
