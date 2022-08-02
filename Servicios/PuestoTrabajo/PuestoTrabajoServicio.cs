using Dominio.UnidadDeTrabajo;
using IServicio.BaseDto;
using IServicios.PuestoTrabajo;
using IServicios.PuestoTrabajo.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.PuestoTrabajo
{
	public class PuestoTrabajoServicio : IPuestoTrabajoServicio
	{
		private readonly IUnidadDeTrabajo _unidadDeTrabajo;

		public PuestoTrabajoServicio(IUnidadDeTrabajo unidadDeTrabajo)
		{
			_unidadDeTrabajo = unidadDeTrabajo;
		}

		public void Eliminar(long id)
		{
			_unidadDeTrabajo.PuestoTrabajoRepositorio.Eliminar(id);
			_unidadDeTrabajo.Commit();
		}

		public void Insertar(DtoBase dtoEntidad)
		{
			var dto = (PuestoTrabajoDto)dtoEntidad;

			var entidad = new Dominio.Entidades.PuestoTrabajo
			{
				Descripcion = dto.Descripcion,
				Codigo = dto.Codigo,
				EstaEliminado = false,
				
			};

			_unidadDeTrabajo.PuestoTrabajoRepositorio.Insertar(entidad);
			_unidadDeTrabajo.Commit();
		}

		public void Modificar(DtoBase dtoEntidad)
		{
			var dto = (PuestoTrabajoDto)dtoEntidad;

			var entidad = _unidadDeTrabajo.PuestoTrabajoRepositorio.Obtener(dto.Id);

			if (entidad == null) throw new Exception("Ocurrio un Error al Obtener El Puesto De Trabajo");

			entidad.Descripcion = dto.Descripcion;
			entidad.Codigo = dto.Codigo;

			_unidadDeTrabajo.PuestoTrabajoRepositorio.Modificar(entidad);
			_unidadDeTrabajo.Commit();
		}

		public DtoBase Obtener(long id)
		{
			var entidad = _unidadDeTrabajo.PuestoTrabajoRepositorio.Obtener(id);

			return new PuestoTrabajoDto
			{
				Id = entidad.Id,
				Descripcion = entidad.Descripcion,
				Codigo = entidad.Codigo,
				Eliminado = entidad.EstaEliminado
			};
		}

		public IEnumerable<DtoBase> Obtener(string cadenaBuscar)
		{
			return _unidadDeTrabajo.PuestoTrabajoRepositorio.Obtener(x => x.Descripcion.Contains(cadenaBuscar))
			   .Select(x => new PuestoTrabajoDto
			   {
				   Id = x.Id,
				   Descripcion = x.Descripcion,
				   Codigo = x.Codigo,
				   Eliminado = x.EstaEliminado
			   })
			   .OrderBy(x => x.Descripcion)
			   .ToList();
		}
	}
}
