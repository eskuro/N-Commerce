using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IServicio.BaseDto;
using IServicio.ListaPrecio.DTOs;

namespace IServicios.Articulo.DTOs
{
	public class PreciosDto
	{

		public decimal Precio { get; set; }

		public DateTime Fecha { get; set; }

		public string ListaPrecio { get; set; }
		
		public string PrecioStr => Precio.ToString("C");

		public string FechaStr => Fecha.ToShortDateString();
	}
}
