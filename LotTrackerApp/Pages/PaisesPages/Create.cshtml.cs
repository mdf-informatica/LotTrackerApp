using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LotTrackerApp.Data.Contexts;
using LotTrackerApp.Data.Entities;

namespace LotTrackerApp.Pages.PaisesPages
{
    public class CreateModel : PageModel
    {
        private readonly LotTrackerApp.Data.Repositories.PaisRepository _paisRepository;

        public CreateModel(LotTrackerApp.Data.Repositories.PaisRepository paisRepository)
        {
            _paisRepository = paisRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Pais Paises { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _paisRepository.AddAsync(Paises);
           

            return RedirectToPage("./Index");
        }
    }
}
