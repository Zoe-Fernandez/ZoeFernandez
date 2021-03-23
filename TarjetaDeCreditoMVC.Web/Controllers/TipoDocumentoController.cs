using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using TarjetaDeCreditoMVC.Entidades.DTOs.TipoDocumento;
using TarjetaDeCreditoMVC.Entidades.ViewModels.TipoDocumento;
using TarjetaDeCreditoMVC.Servicios.Servicios;
using TarjetaDeCreditoMVC.Servicios.Servicios.Facades;

namespace TarjetaDeCreditoMVC.Web.Controllers
{
    public class TipoDocumentoController : Controller
    {
        private readonly IServiciosTipoDocumento _servicio;
        private readonly IMapper _mapper;

        public TipoDocumentoController(IServiciosTipoDocumento servicio)
        {
            _servicio = servicio;
            _mapper = Mapeador.Mapeador.CrearMapper();

        }
        // GET: TipoDocumento
        public ActionResult Index()
        {
            var listaDto = _servicio.GetLista();
            var listaVm = _mapper.Map<List<TipoDocumentoListViewModel>>(listaDto);
            return View(listaVm);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoDocumentoEditViewModel tipoVm)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoVm);
            }
            TipoDocumentoEditDto tipoDto = _mapper.Map<TipoDocumentoEditDto>(tipoVm);
            if (_servicio.Existe(tipoDto))
            {
                ModelState.AddModelError(string.Empty, "Registro existente");
                return View(tipoVm);
            }

            try
            {
                _servicio.Guardar(tipoDto);
                TempData["Msg"] = "Registro agregado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(tipoVm);
            }
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TipoDocumentoEditDto DocumentoDto = _servicio.GetTipoDocumentoPorId(id);
            if (DocumentoDto == null)
            {
                return HttpNotFound("Tipo de documento inexistente");
            }

            TipoDocumentoEditViewModel DocumentoVm = _mapper.Map<TipoDocumentoEditViewModel>(DocumentoDto);
            return View(DocumentoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TipoDocumentoEditViewModel DocumentoVm)
        {
            try
            {
                DocumentoVm = _mapper.Map<TipoDocumentoEditViewModel>(_servicio.GetTipoDocumentoPorId(DocumentoVm.TipoDeDocumentoId));

                _servicio.Borrar(DocumentoVm.TipoDeDocumentoId);
                TempData["Msg"] = "Registro borrado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
                return View(DocumentoVm);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TipoDocumentoEditDto DocumentoDto = _servicio.GetTipoDocumentoPorId(id);
            TipoDocumentoEditViewModel DocumentoVm = _mapper.Map<TipoDocumentoEditViewModel>(DocumentoDto);
            return View(DocumentoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoDocumentoEditViewModel DocumentoVm)
        {
            if (!ModelState.IsValid)
            {
                return View(DocumentoVm);
            }

            TipoDocumentoEditDto DocumentoDto = _mapper.Map<TipoDocumentoEditDto>(DocumentoVm);
            if (_servicio.Existe(DocumentoDto))
            {
                ModelState.AddModelError(string.Empty, "Registro duplicado");
                return View(DocumentoVm);
            }

            try
            {
                _servicio.Guardar(DocumentoDto);
                TempData["Msg"] = "Registro modificado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(DocumentoVm);
            }
        }
    }
}