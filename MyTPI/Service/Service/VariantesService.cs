using System.Collections.Generic;
using System.Linq;
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

        public List<Variante> GetAllVariantes()
        {
            return _dbContext.Variante.ToList();
        }

        public Variante GetVarianteById(int id)
        {
            return _dbContext.Variante.Find(id);
        }

        public Variante CreateVariante(Variante variante)
        {
            _dbContext.Variante.Add(variante);
            _dbContext.SaveChanges();
            return variante;
        }

        public Variante UpdateVariante(int id, Variante variante)
        {
            var existingVariante = _dbContext.Variante.Find(id);
            if (existingVariante != null)
            {
                existingVariante.Color = variante.Color;
                existingVariante.Descripcion = variante.Descripcion;
                _dbContext.SaveChanges();
            }
            return existingVariante;
        }

        public void DeleteVariante(int id)
        {
            var variante = _dbContext.Variante.Find(id);
            if (variante != null)
            {
                _dbContext.Variante.Remove(variante);
                _dbContext.SaveChanges();
            }
        }
    }
}