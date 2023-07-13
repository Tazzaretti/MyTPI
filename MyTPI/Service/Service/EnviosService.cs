using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Model.DTOs;
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

        public List<EnvioDTOs> GetAllEnvios()
        {
            return _dbContext.Envios.Select(envio => new EnvioDTOs
            {
                IdEnvio = envio.IdEnvio,
                Destino = envio.Destino,
                EstadoEnvio = envio.EstadoEnvio,
                IdProducto = envio.IdProducto,
                IdVenta = envio.IdVenta
            }).ToList();
        }

        public EnvioDTOs GetEnvioById(int id)
        {
            var envio = _dbContext.Envios.Find(id);
            if (envio != null)
            {
                return new EnvioDTOs
                {
                    IdEnvio = envio.IdEnvio,
                    Destino = envio.Destino,
                    EstadoEnvio = envio.EstadoEnvio,
                    IdProducto = envio.IdProducto,
                    IdVenta = envio.IdVenta
                };
            }
            return null;
        }

        public EnvioDTOs CreateEnvio(EnvioDTOs envio)
        {
            var newEnvio = new Envios
            {
                Destino = envio.Destino,
                EstadoEnvio = envio.EstadoEnvio,
                IdProducto = envio.IdProducto,
                IdVenta = envio.IdVenta
            };

            _dbContext.Envios.Add(newEnvio);
            _dbContext.SaveChanges();

            envio.IdEnvio = newEnvio.IdEnvio;
            return envio;
        }

        public EnvioDTOs UpdateEnvio(int id, EnvioDTOs envio)
        {
            var existingEnvio = _dbContext.Envios.Find(id);
            if (existingEnvio != null)
            {
                existingEnvio.Destino = envio.Destino;
                existingEnvio.EstadoEnvio = envio.EstadoEnvio;
                existingEnvio.IdProducto = envio.IdProducto;
                existingEnvio.IdVenta = envio.IdVenta;
                _dbContext.SaveChanges();
           
                return new EnvioDTOs
                {
                    IdEnvio = existingEnvio.IdEnvio,
                    Destino = existingEnvio.Destino,
                    EstadoEnvio = existingEnvio.EstadoEnvio,
                    IdProducto = existingEnvio.IdProducto,
                    IdVenta = existingEnvio.IdVenta
                };
            }
            return null;
        }

        public void DeleteEnvio(int id)
        {
            var envio = _dbContext.Envios.Find(id);
            if (envio != null)
            {
                _dbContext.Envios.Remove(envio);
                _dbContext.SaveChanges();
            }
        }
    }
}