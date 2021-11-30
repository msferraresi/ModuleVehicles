using LAYER_DATA;
using LAYER_ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAYER_BUSINESS
{
    public class MantenimientoBL
    {
        private static MantenimientoDL obj = new MantenimientoDL();
        public static List<Mantenimiento> ListarMantenimientos()
        {
            return obj.ListarMantenimientos();
        }
        public static void Agregar(Mantenimiento mantenimiento)
        {
            obj.Agregar(mantenimiento);
        }

        public static Mantenimiento Detalle(int id)
        {
            return obj.Detalle(id);
        }

        public static void Editar(Mantenimiento mantenimiento)
        {
            obj.Editar(mantenimiento);
        }

        public static void Borrar(int id)
        {
            obj.Borrar(id);
        }
    }
}
