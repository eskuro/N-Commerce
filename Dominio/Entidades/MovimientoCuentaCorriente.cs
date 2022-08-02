using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Aplicacion.Constantes;
using Dominio.MetaData;

namespace Dominio.Entidades
{
    [Table("Movimiento_CuentaCorriente")]
    [MetadataType(typeof(IMovimientoCuentaCorriente))]
    public class MovimientoCuentaCorriente : EntidadBase
    {
        // Propiedades 
        public long ComprobanteId { get; set; }

        public long UsuarioId { get; set; }

        public long ClienteId { get; set; }

        public string Descripcion { get; set; }

        public decimal Monto { get; set; }

        public DateTime Fecha { get; set; }

        public TipoMovimiento TipoMovimiento { get; set; }

        // Propiedades de Navegacion
        public virtual Cliente Cliente { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Comprobante Comprobante { get; set; }
    }
}