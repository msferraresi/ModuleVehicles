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
    public class EmpleadoController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var empleados = EmpleadoBL.ListarEmpleados();
            return View(empleados);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Empleado empleado)
        {
            try
            {
                if (!ValidateData(empleado))
                {
                    return View(empleado);
                }

                EmpleadoBL.Agregar(empleado);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(empleado);
            }
        }

        [HttpGet]
        public ActionResult Detalle(int id)
        {
            var empleado = EmpleadoBL.Detalle(id);
            return View(empleado);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var empleado = EmpleadoBL.Detalle(id);
            return View(empleado);
        }

        [HttpPost]
        public ActionResult Editar(Empleado empleado)
        {
            try
            {
                if (!ValidateData(empleado))
                {
                    return View(empleado);
                }

                EmpleadoBL.Editar(empleado);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(empleado);
            }

        }

        [HttpGet]
        public ActionResult Borrar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var empleado = EmpleadoBL.Detalle(id.Value);
            return View(empleado);
        }

        [HttpPost]
        public ActionResult Borrar(int id)
        {
            try
            {
                EmpleadoBL.Borrar(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        private bool ValidateData(Empleado empleado)
        {
            if (empleado.DNI <= 0)
            {
                ModelState.AddModelError("", "Debe ingresar el DNI");
                return false;
            }
            if (empleado.Nombre == null)
            {
                ModelState.AddModelError("", "Debe ingresar el Nombre");
                return false;
            }
            if (empleado.Apellido == null)
            {
                ModelState.AddModelError("", "Debe ingresar el Apellido");
                return false;
            }
            if (empleado.IdEstado == null)
            {
                ModelState.AddModelError("", "Debe ingresar el estado");
                return false;
            }

            return true;
        }

    }
}