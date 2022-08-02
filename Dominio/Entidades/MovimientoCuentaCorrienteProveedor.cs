using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Aplicacion.Constantes;
using Dominio.MetaData;

namespace Dominio.Entidades
{
    [Table("Movimiento_CuentaCorrienteProveedor")]
    [MetadataType(typeof(IMovimientoCuentaCorrienteProveedor))]
    public class MovimientoCuentaCorrienteProveedor : EntidadBase
    {
        // Propiedades 
        public long ComprobanteId { get; set; }

        public long UsuarioId { get; set; }

        public long ProveedorId { get; set; }

        public string Descripcion { get; set; }

        public decimal Monto { get; set; }

        public DateTime Fecha { get; set; }

        public TipoMovimiento TipoMovimiento { get; set; }

        // Propiedades de Navegacion
        public virtual Proveedor Proveedor { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Comprobante Comprobante { get; set; }
    }
}
