using IServicios.PrecioAct.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServicios.Precio
{
	public	interface IPrecioServicio 
	{

		void Eliminar(long id);

		IEnumerable<PrecioDto> Obtener(long articuloId);


		void ActualizarPrecio(decimal valor, bool esPorcentaje, long?
										   marcaId = null, long? rubroId = null,
							   long? listaPrecioId = null, int? codigoDesde = null, int? codigoHasta
																		   = null);
	}
}
