using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using Service.Iservices;

namespace Service.Service
{
    public class VariantesService : IVariantesService
    {
        private readonly eccomerceDBContext _dbContext;

        public VariantesService(eccomerceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Variante>> GetAllVariantes()
        {
            return await _dbContext.Variante.ToListAsync();
        }

        public async Task<Variante> GetVarianteById(int id)
        {
            return await _dbContext.Variante.FindAsync(id);
        }

        public async Task<Variante> CreateVariante(Variante variante)
        {
            _dbContext.Variante.Add(variante);
            await _dbContext.SaveChangesAsync();
            return variante;
        }

        public async Task<Variante> UpdateVariante(int id, Variante variante)
        {
            var existingVariante = await _dbContext.Variante.FindAsync(id);
            if (existingVariante != null)
            {
                existingVariante.Color = variante.Color;
                existingVariante.Descripcion = variante.Descripcion;
                await _dbContext.SaveChangesAsync();
            }
            return existingVariante;
        }

        public async Task DeleteVariante(int id)
        {
            var variante = await _dbContext.Variante.FindAsync(id);
            if (variante != null)
            {
                _dbContext.Variante.Remove(variante);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}