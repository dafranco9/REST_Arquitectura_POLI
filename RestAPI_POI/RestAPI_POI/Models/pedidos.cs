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
    
    public partial class pedidos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pedidos()
        {
            this.productos = new HashSet<productos>();
        }
    
        public int id_Pedido { get; set; }
        public int id_Producto { get; set; }
        public int id_Orden { get; set; }
        public int cantidad { get; set; }
        public double precioTotal { get; set; }
        public int ordenes_id_Orden { get; set; }
    
        public virtual ordenes ordenes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<productos> productos { get; set; }
    }
}