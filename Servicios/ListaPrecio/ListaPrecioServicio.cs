using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Dominio.UnidadDeTrabajo;
using IServicio.BaseDto;
using IServicio.ListaPrecio;
using IServicio.ListaPrecio.DTOs;

namespace Servicios.ListaPrecio
{
    public class ListaPrecioServicio : IListaPrecioServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public ListaPrecioServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public void Eliminar(long id)
        {
            _unidadDeTrabajo.ListaPrecioRepositorio.Eliminar(id);
            _unidadDeTrabajo.Commit();
        }

        public void Insertar(DtoBase dtoEntidad)
        {
            using (var tran = new TransactionScope())
            {
                try
                {
                    var dto = (ListaPrecioDto)dtoEntidad;

                    var entidad = new Dominio.Entidades.ListaPrecio
                    {
                        Descripcion = dto.Descripcion,
                        NecesitaAutorizacion = dto.NecesitaAutorizacion,
                        PorcentajeGanancia = dto.PorcentajeGanancia,
                        EstaEliminado = false
                    };

                    _unidadDeTrabajo.ListaPrecioRepositorio.Insertar(entidad);

                    var fechaActual = DateTime.Now;
                    var articulos = _unidadDeTrabajo.ArticuloRepositorio.Obtener(x=>!x.EstaEliminado,"Precios");
                    foreach ( var articulo in articulos)
                    {

                        var precioArticulo = articulo.Precios.FirstOrDefault(p => p.FechaActualizacion <= fechaActual
                        && p.FechaActualizacion == articulo.Precios.Where(pre => pre.FechaActualizacion <= fechaActual)
                        .Max(f => f.FechaActualizacion));
                        _unidadDeTrabajo.PrecioRepositorio.Insertar(new Dominio.Entidades.Precio
                        {
                            ArticuloId = articulo.Id,
                            ListaPrecioId = entidad.Id,
                            FechaActualizacion = fechaActual,
                            PrecioCosto = precioArticulo.PrecioCosto,
                            PrecioPublico = precioArticulo.PrecioCosto+(precioArticulo.PrecioCosto*(dto.PorcentajeGanancia/100m)),
                            EstaEliminado = false
                        });
                    }

                    _unidadDeTrabajo.Commit();

                    tran.Complete();
                }
                catch (Exception e)
                {
                    tran.Dispose();
                    throw new Exception(e.Message);
                }
            }

        }

        public void Modificar(DtoBase dtoEntidad)
        {
            var dto = (ListaPrecioDto)dtoEntidad;

            var entidad = _unidadDeTrabajo.ListaPrecioRepositorio.Obtener(dto.Id);

            if (entidad == null) throw new Exception("Ocurrio un Error al Obtener la ListaPrecio");

            entidad.Descripcion = dto.Descripcion;
            entidad.PorcentajeGanancia = dto.PorcentajeGanancia;
            entidad.NecesitaAutorizacion = dto.NecesitaAutorizacion;

            _unidadDeTrabajo.ListaPrecioRepositorio.Modificar(entidad);
            _unidadDeTrabajo.Commit();
        }

        public DtoBase Obtener(long id)
        {
            var entidad = _unidadDeTrabajo.ListaPrecioRepositorio.Obtener(id);

            return new ListaPrecioDto
            {
                Id = entidad.Id,
                Descripcion = entidad.Descripcion,
                NecesitaAutorizacion = entidad.NecesitaAutorizacion,
                PorcentajeGanancia = entidad.PorcentajeGanancia,
                Eliminado = entidad.EstaEliminado
            };
        }

        public IEnumerable<DtoBase> Obtener(string cadenaBuscar)
        {
            return _unidadDeTrabajo.ListaPrecioRepositorio.Obtener(x => x.Descripcion.Contains(cadenaBuscar))
                .Select(x => new ListaPrecioDto
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    NecesitaAutorizacion = x.NecesitaAutorizacion,
                    PorcentajeGanancia = x.PorcentajeGanancia,
                    Eliminado = x.EstaEliminado
                })
                .OrderBy(x => x.Descripcion)
                .ToList();
        }

        public bool VerificarSiExiste(string datoVerificar, long? entidadId = null)
        {
            return entidadId.HasValue
                ? _unidadDeTrabajo.ListaPrecioRepositorio.Obtener(x => !x.EstaEliminado
                                                                        && x.Id != entidadId.Value
                                                                        && x.Descripcion.Equals(datoVerificar,
                                                                            StringComparison.CurrentCultureIgnoreCase))
                    .Any()
                : _unidadDeTrabajo.ListaPrecioRepositorio.Obtener(x => !x.EstaEliminado
                                                                        && x.Descripcion.Equals(datoVerificar,
                                                                            StringComparison.CurrentCultureIgnoreCase))
                    .Any();
        }
    }
}
