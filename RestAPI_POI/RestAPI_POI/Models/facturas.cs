//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestAPI_POI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class facturas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public facturas()
        {
            this.formas_pago = new HashSet<formas_pago>();
        }
    
        public int id_Facturas { get; set; }
        public int id_Orden { get; set; }
        public System.DateTime fecha { get; set; }
        public int numProductos { get; set; }
        public double valorPedido { get; set; }
        public int id_FormaPago { get; set; }
        public int ordenes_id_Orden { get; set; }
    
        public virtual ordenes ordenes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<formas_pago> formas_pago { get; set; }
    }
}
