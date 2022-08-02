using Dominio;
using Dominio.UnidadDeTrabajo;
using IServicio.BaseDto;
using IServicios.Precio;
using IServicios.PrecioAct.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Servicios.Precio
{
	public class PrecioServicio : IPrecioServicio
	{
		private readonly IUnidadDeTrabajo _unidadDeTrabajo;

		public PrecioServicio(IUnidadDeTrabajo unidadDeTrabajo)
		{
			_unidadDeTrabajo = unidadDeTrabajo;
		}

		public void ActualizarPrecio(decimal valor, bool esPorcentaje, long?
											marcaId = null, long? rubroId = null,
								long? listaPrecioId = null, int? codigoDesde = null, int? codigoHasta
																			= null)
		{
			using (var tran = new TransactionScope())
			{
				try
				{
					Expression<Func<Dominio.Entidades.Articulo, bool>> filtro = x
				   => true;
					if (marcaId.HasValue)
					{
						filtro = filtro.And(x => x.MarcaId == marcaId.Value);
					}
					if (rubroId.HasValue)
					{
						filtro = filtro.And(x => x.RubroId == rubroId.Value);
					}
					if (codigoDesde.HasValue && codigoHasta.HasValue)
					{
						filtro = filtro.And(x => x.Codigo >= codigoDesde &&
					   x.Codigo <= codigoHasta);
					}
					var listaDeArticulosParaActualizar = _unidadDeTrabajo
					.ArticuloRepositorio.Obtener(filtro, "Precios");

					var listasPrecios = _unidadDeTrabajo.ListaPrecioRepositorio.Obtener();
					var fechaActual = DateTime.Now;
					foreach (var articulo in listaDeArticulosParaActualizar)
					{
						if (listaPrecioId.HasValue) // Solo voy a manejarme con un lista de Precios
						{
									var ultimoPrecioArticulo = articulo.Precios
									.FirstOrDefault(x => x.ListaPrecioId ==
								   listaPrecioId.Value
									&& x.FechaActualizacion <=
								   fechaActual
								   && x.FechaActualizacion ==
								   articulo.Precios.Where(p =>
									p.ListaPrecioId ==
								   listaPrecioId.Value
								   &&
								   x.FechaActualizacion <= fechaActual)
									.Max(f =>
								   f.FechaActualizacion));
									// Calcular Precio Costo
									var precioCosto = esPorcentaje
									 ? ultimoPrecioArticulo.PrecioCosto +
									(ultimoPrecioArticulo.PrecioCosto * (valor / 100m))
									 : ultimoPrecioArticulo.PrecioCosto + valor;
									var listaSeleccionada = listasPrecios
									.FirstOrDefault(x => x.Id ==
								   listaPrecioId.Value);
									var precioPublico = precioCosto + (precioCosto *
								   (listaSeleccionada.PorcentajeGanancia / 100m));
									var nuevoPrecio = new Dominio.Entidades.Precio
									{
										ArticuloId = articulo.Id,
										ListaPrecioId = listaPrecioId.Value, // Entra por parametro
	
										FechaActualizacion = fechaActual,
										PrecioCosto = precioCosto,
										PrecioPublico = precioPublico,
										EstaEliminado = false,
									};
									_unidadDeTrabajo.PrecioRepositorio.Insertar
								   (nuevoPrecio);
						}
						else // Van todas las listas de Precios
						{
							foreach (var lista in listasPrecios)
							{
								var ultimoPrecioArticulo = articulo.Precios
								.FirstOrDefault(x => x.ListaPrecioId ==
							   lista.Id
								&& x.FechaActualizacion
							   <= fechaActual
							   && x.FechaActualizacion
							   == articulo.Precios.Where(p =>
								p.ListaPrecioId
							   == lista.Id
							   &&
							   x.FechaActualizacion <= fechaActual)
								.Max(f =>
							   f.FechaActualizacion));
								// Calcular Precio Costo
								var precioCosto = esPorcentaje
								 ? ultimoPrecioArticulo.PrecioCosto +
								(ultimoPrecioArticulo.PrecioCosto * (valor / 100m))
								 : ultimoPrecioArticulo.PrecioCosto + valor;
								var precioPublico = precioCosto + (precioCosto *
							   (lista.PorcentajeGanancia / 100m));
								var nuevoPrecio = new Dominio.Entidades.Precio
								{
									ArticuloId = articulo.Id,
									ListaPrecioId = lista.Id, // Esta es la de	Foreach
	
									FechaActualizacion = fechaActual,
									PrecioCosto = precioCosto,
									PrecioPublico = precioPublico,
									EstaEliminado = false,
								};
								_unidadDeTrabajo.PrecioRepositorio.Insertar
							   (nuevoPrecio);
							}
						}
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

		public void Eliminar(long id)
		{
			var entidad = _unidadDeTrabajo.PrecioRepositorio.Obtener(id);
			_unidadDeTrabajo.PrecioRepositorio.Eliminar(entidad.Id);
			_unidadDeTrabajo.Commit();
		}

	
	
		public IEnumerable<PrecioDto> Obtener(long articuloId)
		{
			Expression<Func<Dominio.Entidades.Precio, bool>> filtro = p =>
			  p.ArticuloId == articuloId;

			var resultado = _unidadDeTrabajo.PrecioRepositorio.Obtener(filtro);

			return resultado.Select(x => new PrecioDto
			{
				ArticuloId = x.ArticuloId,
				ListaPrecioId = x.ListaPrecioId,
				FechaActualizacion = x.FechaActualizacion,
				PrecioCosto = x.PrecioCosto,
				PrecioPublico = x.PrecioPublico,

				
			
			}).ToList();
		}
	}	
}
