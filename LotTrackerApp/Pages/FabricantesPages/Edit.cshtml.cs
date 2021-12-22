﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LotTrackerApp.Data.Contexts;
using LotTrackerApp.Data.Entities;

namespace LotTrackerApp.Pages.FabricantesPages
{
    public class EditModel : PageModel
    {
        private readonly LotTrackerApp.Data.Contexts.LoteTrackerDbContext _context;

        public EditModel(LotTrackerApp.Data.Contexts.LoteTrackerDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ProdutoFabricante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoFabricanteExists(ProdutoFabricante.Produto))
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

        private bool ProdutoFabricanteExists(string id)
        {
            return _context.ProdutoFabricante.Any(e => e.Produto == id);
        }
    }
}
