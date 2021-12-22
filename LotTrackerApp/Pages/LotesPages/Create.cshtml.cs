using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LotTrackerApp.Data.Contexts;
using LotTrackerApp.Data.Entities;
using LotTrackerApp.Services;

namespace LotTrackerApp.Pages.LotesPages
{
    public class CreateModel : PageModel
    {
        private readonly LotTrackerApp.Data.Contexts.LoteTrackerDbContext _context;
        private readonly BussinessLogic _bs;

        public CreateModel(LotTrackerApp.Data.Contexts.LoteTrackerDbContext context, LotTrackerApp.Services.BussinessLogic bs )
        {
            _context = context;
            _bs = bs;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ProdutoLote ProdutoLote { get; set; }

        public string errorMsg = "";

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (_bs.LoteCheck(ProdutoLote))
            {

                errorMsg = "Error: Fabricante deste lote pertence a paises bloqueados!";
               

            }
            else
            {
                _context.ProdutoLote.Add(ProdutoLote);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
