using LAYER_ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAYER_DATA
{
    public class VehiculoDL
    {
        public List<Vehiculo> ListarVehiculos()
        {
            using (var db = new VehiclesContext())
            {
                return db.Vehiculo.ToList();
            }
        }
        
        public void Agregar(Vehiculo obj)
        {
            using (var db = new VehiclesContext())
            {
                db.Vehiculo.Add(obj);
                db.SaveChanges();
            }
        }

        public Vehiculo Detalle(int id)
        {
            using (var db = new VehiclesContext())
            {
                return db.Vehiculo.Where(v => v.IdVehiculo == id).FirstOrDefault();
            }
        }

        public void Borrar(int id)
        {
            using (var db = new VehiclesContext())
            {
                var veh = db.Vehiculo.Where(v => v.IdVehiculo == id).FirstOrDefault();
                db.Vehiculo.Remove(veh);
                db.SaveChanges();
            }
        }

        public void Editar(Vehiculo obj)
        {
            using (var db = new VehiclesContext())
            {
                var veh = db.Vehiculo.Where(v => v.IdVehiculo == obj.IdVehiculo).FirstOrDefault();
                veh.Patente = obj.Patente;
                veh.NroChasis = obj.NroChasis;
                veh.NroMotor = obj.NroMotor;
                veh.Marca = obj.Marca;
                veh.Modelo = obj.Modelo;
                veh.CantPuertas = obj.CantPuertas;
                veh.TipoVehiculo = obj.TipoVehiculo;
                veh.TipoCombustible = obj.TipoCombustible;
                veh.Cilindrada = obj.Cilindrada;
                veh.IdEstado = obj.IdEstado;
                db.SaveChanges();
            }
        }
    }
}
