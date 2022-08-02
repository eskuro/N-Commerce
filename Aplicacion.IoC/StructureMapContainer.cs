using System.Data.Entity;
using Dominio.Entidades;
using Dominio.MetaData;
using Dominio.Repositorio;
using Dominio.UnidadDeTrabajo;
using Infraestructura.Repositorio;
using Infraestructura.UnidadDeTrabajo;
using IServicio.Articulo;
using IServicio.Configuracion;
using IServicio.Departamento;
using IServicio.Deposito;
using IServicio.Iva;
using IServicio.ListaPrecio;
using IServicio.Localidad;
using IServicio.Marca;
using IServicio.Persona;
using IServicio.Provincia;
using IServicio.Rubro;
using IServicio.Seguridad;
using IServicio.UnidadMedida;
using IServicio.Usuario;
using IServicios.BajaArticulo;
using IServicios.Contador;
using IServicios.MotivoBaja;
using IServicios.Precio;
using IServicios.PuestoTrabajo;
using Servicios.Articulo;
using Servicios.BajaArticulo;
using Servicios.CondicionIva;
using Servicios.Configuracion;
using Servicios.Contador;
using Servicios.Departamento;
using Servicios.Deposito;
using Servicios.Iva;
using Servicios.ListaPrecio;
using Servicios.Localidad;
using Servicios.Marca;
using Servicios.MotivoBaja;
using Servicios.Persona;
using Servicios.Precio;
using Servicios.Provincia;
using Servicios.PuestoTrabajo;
using Servicios.Rubro;
using Servicios.Seguridad;
using Servicios.UnidadMedida;
using Servicios.Usuario;
using StructureMap;

namespace Aplicacion.IoC
{
    public class StructureMapContainer
    {
        public void Configure()
        {
            ObjectFactory.Configure(x =>
			{
				x.For(typeof(IRepositorio<>)).Use(typeof(Repositorio<>));

				x.ForSingletonOf<DbContext>();

				x.For<IUnidadDeTrabajo>().Use<UnidadDeTrabajo>();

                // =================================================================== //

                x.For<IProvinciaServicio>().Use<ProvinciaServicio>();

                x.For<IDepartamentoServicio>().Use<DepartamentoServicio>();

                x.For<ILocalidadServicio>().Use<LocalidadServicio>();

                x.For<ICondicionIvaServicio>().Use<CondicionIvaServicio>();

                x.For<IPersonaServicio>().Use<PersonaServicio>();

                x.For<IClienteServicio>().Use<ClienteServicio>();

                x.For<IEmpleadoServicio>().Use<EmpleadoServicio>();

                x.For<IUsuarioServicio>().Use<UsuarioServicio>();

                x.For<ISeguridadServicio>().Use<SeguridadServicio>();

                x.For<IConfiguracionServicio>().Use<ConfiguracionServicio>();

                x.For<IListaPrecioServicio>().Use<ListaPrecioServicio>();

                x.For<IBajaArticuloServicio>().Use<BajaArticuloServicio>();

                x.For<IArticuloServicio>().Use<ArticuloServicio>();

                x.For<IMarcaServicio>().Use<MarcaServicio>();

                x.For<IRubroServicio>().Use<RubroServicio>();

                x.For<IUnidadMedidaServicio>().Use<UnidadMedidaServicio>();

                x.For<IIvaServicio>().Use<IvaServicio>();

                //x.For<IConceptoGastoServicio>().Use<ConceptoGastoServicio>();

                x.For<IDepositoSevicio>().Use<DepositoServicio>();

                x.For<IPuestoTrabajoServicio>().Use<PuestoTrabajoServicio>();

                x.For<IMotivoBajaServicio>().Use<MotivoBajaServicio>();

               // x.For<ICuentaCorrienteServicio>().Use<CuentaCorrienteServicio>();

                x.For<IContadorServicio>().Use<ContadorServicio>();

                x.For<IPrecioServicio>().Use<PrecioServicio>();


            });
        }
    }
}
