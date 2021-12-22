using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LotTrackerApp.Data.Contexts;
using LotTrackerApp.Data.Entities;

namespace LotTrackerApp.Pages.FabricantesPages
{
    public class DeleteModel : PageModel
    {
        private readonly LotTrackerApp.Data.Contexts.LoteTrackerDbContext _context;

        public DeleteModel(LotTrackerApp.Data.Contexts.LoteTrackerDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProdutoFabricante ProdutoFabricante { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProdutoFabricante = await _context.ProdutoFabricante.FirstOrDefaultAsync(m => m.Produto == id);

            if (ProdutoFabricante == null)
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

            ProdutoFabricante = await _context.ProdutoFabricante.FindAsync(id);

            if (ProdutoFabricante != null)
            {
                _context.ProdutoFabricante.Remove(ProdutoFabricante);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
