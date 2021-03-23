using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TarjetaDeCreditoMVC.Datos.Repositorios.Facades;
using TarjetaDeCreditoMVC.Entidades.DTOs.CarteraConsumo;
using TarjetaDeCreditoMVC.Entidades.Entidades;

namespace TarjetaDeCreditoMVC.Datos.Repositorios
{
    public class RepositorioCarteraConsumo : IRepositorioCarterasConsumos
    {
        private readonly TarjetasDeCreditoDbContext _context;
        private readonly IMapper _mapper;

        public RepositorioCarteraConsumo(TarjetasDeCreditoDbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }
        public void Borrar(int? id)
        {
            try
            {
                var carteraInDb = _context.CarteraDeConsumos.Find(id);
                _context.Entry(carteraInDb).State = EntityState.Deleted;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Error al borrar una cartera de consumo");
            }
        }

        public bool Existe(CarteraDeConsumo carteraDeConsumo)
        {
            if (carteraDeConsumo.CarteraDeConsumoId == 0)
            {
                return _context.CarteraDeConsumos.Any(cc => cc.Descripcion == carteraDeConsumo.Descripcion);
            }

            return _context.CarteraDeConsumos.Any(cc =>
                cc.Descripcion == carteraDeConsumo.Descripcion && cc.CarteraDeConsumoId == carteraDeConsumo.CarteraDeConsumoId);
        }

        public List<CarteraConsumoListDto> GetLista()
        {
            try
            {
                var lista = _context.CarteraDeConsumos.ToList();
                return _mapper.Map<List<CarteraConsumoListDto>>(lista);
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer las carteras de consumo");
            }
        }

        public CarteraConsumoEditDto GetCarteraPorId(int? id)
        {
            try
            {
                return _mapper
                    .Map<CarteraConsumoEditDto>(_context.CarteraDeConsumos
                        .SingleOrDefault(cc => cc.CarteraDeConsumoId == id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer una cartera de consumo");
            }
        }

        public void Guardar(CarteraDeConsumo carteraDeConsumo)
        {
            try
            {
                if (carteraDeConsumo.CarteraDeConsumoId == 0)
                {
                    _context.CarteraDeConsumos.Add(carteraDeConsumo);
                }
                else
                {
                    var carteraInDb = _context.CarteraDeConsumos
                        .SingleOrDefault(cc => cc.CarteraDeConsumoId == carteraDeConsumo.CarteraDeConsumoId);
                    carteraInDb.Descripcion = carteraDeConsumo.Descripcion;
                    carteraInDb.CostoDeRenovacion = carteraDeConsumo.CostoDeRenovacion;
                    carteraInDb.LimiteDeCredito = carteraDeConsumo.LimiteDeCredito;
                    _context.Entry(carteraInDb).State = EntityState.Modified;
                }

            }
            catch (Exception)
            {

                throw new Exception("Error al agregar/editar una cartera de consumo");
            }
        }

    }
}
