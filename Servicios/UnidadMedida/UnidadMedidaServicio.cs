﻿using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.UnidadDeTrabajo;
using IServicio.BaseDto;
using IServicio.UnidadMedida.DTOs;
using IServicio.UnidadMedida;

namespace Servicios.UnidadMedida
{
    public class UnidadMedidaServicio : IUnidadMedidaServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public UnidadMedidaServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public void Eliminar(long id)
        {
            _unidadDeTrabajo.UnidadMedidaRepositorio.Eliminar(id);
            _unidadDeTrabajo.Commit();
        }

        public void Insertar(DtoBase dtoEntidad)
        {
            var dto = (UnidadMedidaDto)dtoEntidad;

            var entidad = new Dominio.Entidades.UnidadMedida
            {
                Descripcion = dto.Descripcion,
                EstaEliminado = false
            };

            _unidadDeTrabajo.UnidadMedidaRepositorio.Insertar(entidad);
            _unidadDeTrabajo.Commit();
        }

        public void Modificar(DtoBase dtoEntidad)
        {
            var dto = (UnidadMedidaDto)dtoEntidad;

            var entidad = _unidadDeTrabajo.UnidadMedidaRepositorio.Obtener(dto.Id);

            if (entidad == null) throw new Exception("Ocurrió un Error al Obtener la Unidad de Medida");

            entidad.Descripcion = dto.Descripcion;

            _unidadDeTrabajo.UnidadMedidaRepositorio.Modificar(entidad);
            _unidadDeTrabajo.Commit();
        }

        public DtoBase Obtener(long id)
        {
            var entidad = _unidadDeTrabajo.UnidadMedidaRepositorio.Obtener(id);

            return new UnidadMedidaDto
            {
                Id = entidad.Id,
                Descripcion = entidad.Descripcion,
                Eliminado = entidad.EstaEliminado
            };
        }

        public IEnumerable<DtoBase> Obtener(string cadenaBuscar)
        {
            return _unidadDeTrabajo.UnidadMedidaRepositorio.Obtener(x => x.Descripcion.Contains(cadenaBuscar))
                .Select(x => new UnidadMedidaDto
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    Eliminado = x.EstaEliminado
                })
                .OrderBy(x => x.Descripcion)
                .ToList();
        }

        public bool VerificarSiExiste(string datoVerificar, long? entidadId = null)
        {
            return entidadId.HasValue
                ? _unidadDeTrabajo.UnidadMedidaRepositorio.Obtener(x => !x.EstaEliminado
                                                                 && x.Id != entidadId.Value
                                                                 && x.Descripcion.Equals(datoVerificar,
                                                                     StringComparison.CurrentCultureIgnoreCase))
                    .Any()
                : _unidadDeTrabajo.UnidadMedidaRepositorio.Obtener(x => !x.EstaEliminado
                                                                        && x.Descripcion.Equals(datoVerificar,
                                                                            StringComparison.CurrentCultureIgnoreCase))
                    .Any();
        }
    }
}
