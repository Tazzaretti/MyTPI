using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using Service.Iservices;

namespace Service.Service
{
    public class EnviosService : IEnviosService
    {
        private readonly eccomerceDBContext _dbContext;

        public EnviosService(eccomerceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Envios>> GetAllEnvios()
        {
            return await _dbContext.Envios.ToListAsync();
        }

        public async Task<Envios> GetEnvioById(int id)
        {
            return await _dbContext.Envios.FindAsync(id);
        }

        public async Task<Envios> CreateEnvio(Envios envio)
        {
            _dbContext.Envios.Add(envio);
            await _dbContext.SaveChangesAsync();
            return envio;
        }

        public async Task<Envios> UpdateEnvio(int id, Envios envio)
        {
            var existingEnvio = await _dbContext.Envios.FindAsync(id);
            if (existingEnvio != null)
            {
                existingEnvio.Destino = envio.Destino;
                existingEnvio.EstadoEnvio = envio.EstadoEnvio;
                existingEnvio.IdProducto = envio.IdProducto;
                existingEnvio.IdVenta = envio.IdVenta;
                await _dbContext.SaveChangesAsync();
            }
            return existingEnvio;
        }

        public async Task DeleteEnvio(int id)
        {
            var envio = await _dbContext.Envios.FindAsync(id);
            if (envio != null)
            {
                _dbContext.Envios.Remove(envio);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}