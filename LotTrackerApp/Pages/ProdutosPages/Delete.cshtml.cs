using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LotTrackerApp.Data.Contexts;
using LotTrackerApp.Data.Entities;

namespace LotTrackerApp.Pages.ProdutosPages
{
    public class DeleteModel : PageModel
    {
        private readonly LotTrackerApp.Data.Contexts.LoteTrackerDbContext _context;

        public DeleteModel(LotTrackerApp.Data.Contexts.LoteTrackerDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Produto Produto { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Produto = await _context.Produtos.FirstOrDefaultAsync(m => m.CodProduto == id);

            if (Produto == null)
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

            Produto = await _context.Produtos.FindAsync(id);

            if (Produto != null)
            {
                _context.Produtos.Remove(Produto);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
