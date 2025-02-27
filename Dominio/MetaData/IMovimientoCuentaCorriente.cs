﻿using System;
using System.ComponentModel.DataAnnotations;
using Aplicacion.Constantes;

namespace Dominio.MetaData
{
    public interface IMovimientoCuentaCorriente
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long UsuarioId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long ClienteId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [StringLength(400, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DataType(DataType.Currency)]
        decimal Monto { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DataType(DataType.DateTime)]
        DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        TipoMovimiento TipoMovimiento { get; set; }
    }
}
