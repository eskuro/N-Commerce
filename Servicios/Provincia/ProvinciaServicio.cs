using System;
using IServicio.Provincia;
using IServicio.Provincia.DTOs;
using System.Collections.Generic;
using System.Linq;
using Dominio.UnidadDeTrabajo;
using IServicio.BaseDto;

namespace Servicios.Provincia
{
    public class ProvinciaServicio : IProvinciaServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public ProvinciaServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public void Eliminar(long id)
        {
            _unidadDeTrabajo.ProvinciaRepositorio.Eliminar(id);
            _unidadDeTrabajo.Commit();
        }

        public void Insertar(DtoBase dtoEntidad)
        {
            var dto = (ProvinciaDto) dtoEntidad;

            var entidad = new Dominio.Entidades.Provincia
            {
               
                Descripcion = dto.Descripcion, 
                EstaEliminado = false,
                
            };

            _unidadDeTrabajo.ProvinciaRepositorio.Insertar(entidad);
            _unidadDeTrabajo.Commit();
        }

        public void Modificar(DtoBase dtoEntidad)
        {
            var dto = (ProvinciaDto)dtoEntidad;

            var entidad = _unidadDeTrabajo.ProvinciaRepositorio.Obtener(dto.Id);

            if (entidad == null) throw new Exception("Ocurrio un Error al Obtener la Provincia");

            entidad.Descripcion = dto.Descripcion;

            _unidadDeTrabajo.ProvinciaRepositorio.Modificar(entidad);
            _unidadDeTrabajo.Commit();
        }

        public DtoBase Obtener(long id)
        {
            var entidad = _unidadDeTrabajo.ProvinciaRepositorio.Obtener(id);

            return new ProvinciaDto
            {
                Id = entidad.Id,
                Descripcion = entidad.Descripcion,
                Eliminado = entidad.EstaEliminado
            };
        }

        public IEnumerable<DtoBase> Obtener(string cadenaBuscar)
        {
            return _unidadDeTrabajo.ProvinciaRepositorio.Obtener(x=>x.Descripcion.Contains(cadenaBuscar))
                .Select(x => new ProvinciaDto
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    Eliminado = x.EstaEliminado
                })
                .OrderBy(x=>x.Descripcion)
                .ToList();
        }

        public bool VerificarSiExiste(string datoVerificar, long? entidadId = null)
        {
            return entidadId.HasValue
                ? _unidadDeTrabajo.LocalidadRepositorio.Obtener(x => !x.EstaEliminado
                                                                     && x.Id != entidadId.Value
                                                                     && x.Descripcion.Equals(datoVerificar,
                                                                         StringComparison.CurrentCultureIgnoreCase))
                    .Any()
                : _unidadDeTrabajo.LocalidadRepositorio.Obtener(x => !x.EstaEliminado
                                                                     && x.Descripcion.Equals(datoVerificar,
                                                                         StringComparison.CurrentCultureIgnoreCase))
                    .Any();
        }
    }
}
