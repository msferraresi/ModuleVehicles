//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LAYER_ENTITY
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vehiculo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehiculo()
        {
            this.Mantenimiento = new HashSet<Mantenimiento>();
        }
    
        public int IdVehiculo { get; set; }
        public string Patente { get; set; }
        public string NroChasis { get; set; }
        public string NroMotor { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int CantPuertas { get; set; }
        public string TipoVehiculo { get; set; }
        public string TipoCombustible { get; set; }
        public int Cilindrada { get; set; }
        public int IdEstado { get; set; }
    
        public virtual Estado Estado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mantenimiento> Mantenimiento { get; set; }
    }
}