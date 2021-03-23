using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using TarjetaDeCreditoMVC.Entidades.DTOs.Provincia;
using TarjetaDeCreditoMVC.Entidades.Entidades;
using TarjetaDeCreditoMVC.Entidades.ViewModels.Provincia;
using TarjetaDeCreditoMVC.Servicios.Servicios;
using TarjetaDeCreditoMVC.Servicios.Servicios.Facades;

namespace TarjetaDeCreditoMVC.Web.Controllers
{
    public class ProvinciaController : Controller
    {
        private readonly IServiciosProvincia _servicio;
        private readonly IMapper _mapper;

        public ProvinciaController(IServiciosProvincia servicio)
        {
            _servicio = servicio;
            _mapper = Mapeador.Mapeador.CrearMapper();

        }
        // GET: Provincia
        public ActionResult Index()
        {
            var listaDto = _servicio.GetLista();
            var listaVm = _mapper.Map<List<ProvinciaListViewModel>>(listaDto);
            return View(listaVm);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProvinciasEditViewModel provVm)
        {
            if (!ModelState.IsValid)
            {
                return View(provVm);
            }

            ProvinciaEditDto provDto = _mapper.Map<ProvinciaEditDto>(provVm);
            if (_servicio.Existe(provDto))
            {
                ModelState.AddModelError(string.Empty, "Registro existente");
                return View(provVm);
            }

            try
            {
                _servicio.Guardar(provDto);
                TempData["Msg"] = "Registro agregado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(provVm);
            }
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProvinciaEditDto ProvinciaDto = _servicio.GetProvinciaPorId(id);
            if (ProvinciaDto == null)
            {
                return HttpNotFound("Provincia inexistente");
            }

            ProvinciasEditViewModel ProvinciaVm = _mapper.Map<ProvinciasEditViewModel>(ProvinciaDto);
            return View(ProvinciaVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProvinciasEditViewModel ProvinciaVm)
        {
            try
            {
                ProvinciaVm = _mapper.Map<ProvinciasEditViewModel>(_servicio.GetProvinciaPorId(ProvinciaVm.ProvinciaId));

                _servicio.Borrar(ProvinciaVm.ProvinciaId);
                TempData["Msg"] = "Registro borrado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
                return View(ProvinciaVm);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProvinciaEditDto ProvinciaDto = _servicio.GetProvinciaPorId(id);
            ProvinciasEditViewModel ProvinciaVm = _mapper.Map<ProvinciasEditViewModel>(ProvinciaDto);
            return View(ProvinciaVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (ProvinciasEditViewModel ProvinciaVm)
        {
            if (!ModelState.IsValid)
            {
                return View(ProvinciaVm);
            }

            ProvinciaEditDto ProvinciaDto = _mapper.Map<ProvinciaEditDto>(ProvinciaVm);
            if (_servicio.Existe(ProvinciaDto))
            {
                ModelState.AddModelError(string.Empty, "Registro duplicado");
                return View(ProvinciaVm);
            }

            try
            {
                _servicio.Guardar(ProvinciaDto);
                TempData["Msg"] = "Registro modificado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(ProvinciaVm);
            }
        }
    }
}
