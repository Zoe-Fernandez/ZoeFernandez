using AutoMapper;
using System;
using System.Collections.Generic;
using TarjetaDeCreditoMVC.Datos;
using TarjetaDeCreditoMVC.Datos.Repositorios;
using TarjetaDeCreditoMVC.Datos.Repositorios.Facades;
using TarjetaDeCreditoMVC.Entidades.DTOs.TipoDocumento;
using TarjetaDeCreditoMVC.Entidades.Entidades;
using TarjetaDeCreditoMVC.Servicios.Servicios.Facades;

namespace TarjetaDeCreditoMVC.Servicios.Servicios
{
    public class ServiciosTipoDocumento: IServiciosTipoDocumento
    {
        private readonly IRepositorioTipoDocumentos _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServiciosTipoDocumento(IRepositorioTipoDocumentos repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _mapper = Mapeador.Mapeador.CrearMapper();
            _unitOfWork = unitOfWork;
        }

        public void Borrar(int? id)
        {
            try
            {
                _repositorio.Borrar(id);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(TipoDocumentoEditDto tipoDocumento)
        {
            try
            {
                TipoDeDocumento tipo = _mapper.Map<TipoDeDocumento>(tipoDocumento);
                return _repositorio.Existe(tipo);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<TipoDocumentoListDto> GetLista()
        {
            try
            {
                return _repositorio.GetLista();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(TipoDocumentoEditDto tipoDocumento)
        {
            try
            {
                TipoDeDocumento documento = _mapper.Map<TipoDeDocumento>(tipoDocumento);
                _repositorio.Guardar(documento);
                _unitOfWork.Save();
                tipoDocumento.TipoDeDocumentoId = documento.TipoDeDocumentoId;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }

        public TipoDocumentoEditDto GetTipoDocumentoPorId(int? id)
        {
            try
            {
                return _repositorio.GetTipoPorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
