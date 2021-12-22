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
    public class IndexModel : PageModel
    {
        private readonly LotTrackerApp.Data.Contexts.LoteTrackerDbContext _context;

        public IndexModel(LotTrackerApp.Data.Contexts.LoteTrackerDbContext context)
        {
            _context = context;
        }

        public IList<Produto> Produto { get;set; }

        public async Task OnGetAsync()
        {
            Produto = await _context.Produtos.ToListAsync();
        }
    }
}
