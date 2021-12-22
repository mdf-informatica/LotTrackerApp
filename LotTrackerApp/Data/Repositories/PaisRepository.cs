using LotTrackerApp.Data.Contexts;
using LotTrackerApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotTrackerApp.Data.Repositories
{
    public class PaisRepository
    {

        private readonly LoteTrackerDbContext _ctx;
        public PaisRepository(LoteTrackerDbContext ctx)
        {
            _ctx = ctx;
        }


        public Pais Add(string codpais, string desc)
        {
            var pais = new Pais
            {
                CodPais = codpais,
                Descricao = desc,

            };

            _ctx.Paises.Add(pais);
            _ctx.SaveChanges();

            return pais;
        }


        public async Task<Pais> AddAsync(string codpais, string desc)
        {
            var pais = new Pais
            {
                CodPais = codpais,
                Descricao = desc,

            };

            _ctx.Paises.Add(pais);
            try
            {
                await _ctx.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Erro a inserir na BD");
            }
            return pais;
        }


        public async Task<Pais> AddAsync(Pais pais)
        {
            _ctx.Paises.Add(pais);
            await _ctx.SaveChangesAsync();

            return pais;
        }

        public List<Pais> GetAll()
        {

            return _ctx.Paises.ToList();
        }
    }
}
