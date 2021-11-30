using LAYER_ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAYER_DATA
{
    public class MantenimientoDL
    {
        public List<Mantenimiento> ListarMantenimientos()
        {
            using (var db = new VehiclesContext())
            {
                return db.Mantenimiento.ToList();
            }
        }

        public void Agregar(Mantenimiento obj)
        {
            using (var db = new VehiclesContext())
            {
                db.Mantenimiento.Add(obj);
                db.SaveChanges();
            }
        }

        public Mantenimiento Detalle(int id)
        {
            using (var db = new VehiclesContext())
            {
                return db.Mantenimiento.Where(m => m.IdMantenimiento == id).FirstOrDefault();
            }
        }

        public void Borrar(int id)
        {
            using (var db = new VehiclesContext())
            {
                var man = db.Mantenimiento.Where(m => m.IdMantenimiento == id).FirstOrDefault();
                db.Mantenimiento.Remove(man);
                db.SaveChanges();
            }
        }

        public void Editar(Mantenimiento obj)
        {
            using (var db = new VehiclesContext())
            {
                var man = db.Mantenimiento.Where(m => m.IdMantenimiento == obj.IdMantenimiento).FirstOrDefault();
                man.IdVehiculo = obj.IdVehiculo;
                man.Tarea = obj.Tarea;
                man.IdEmpleado = obj.IdEmpleado;
                man.Valor = obj.Valor;
                man.FechaIngreso = obj.FechaIngreso;
                man.FechaEstFin = obj.FechaEstFin;
                man.IsPago = obj.IsPago;
                db.SaveChanges();
            }
        }
    }
}
