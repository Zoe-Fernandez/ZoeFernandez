using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TarjetaDeCreditoMVC.Datos.Repositorios.Facades;
using TarjetaDeCreditoMVC.Entidades.DTOs.Provincia;
using TarjetaDeCreditoMVC.Entidades.Entidades;

namespace TarjetaDeCreditoMVC.Datos.Repositorios
{
    public class RepositorioProvincias : IRepositorioProvincias
    {
        private readonly TarjetasDeCreditoDbContext _context;
        private readonly IMapper _mapper;

        public RepositorioProvincias(TarjetasDeCreditoDbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }
        public void Borrar(int? id)
        {
            try
            {
                var provInDb = _context.Provincias
                    .SingleOrDefault(p => p.ProvinciaId == id);
                _context.Entry(provInDb).State = EntityState.Deleted;
            }
            catch (Exception e)
            {
                throw new Exception("Error al borrar una provincia");
            }
        }

        public bool Existe(Provincia provincia)
        {
            if (provincia.ProvinciaId == 0)
            {
                return _context.Provincias.Any(p => p.NombreProvincia == provincia.NombreProvincia);
            }

            return _context.Provincias.Any(p =>
                p.NombreProvincia == provincia.NombreProvincia && p.ProvinciaId == provincia.ProvinciaId);
        }

        public List<ProvinciaListDto> GetLista()
        {
            try
            {
                var lista = _context.Provincias.ToList();
                return _mapper.Map<List<ProvinciaListDto>>(lista);
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer las provincias");
            }
        }
        public void Guardar(Provincia provincia)
        {
            try
            {
                if (provincia.ProvinciaId == 0)
                {
                    _context.Provincias.Add(provincia);
                }
                else
                {
                    var provInDb = _context.Provincias
                        .SingleOrDefault(p => p.ProvinciaId == provincia.ProvinciaId);
                    provInDb.NombreProvincia = provincia.NombreProvincia;
                    _context.Entry(provInDb).State = EntityState.Modified;
                }

                //_context.SaveChanges();

            }
            catch (Exception)
            {

                throw new Exception("Error al agregar/editar una provincia");
            }
        }

        public ProvinciaEditDto GetProvinciaPorId(int? id)
        {
            try
            {
                return _mapper
                    .Map<ProvinciaEditDto>(_context.Provincias
                        .SingleOrDefault(p => p.ProvinciaId == id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer una provincia");
            }
        }
    }
}
