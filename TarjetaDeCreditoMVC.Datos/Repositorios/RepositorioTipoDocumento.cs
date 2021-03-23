using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TarjetaDeCreditoMVC.Datos.Repositorios.Facades;
using TarjetaDeCreditoMVC.Entidades.DTOs.TipoDocumento;
using TarjetaDeCreditoMVC.Entidades.Entidades;

namespace TarjetaDeCreditoMVC.Datos.Repositorios
{
    public class RepositorioTipoDocumento : IRepositorioTipoDocumentos
    {
        private readonly TarjetasDeCreditoDbContext _context;
        private readonly IMapper _mapper;

        public RepositorioTipoDocumento(TarjetasDeCreditoDbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }
        public void Borrar(int? id)
        {
            try
            {
                var tipoInDb = _context.TipoDeDocumentos
                    .SingleOrDefault(td => td.TipoDeDocumentoId == id);
                _context.Entry(tipoInDb).State = EntityState.Deleted;
            }
            catch (Exception e)
            {
                throw new Exception("Error al borrar un tipo de documento");
            }
        }

        public bool Existe(TipoDeDocumento tipoDeDocumento)
        {
            if (tipoDeDocumento.TipoDeDocumentoId == 0)
            {
                return _context.TipoDeDocumentos.Any(td => td.Descripcion == tipoDeDocumento.Descripcion);
            }

            return _context.TipoDeDocumentos.Any(td =>
                td.Descripcion == tipoDeDocumento.Descripcion && td.TipoDeDocumentoId == tipoDeDocumento.TipoDeDocumentoId);
        }

        public List<TipoDocumentoListDto> GetLista()
        {
            try
            {
                var lista = _context.TipoDeDocumentos.ToList();
                return _mapper.Map<List<TipoDocumentoListDto>>(lista);
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer los tipos de documentos");
            }
        }

        public TipoDocumentoEditDto GetTipoPorId(int? id)
        {
            try
            {
                return _mapper
                    .Map<TipoDocumentoEditDto>(_context.TipoDeDocumentos
                        .SingleOrDefault(td => td.TipoDeDocumentoId == id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer un tipo de documento");
            }
        }

        public void Guardar(TipoDeDocumento tipoDeDocumento)
        {
            try
            {
                if (tipoDeDocumento.TipoDeDocumentoId == 0)
                {
                    _context.TipoDeDocumentos.Add(tipoDeDocumento);
                }
                else
                {
                    var tipoInDb = _context.TipoDeDocumentos
                       .SingleOrDefault(td => td.TipoDeDocumentoId == tipoDeDocumento.TipoDeDocumentoId);
                    tipoInDb.Descripcion = tipoDeDocumento.Descripcion;
                    _context.Entry(tipoInDb).State = EntityState.Modified;
                }

                //_context.SaveChanges();

            }
            catch (Exception)
            {

                throw new Exception("Error al agregar/editar un tipo de documento");
            }
        }


    }
}
