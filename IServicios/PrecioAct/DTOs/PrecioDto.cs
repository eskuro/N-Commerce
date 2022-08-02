using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServicios.PrecioAct.DTOs
{
	public class PrecioDto
	{
		public long ArticuloId { get; set; }

		public long ListaPrecioId { get; set; }

		public decimal PrecioCosto { get; set; }

		public decimal PrecioPublico { get; set; }

		public DateTime FechaActualizacion { get; set; }
	}
}
