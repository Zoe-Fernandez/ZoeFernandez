using AutoMapper;
using System;
using System.Collections.Generic;
using TarjetaDeCreditoMVC.Datos;
using TarjetaDeCreditoMVC.Datos.Repositorios;
using TarjetaDeCreditoMVC.Datos.Repositorios.Facades;
using TarjetaDeCreditoMVC.Entidades.DTOs.CarteraConsumo;
using TarjetaDeCreditoMVC.Entidades.Entidades;
using TarjetaDeCreditoMVC.Servicios.Servicios.Facades;

namespace TarjetaDeCreditoMVC.Servicios.Servicios
{
    public class ServiciosCarteraConsumo : IServiciosCarteraConsumo
    {
        private readonly IRepositorioCarterasConsumos _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServiciosCarteraConsumo(IRepositorioCarterasConsumos repositorio, IUnitOfWork unitOfWork)
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

        public bool Existe(CarteraConsumoEditDto cartera)
        {
            try
            {
                CarteraDeConsumo carteraDeConsumo = _mapper.Map<CarteraDeConsumo>(cartera);
                return _repositorio.Existe(carteraDeConsumo);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public List<CarteraConsumoListDto> GetLista()
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

        public void Guardar(CarteraConsumoEditDto cartera)
        {
            try
            {
                CarteraDeConsumo carteraDeConsumo = _mapper.Map<CarteraDeConsumo>(cartera);
                _repositorio.Guardar(carteraDeConsumo);
                _unitOfWork.Save();
                cartera.CarteraDeConsumoId = carteraDeConsumo.CarteraDeConsumoId;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }

        public CarteraConsumoEditDto GetCarteraPorId(int? id)
        {
            try
            {
                return _repositorio.GetCarteraPorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
