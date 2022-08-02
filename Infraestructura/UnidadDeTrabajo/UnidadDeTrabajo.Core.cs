using Dominio.Entidades;
using Dominio.Repositorio;
using Infraestructura.Repositorio;

namespace Infraestructura.UnidadDeTrabajo
{
	public partial class UnidadDeTrabajo
	{
		// ============================================================================================================ //

		private IRepositorio<Proveedor> proveedorRepositorio;

		public IRepositorio<Proveedor> ProveedorRepositorio => proveedorRepositorio
															   ?? (proveedorRepositorio =
																   new Repositorio<Proveedor>(_context));

		// ============================================================================================================ //

		private IEmpleadoRepositorio empleadoRepositorio;

		public IEmpleadoRepositorio EmpleadoRepositorio => empleadoRepositorio
														   ?? (empleadoRepositorio =
															   new EmpleadoRepositorio(_context));

		// ============================================================================================================ //

		private IClienteRepositorio clienteRepositorio;

		public IClienteRepositorio ClienteRepositorio => clienteRepositorio
														 ?? (clienteRepositorio =
															 new ClienteRepositorio(_context));

		// ============================================================================================================ //

		private IRepositorio<Configuracion> configuracionRepositorio;

		public IRepositorio<Configuracion> ConfiguracionRepositorio => configuracionRepositorio
																	   ?? (configuracionRepositorio =
																		   new Repositorio<Configuracion>(_context));

		// ============================================================================================================ //

		private IRepositorio<ListaPrecio> listaPrecioRepositorio;

		public IRepositorio<ListaPrecio> ListaPrecioRepositorio => listaPrecioRepositorio
																   ?? (listaPrecioRepositorio =
																	   new Repositorio<ListaPrecio>(_context));

		// ============================================================================================================ //

		private IRepositorio<Articulo> articuloRepositorio;

		public IRepositorio<Articulo> ArticuloRepositorio => articuloRepositorio
															 ?? (articuloRepositorio =
																 new Repositorio<Articulo>(_context));

		// ============================================================================================================ //

		private IRepositorio<Stock> stockRepositorio;

		public IRepositorio<Stock> StockRepositorio => stockRepositorio
													   ?? (stockRepositorio =
														   new Repositorio<Stock>(_context));


		// ============================================================================================================ //


		private IRepositorio<Precio> precioRepositorio;

		public IRepositorio<Precio> PrecioRepositorio => precioRepositorio
														 ?? (precioRepositorio =
															 new Repositorio<Precio>(_context));

		// ============================================================================================================ //

		public IRepositorio<MotivoBaja> motivoBajaRepositorio;

		public IRepositorio<MotivoBaja> MotivoBajaRepositorio => motivoBajaRepositorio ?? 
																	(motivoBajaRepositorio = 
																		new Repositorio<MotivoBaja>(_context));

		// ============================================================================================================ //

		public IRepositorio<BajaArticulo> bajaArticuloRepositorio;
		public IRepositorio<BajaArticulo> BajaArticuloRepositorio => bajaArticuloRepositorio ??
																			(bajaArticuloRepositorio =
																							new Repositorio<BajaArticulo>(_context));

		// ============================================================================================================ //

		public IRepositorio<PuestoTrabajo> puestoTrabajoRepositorio;
		public IRepositorio<PuestoTrabajo> PuestoTrabajoRepositorio => puestoTrabajoRepositorio ??
																							(puestoTrabajoRepositorio =
																										new Repositorio<PuestoTrabajo>(_context));

		// ============================================================================================================ //
		private IRepositorio<Contador> contadorRepositorio;

		public IRepositorio<Contador> ContadorRepositorio => contadorRepositorio
															 ?? (contadorRepositorio =
																 new Repositorio<Contador>(_context));
	}
}
