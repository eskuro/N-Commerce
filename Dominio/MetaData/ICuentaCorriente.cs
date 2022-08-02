using System.ComponentModel.DataAnnotations;
using Aplicacion.Constantes;

namespace Dominio.MetaData
{
    public interface ICuentaCorriente
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        long ClienteId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        Estado Estado { get; set; }

    }
}
