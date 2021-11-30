using LAYER_DATA;
using LAYER_ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAYER_BUSINESS
{
    public class EmpleadoBL
    {
        private static EmpleadoDL obj = new EmpleadoDL();
        public static List<Empleado> ListarEmpleados()
        {
            return obj.ListarEmpleados();
        }

        public static void Agregar(Empleado empleado)
        {
            obj.Agregar(empleado);
        }

        public static Empleado Detalle(int id)
        {
            return obj.Detalle(id);
        }

        public static void Editar(Empleado empleado)
        {
            obj.Editar(empleado);
        }

        public static void Borrar(int id)
        {
            obj.Borrar(id);
        }
    }
}
