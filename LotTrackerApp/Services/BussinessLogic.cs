using LotTrackerApp.Data.Contexts;
using LotTrackerApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotTrackerApp.Services
{
    public class BussinessLogic

    {
        private readonly LoteTrackerDbContext _ctx;

        public BussinessLogic(LoteTrackerDbContext ctx)
        {
            _ctx = ctx;
        }

        public bool LoteCheck(ProdutoLote lot)
        {
            ProdutoFabricante fabs = new ProdutoFabricante();

            ProdutoFabricante fab =
               ( from f in _ctx.ProdutoFabricante
                where (f.Fabricante == lot.Fabricante && f.Produto == lot.Produto)
                select f).FirstOrDefault();

            if (fab.Pais.CodPais == "IT" || fab.Pais.CodPais == "ES" || fab.Pais.CodPais == "PT")  return true;

            return false;
        }
    }
}
