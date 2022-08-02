using Dominio.UnidadDeTrabajo;
using IServicio.BaseDto;
using IServicios.BajaArticulo;
using IServicios.BajaArticulo.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Servicios.BajaArticulo
{
	public class BajaArticuloServicio : IBajaArticuloServicio
	{
		private readonly IUnidadDeTrabajo _unidadDeTrabajo;

		public BajaArticuloServicio(IUnidadDeTrabajo unidadDeTrabajo)
		{
			_unidadDeTrabajo = unidadDeTrabajo;
		}

		public void Eliminar(long id)
		{
			_unidadDeTrabajo.BajaArticuloRepositorio.Eliminar(id);
			_unidadDeTrabajo.Commit();
		}

		public void Insertar(DtoBase dtoEntidad)
		{
					var dto = (BajaArticuloDto)dtoEntidad;
					var entidad = new Dominio.Entidades.BajaArticulo
					{

						ArticuloId = dto.ArticuloId,
						EstaEliminado = false,
						Cantidad = dto.Cantidad,
						Observacion = dto.Observacion,
						MotivoBajaId = dto.MotivoBajaId,
						Fecha = dto.Fecha,
						Foto = dto.Foto
						
					};
			_unidadDeTrabajo.BajaArticuloRepositorio.Insertar(entidad);
			_unidadDeTrabajo.Commit();
		}

		public void Modificar(DtoBase dtoEntidad)
		{

			var dto = (BajaArticuloDto)dtoEntidad;

			var entidad = _unidadDeTrabajo.BajaArticuloRepositorio.Obtener(dto.Id);

			if (entidad == null) throw new Exception("Ocurrio un Error al Obtener la Marca");

			entidad.ArticuloId = dto.ArticuloId;
			entidad.Cantidad = dto.Cantidad;
			entidad.Fecha = dto.Fecha;
			entidad.MotivoBajaId = dto.MotivoBajaId;
			entidad.Observacion = dto.Observacion;
			entidad.Foto = dto.Foto;

			_unidadDeTrabajo.BajaArticuloRepositorio.Modificar(entidad);
			_unidadDeTrabajo.Commit();

		}

		public DtoBase Obtener(long id)
		{
			var entidad = _unidadDeTrabajo.BajaArticuloRepositorio.Obtener(id,"Articulo , MotivoBaja");

			return new BajaArticuloDto
			{
				Id = entidad.Id,
				Observacion = entidad.Observacion,
				Eliminado = entidad.EstaEliminado,
				Fecha = entidad.Fecha,
				MotivoBajaId = entidad.MotivoBajaId,
				ArticuloId = entidad.ArticuloId,
				Foto = entidad.Foto,
				
			};
		}

		public IEnumerable<DtoBase> Obtener(string cadenaBuscar)
		{
			Expression<Func<Dominio.Entidades.BajaArticulo, bool>> filtro = x =>
	!x.EstaEliminado && x.Articulo.Descripcion.Contains(cadenaBuscar)
	|| x.MotivoBaja.Descripcion.Contains(cadenaBuscar)
	|| x.Observacion.Contains(cadenaBuscar);

			var resultado = _unidadDeTrabajo.BajaArticuloRepositorio.Obtener(filtro, "Articulo, MotivoBaja");

			return resultado.Select(x => new BajaArticuloDto
			{
				Id = x.Id,
				ArticuloId = x.ArticuloId,
				Articulo = x.Articulo.Descripcion,
				MotivoBajaId = x.MotivoBajaId,
				MotivoBaja = x.MotivoBaja.Descripcion,
				Cantidad = x.Cantidad,
				Fecha = x.Fecha,
				Observacion = x.Observacion,
				Eliminado = x.EstaEliminado,
				Foto = x.Foto,


				
			}).ToList();
		}
	}
}
