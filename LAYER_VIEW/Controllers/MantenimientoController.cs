using LAYER_BUSINESS;
using LAYER_ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LAYER_VIEW.Controllers
{
    public class MantenimientoController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var servicios = MantenimientoBL.ListarMantenimientos();
            return View(servicios);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Mantenimiento mantenimiento)
        {
            try
            {
                if (!ValidateData(mantenimiento))
                {
                    return View(mantenimiento);
                }
                MantenimientoBL.Agregar(mantenimiento);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(mantenimiento);
            }
        }

        [HttpGet]
        public ActionResult Detalle(int id)
        {
            var mantenimiento = MantenimientoBL.Detalle(id);
            return View(mantenimiento);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var mantenimiento = MantenimientoBL.Detalle(id);
            return View(mantenimiento);
        }

        [HttpPost]
        public ActionResult Editar(Mantenimiento mantenimiento)
        {
            try
            {
                if (!ValidateData(mantenimiento))
                {
                    return View(mantenimiento);
                }

                MantenimientoBL.Editar(mantenimiento);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(mantenimiento);
            }

        }

        [HttpGet]
        public ActionResult Borrar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var empleado = MantenimientoBL.Detalle(id.Value);
            return View(empleado);
        }

        [HttpPost]
        public ActionResult Borrar(int id)
        {
            try
            {
                MantenimientoBL.Borrar(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        private bool ValidateData(Mantenimiento mantenimiento)
        {
            if (mantenimiento.IdVehiculo <= 0)
            {
                ModelState.AddModelError("", "Debe ingresar el Vehiculo");
                return false;
            }
            if (mantenimiento.Tarea == null)
            {
                ModelState.AddModelError("", "Debe ingresar la tarea a realizar");
                return false;
            }
            if (mantenimiento.IdEmpleado <= 0)
            {
                ModelState.AddModelError("", "Debe asignar un Empleado");
                return false;
            }
            if (mantenimiento.Valor <= 0)
            {
                ModelState.AddModelError("", "El valor no puede ser menor o igual a cero.");
                return false;
            }

            return true;
        }

    }
}