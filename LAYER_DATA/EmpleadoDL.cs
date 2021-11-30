using LAYER_ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAYER_DATA
{
    public class EmpleadoDL
    {
        public List<Empleado> ListarEmpleados()
        {
            using (var db = new VehiclesContext())
            {
                return db.Empleado.ToList();
            }
        }

        public void Agregar (Empleado empleado)
        {
            using (var db = new VehiclesContext())
            {
                db.Empleado.Add(empleado);
                db.SaveChanges();
            }
        }

        public Empleado Detalle(int id)
        {
            using (var db = new VehiclesContext())
            {
                return db.Empleado.Where(e => e.IdEmpleado == id).FirstOrDefault();         
            }
        }

        public void Borrar(int id)
        {
            using (var db = new VehiclesContext())
            {
                var emp = db.Empleado.Where(e => e.IdEmpleado == id).FirstOrDefault();
                db.Empleado.Remove(emp);
                db.SaveChanges();
            }
        }

        public void Editar(Empleado empleado)
        {
            using(var db = new VehiclesContext())
            {
                var emp = db.Empleado.Where(e => e.IdEmpleado == empleado.IdEmpleado).FirstOrDefault();
                emp.Nombre = empleado.Nombre;
                emp.Apellido = empleado.Apellido;
                emp.DNI = empleado.DNI;
                emp.IdEstado = empleado.IdEstado;
                db.SaveChanges();
            }
        }
    }
}
