using LAYER_DATA;
using LAYER_ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAYER_BUSINESS
{
    public class VehiculoBL
    {
        private static VehiculoDL obj = new VehiculoDL();
        public static List<Vehiculo> ListarVehiculos()
        {
            return obj.ListarVehiculos();
        }
        public static void Agregar(Vehiculo vehiculo)
        {
            obj.Agregar(vehiculo);
        }

        public static Vehiculo Detalle(int id)
        {
            return obj.Detalle(id);
        }

        public static void Editar(Vehiculo vehiculo)
        {
            obj.Editar(vehiculo);
        }

        public static void Borrar(int id)
        {
            obj.Borrar(id);
        }
    }
}
