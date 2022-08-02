using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Aplicacion.Constantes;
using Dominio.MetaData;

namespace Dominio.Entidades
{
    [Table("Comprobante_CtaCte")]
    [MetadataType(typeof(ICuentaCorriente))]
    public class CuentaCorriente : Comprobante
    {
        // Propiedades 
        public long ClienteId { get; set; }

        public Estado Estado { get; set; }

        // Propiedades de Navegacion
        public virtual Cliente Cliente { get; set; }
    }
}
