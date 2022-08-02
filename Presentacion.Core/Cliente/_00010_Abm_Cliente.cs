using IServicio.Departamento;
using IServicio.Localidad;
using IServicio.Persona;
using IServicio.Persona.DTOs;
using IServicio.Provincia;
using Presentacion.Core.CondicionIva;
using Presentacion.Core.Departamento;
using Presentacion.Core.Localidad;
using Presentacion.Core.Provincia;
using PresentacionBase.Formularios;
using StructureMap;
using System;
using System.Windows.Forms;

namespace Presentacion.Core.Cliente
{
	public partial class _00010_Abm_Cliente : FormAbm
	{
		private readonly IClienteServicio _clienteServicio;
		private readonly IProvinciaServicio _provinciaServicio;
		private readonly ILocalidadServicio _localidadServicio;
		private readonly ICondicionIvaServicio _condicionIvaServicio;
		private readonly IDepartamentoServicio _departamentoServicio;

		public _00010_Abm_Cliente(TipoOperacion tipoOperacion, long? entidadId = null)
			: base(tipoOperacion, entidadId)
		{
			InitializeComponent();

			_clienteServicio = ObjectFactory.GetInstance<IClienteServicio>();
			_provinciaServicio = ObjectFactory.GetInstance<IProvinciaServicio>();
			_localidadServicio = ObjectFactory.GetInstance<ILocalidadServicio>();
			_condicionIvaServicio = ObjectFactory.GetInstance<ICondicionIvaServicio>();
			_departamentoServicio = ObjectFactory.GetInstance<IDepartamentoServicio>();

			PoblarComboBox(cmbCondicionIva, _condicionIvaServicio.Obtener(string.Empty), "Descripcion", "Id");
			PoblarComboBox(cmbDepartamento, _departamentoServicio.Obtener(string.Empty), "Descripcion", "Id");
			PoblarComboBox(cmbLocalidad, _localidadServicio.Obtener(string.Empty), "Descripcion", "Id");
			PoblarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty), "Descripcion", "Id");


		}


		public override void CargarDatos(long? entidadId)
		{
			base.CargarDatos(entidadId);

			


			if (entidadId.HasValue && entidadId.Value != 0)
			{
				var entidad = (ClienteDto)_clienteServicio.Obtener(typeof(ClienteDto), entidadId.Value);

				if (entidad == null)
				{
					MessageBox.Show("Ocurrio un error al Obtener los Datos");
				}

				txtApellido.Text = entidad.Apellido;


				txtDomicilio.Text = entidad.Direccion;
				txtDni.Text = entidad.Dni;
				txtMail.Text = entidad.Mail;
				txtNombre.Text = entidad.Nombre;
				txtTelefono.Text = entidad.Telefono;
				cmbProvincia.SelectedValue = entidad.ProvinciaId;
				chkActivarCuentaCorriente.Checked = entidad.ActivarCtaCte;
				chkLimiteCompra.Checked = entidad.TieneLimiteCompra;
				nudLimiteCompra.Value = entidad.MontoMaximoCtaCte;
				cmbCondicionIva.SelectedValue = entidad.CondicionIvaId;


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

			if (cmbCondicionIva.Items.Count <= 0) return false;
			if (cmbDepartamento.Items.Count <= 0) return false;
			if (cmbLocalidad.Items.Count <= 0) return false;
			if (cmbProvincia.Items.Count <= 0) return false;
			return true;
		}

		public override void EjecutarComandoNuevo()
		{
			var nuevoRegistro = new ClienteDto
			{
				Apellido = txtApellido.Text,
				Nombre = txtNombre.Text,
				Dni = txtDni.Text,
				Telefono = txtTelefono.Text,
				ProvinciaId = (long)cmbProvincia.SelectedValue,
				LocalidadId = (long)cmbLocalidad.SelectedValue,
				DepartamentoId = (long)cmbDepartamento.SelectedValue,
				CondicionIvaId = (long)cmbCondicionIva.SelectedValue,
				Mail = txtMail.Text,
				ActivarCtaCte = chkActivarCuentaCorriente.Checked,
				TieneLimiteCompra = chkLimiteCompra.Checked,
				MontoMaximoCtaCte = nudLimiteCompra.Value,
				Direccion = txtDomicilio.Text,
				//------------------------------------------------//			
				Eliminado = false
			};
			_clienteServicio.Insertar(nuevoRegistro);
		}


		public override void EjecutarComandoModificar()
		{
			var modificarRegistro = new ClienteDto
			{
				Apellido = txtApellido.Text,
				Nombre = txtNombre.Text,
				Dni = txtDni.Text,
				Telefono = txtTelefono.Text,
				ProvinciaId = (long)cmbProvincia.SelectedValue,
				LocalidadId = (long)cmbLocalidad.SelectedValue,
				DepartamentoId = (long)cmbDepartamento.SelectedValue,
				CondicionIvaId = (long)cmbCondicionIva.SelectedValue,
				Mail = txtMail.Text,
				ActivarCtaCte = chkActivarCuentaCorriente.Checked,
				TieneLimiteCompra = chkLimiteCompra.Checked,
				MontoMaximoCtaCte = nudLimiteCompra.Value,
				Direccion = txtDomicilio.Text,
				//------------------------------------------------//			
				Eliminado = false
			};
			_clienteServicio.Modificar(modificarRegistro);
		}

		public override void EjecutarComandoEliminar()
		{
			_clienteServicio.Eliminar(typeof(ClienteDto),EntidadId.Value);
		}

		private void btnNuevaProvincia_Click(object sender, EventArgs e)
		{
			var NuevaProvincia = new _00002_Abm_Provincia(TipoOperacion.Nuevo);


			NuevaProvincia.ShowDialog();

			if (NuevaProvincia.RealizoAlgunaOperacion)
			{
				PoblarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty));
			}
		}

		private void btnNuevoDepartamento_Click(object sender, EventArgs e)
		{
			var NuevoDepartamento = new _00004_Abm_Departamento(TipoOperacion.Nuevo);

			NuevoDepartamento.ShowDialog();

			if (NuevoDepartamento.RealizoAlgunaOperacion)
			{
				PoblarComboBox(cmbDepartamento, _departamentoServicio.Obtener(string.Empty));
			}
		}

		private void btnNuevaLocalidad_Click(object sender, EventArgs e)
		{
			var NuevaLocalidad = new _00006_AbmLocalidad(TipoOperacion.Nuevo);

			NuevaLocalidad.ShowDialog();

			if (NuevaLocalidad.RealizoAlgunaOperacion)
			{
				PoblarComboBox(cmbLocalidad, _localidadServicio.Obtener(string.Empty));
			}
		}

		private void btnNuevaCondicionIva_Click(object sender, EventArgs e)
		{
			var NuevaCondicion = new _00014_Abm_CondicionIva(TipoOperacion.Nuevo);

			NuevaCondicion.ShowDialog();

			if (NuevaCondicion.RealizoAlgunaOperacion)
			{
				PoblarComboBox(cmbCondicionIva, _condicionIvaServicio.Obtener(string.Empty));
			}

		}
	}	
}
