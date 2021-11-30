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
    public class VehiculoController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var vehiculos = VehiculoBL.ListarVehiculos();
            return View(vehiculos);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Vehiculo vehiculo)
        {
            try
            {
                if (!ValidateData(vehiculo))
                {
                    return View(vehiculo);
                }

                VehiculoBL.Agregar(vehiculo);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(vehiculo);
            }
        }

        [HttpGet]
        public ActionResult Detalle(int id)
        {
            var vehiculo = VehiculoBL.Detalle(id);
            return View(vehiculo);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var vehiculo = VehiculoBL.Detalle(id);
            return View(vehiculo);
        }

        [HttpPost]
        public ActionResult Editar(Vehiculo vehiculo)
        {
            try
            {
                if (!ValidateData(vehiculo))
                {
                    return View(vehiculo);
                }

                VehiculoBL.Editar(vehiculo);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(vehiculo);
            }

        }

        [HttpGet]
        public ActionResult Borrar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var vehiculo = VehiculoBL.Detalle(id.Value);
            return View(vehiculo);
        }

        [HttpPost]
        public ActionResult Borrar(int id)
        {
            try
            {
                VehiculoBL.Borrar(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        private bool ValidateData(Vehiculo vehiculo)
        {

            if (vehiculo.Patente == null)
            {
                ModelState.AddModelError("", "Debe ingresar el Nombre");
                return false;
            }
            if (vehiculo.NroChasis == null)
            {
                ModelState.AddModelError("", "Debe ingresar el Apellido");
                return false;
            }
            if (vehiculo.NroMotor == null)
            {
                ModelState.AddModelError("", "Debe ingresar el Apellido");
                return false;
            }

            if (vehiculo.Marca == null)
            {
                ModelState.AddModelError("", "Debe ingresar el Apellido");
                return false;
            }
            if (vehiculo.Modelo == null)
            {
                ModelState.AddModelError("", "Debe ingresar el Apellido");
                return false;
            }

            if (vehiculo.CantPuertas <=0)
            {
                ModelState.AddModelError("", "Debe ingresar el Apellido");
                return false;
            }
            if (vehiculo.TipoVehiculo == null)
            {
                ModelState.AddModelError("", "Debe ingresar el Apellido");
                return false;
            }
            if (vehiculo.TipoCombustible == null)
            {
                ModelState.AddModelError("", "Debe ingresar el Apellido");
                return false;
            }

            if (vehiculo.Cilindrada <= 0)
            {
                ModelState.AddModelError("", "Debe ingresar el Apellido");
                return false;
            }
            if (vehiculo.IdEstado <= 0)
            {
                ModelState.AddModelError("", "Debe ingresar el estado");
                return false;
            }
                                 
            return true;
        }

    }
}