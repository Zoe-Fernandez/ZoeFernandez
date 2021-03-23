using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using TarjetaDeCreditoMVC.Entidades.DTOs.CarteraConsumo;
using TarjetaDeCreditoMVC.Entidades.ViewModels.CarteraConsumo;
using TarjetaDeCreditoMVC.Servicios.Servicios.Facades;

namespace TarjetaDeCreditoMVC.Web.Controllers
{
    public class CarteraConsumoController : Controller
    {
        private readonly IServiciosCarteraConsumo _servicio;
        private readonly IMapper _mapper;

        public CarteraConsumoController(IServiciosCarteraConsumo servicio)
        {
            _servicio = servicio;
            _mapper = Mapeador.Mapeador.CrearMapper();

        }
        // GET: CarteraConsumo
        public ActionResult Index()
        {
            var listaDto = _servicio.GetLista();
            var listaVm = _mapper.Map<List<CarteraConsumoListViewModel>>(listaDto);
            return View(listaVm);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarteraConsumoEditViewModel carteraVm)
        {
            if (!ModelState.IsValid)
            {
                return View(carteraVm);
            }

            CarteraConsumoEditDto carteraDto = _mapper.Map<CarteraConsumoEditDto>(carteraVm);
            if (_servicio.Existe(carteraDto))
            {
                ModelState.AddModelError(string.Empty, "Registro existente");
                return View(carteraVm);
            }

            try
            {
                _servicio.Guardar(carteraDto);
                TempData["Msg"] = "Registro agregado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(carteraVm);
            }
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

           CarteraConsumoEditDto carteraDto = _servicio.GetCarteraPorId(id);
            if (carteraDto == null)
            {
                return HttpNotFound("Cartera de consumo inexistente");
            }

            CarteraConsumoEditViewModel carteraVm = _mapper.Map<CarteraConsumoEditViewModel>(carteraDto);
            return View(carteraVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CarteraConsumoEditViewModel carteraVm)
        {
            try
            {
                carteraVm = _mapper.Map<CarteraConsumoEditViewModel>(_servicio.GetCarteraPorId(carteraVm.CarteraDeConsumoId));

                _servicio.Borrar(carteraVm.CarteraDeConsumoId);
                TempData["Msg"] = "Registro borrado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
                return View(carteraVm);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CarteraConsumoEditDto carteraDto = _servicio.GetCarteraPorId(id);
            CarteraConsumoEditViewModel carteraVm = _mapper.Map<CarteraConsumoEditViewModel>(carteraDto);
            return View(carteraVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CarteraConsumoEditViewModel carteraVm)
        {
            if (!ModelState.IsValid)
            {
                return View(carteraVm);
            }

            CarteraConsumoEditDto carteraDto = _mapper.Map<CarteraConsumoEditDto>(carteraVm);
            if (_servicio.Existe(carteraDto))
            {
                ModelState.AddModelError(string.Empty, "Registro duplicado");
                return View(carteraVm);
            }

            try
            {
                _servicio.Guardar(carteraDto);
                TempData["Msg"] = "Registro modificado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(carteraVm);
            }
        }
    }
}