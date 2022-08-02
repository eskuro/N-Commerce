using Dominio.Entidades;
using IServicio.BaseDto;
using IServicios.Articulo.DTOs;
using System.Collections.Generic;

namespace IServicio.ListaPrecio.DTOs
{
	public class ListaPrecioDto : DtoBase
	{
		public string Descripcion { get; set; }

		public decimal PorcentajeGanancia { get; set; }

		public bool NecesitaAutorizacion { get; set; }

		public string AutorizacionStr => NecesitaAutorizacion ? "SI" : "NO";

		public string PorcentajeGananciaStr => (PorcentajeGanancia / 100m).ToString("P");
	}
}
