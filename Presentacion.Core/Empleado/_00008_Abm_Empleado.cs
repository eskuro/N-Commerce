using Aplicacion.Constantes;
using IServicio.Departamento;
using IServicio.Localidad;
using IServicio.Persona;
using IServicio.Persona.DTOs;
using IServicio.Provincia;
using Presentacion.Core.Departamento;
using Presentacion.Core.Localidad;
using Presentacion.Core.Provincia;
using PresentacionBase.Formularios;
using StructureMap;
using System.Windows.Forms;

namespace Presentacion.Core.Empleado
{
    public partial class _00008_Abm_Empleado : FormAbm
    {
        private readonly IEmpleadoServicio _empleadoServicio;
        private readonly IProvinciaServicio _provinciaServicio;
        private readonly IDepartamentoServicio _departamentoServicio;
        private readonly ILocalidadServicio _localidadServicio;

        public _00008_Abm_Empleado(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _provinciaServicio = ObjectFactory.GetInstance<IProvinciaServicio>();
            _localidadServicio = ObjectFactory.GetInstance<ILocalidadServicio>();
            _empleadoServicio = ObjectFactory.GetInstance<IEmpleadoServicio>();
            _departamentoServicio = ObjectFactory.GetInstance<IDepartamentoServicio>();


            PoblarComboBox(cmbDepartamento, _departamentoServicio.Obtener(string.Empty), "Descripcion", "Id");
            PoblarComboBox(cmbLocalidad, _localidadServicio.Obtener(string.Empty), "Descripcion", "Id");
            PoblarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty), "Descripcion", "Id");

			imgFoto.Image = Imagen.ImagenEmpleadoPorDefecto;
			nudLegajo.Value = _empleadoServicio.ObtenerSiguienteLegajo();
			nudLegajo.Enabled = false;
		}


		public override void CargarDatos(long? entidadId)
		{
			base.CargarDatos(entidadId);

			if (entidadId.HasValue && entidadId.Value != 0)
			{
				var entidad = (EmpleadoDto)_empleadoServicio.Obtener(typeof(EmpleadoDto), entidadId.Value);

				if (entidad == null)
				{
					MessageBox.Show("Ocurrio un error al Obtener los Datos");
				}
				nudLegajo.Value = entidad.Legajo;
				txtApellido.Text = entidad.Apellido;
				txtDomicilio.Text = entidad.Direccion;
				txtDni.Text = entidad.Dni;
				txtMail.Text = entidad.Mail;
				txtNombre.Text = entidad.Nombre;
				txtTelefono.Text = entidad.Telefono;
				cmbProvincia.SelectedValue = entidad.ProvinciaId;
				cmbDepartamento.SelectedValue = entidad.DepartamentoId;
				cmbLocalidad.SelectedValue = entidad.LocalidadId;
				imgFoto.Image = Imagen.ConvertirImagen(entidad.Foto);



				if (TipoOperacion == TipoOperacion.Eliminar)
					DesactivarControles(this);
			}
			else
			{


				btnEjecutar.Text = "Grabar";
				LimpiarControles(this);
			}
			
			

		}

		public override bool VerificarDatosObligatorios()
		{
			if (string.IsNullOrEmpty(txtApellido.Text)) return false;
			if (string.IsNullOrEmpty(txtDni.Text)) return false;
			if (string.IsNullOrEmpty(txtDomicilio.Text)) return false;
			if (string.IsNullOrEmpty(txtNombre.Text)) return false;
			if (string.IsNullOrEmpty(txtTelefono.Text)) return false;
			if (string.IsNullOrEmpty(txtMail.Text)) return false;

			
			if (cmbDepartamento.Items.Count <= 0) return false;
			if (cmbLocalidad.Items.Count <= 0) return false;
			if (cmbProvincia.Items.Count <= 0) return false;
			return true;

			
		}

		public override void EjecutarComandoNuevo()
		{
			var nuevoRegistro = new EmpleadoDto
			{
				Apellido = txtApellido.Text,
				Nombre = txtNombre.Text,
				Dni = txtDni.Text,
				Telefono = txtTelefono.Text,
				ProvinciaId = (long)cmbProvincia.SelectedValue,
				LocalidadId = (long)cmbLocalidad.SelectedValue,
				DepartamentoId = (long)cmbDepartamento.SelectedValue,
				Legajo = (int)nudLegajo.Value,
				Mail = txtMail.Text,
				
				Direccion = txtDomicilio.Text,
				//------------------------------------------------//			
				Eliminado = false,
				Foto = Imagen.ConvertirImagen(imgFoto.Image)
			};
			_empleadoServicio.Insertar(nuevoRegistro);
		}
		public override void EjecutarComandoModificar()
		{
			var modificarRegistro = new EmpleadoDto
			{
				Apellido = txtApellido.Text,
				Nombre = txtNombre.Text,
				Dni = txtDni.Text,
				Telefono = txtTelefono.Text,
				ProvinciaId = (long)cmbProvincia.SelectedValue,
				LocalidadId = (long)cmbLocalidad.SelectedValue,
				DepartamentoId = (long)cmbDepartamento.SelectedValue,
				Legajo = (int)nudLegajo.Value,
				Mail = txtMail.Text,

				Direccion = txtDomicilio.Text,
				//------------------------------------------------//			
				Eliminado = false,
				Foto = Imagen.ConvertirImagen(imgFoto.Image)
			};
			_empleadoServicio.Modificar(modificarRegistro);
		}
		public override void EjecutarComandoEliminar()
		{
			_empleadoServicio.Eliminar(typeof(EmpleadoDto), EntidadId.Value);
		}

		private void btnNuevaProvincia_Click(object sender, System.EventArgs e)
		{
			var NuevaProvincia = new _00002_Abm_Provincia(TipoOperacion.Nuevo);


			NuevaProvincia.ShowDialog();

			if (NuevaProvincia.RealizoAlgunaOperacion)
			{
				PoblarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty));
			}
		}

		private void btnNuevoDepartamento_Click(object sender, System.EventArgs e)
		{
			var NuevoDepartamento = new _00004_Abm_Departamento(TipoOperacion.Nuevo);

			NuevoDepartamento.ShowDialog();

			if (NuevoDepartamento.RealizoAlgunaOperacion)
			{
				PoblarComboBox(cmbDepartamento, _departamentoServicio.Obtener(string.Empty));
			}
		}

		private void btnNuevaLocalidad_Click(object sender, System.EventArgs e)
		{
			var NuevaLocalidad = new _00006_AbmLocalidad(TipoOperacion.Nuevo);

			NuevaLocalidad.ShowDialog();

			if (NuevaLocalidad.RealizoAlgunaOperacion)
			{
				PoblarComboBox(cmbLocalidad, _localidadServicio.Obtener(string.Empty));
			}
		}
	}
}
