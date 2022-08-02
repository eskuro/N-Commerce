using IServicio.Usuario;
using IServicio.Usuario.DTOs;
using PresentacionBase.Formularios;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Core.Usuario
{
	public partial class _00011_Usuario : FormBase
	{
		private readonly IUsuarioServicio _usuarioServicio;

		private long? entidadId;
		protected object EntidadSeleccionada;
		public _00011_Usuario(IUsuarioServicio usuarioServicio)
		{
			InitializeComponent();

			_usuarioServicio = usuarioServicio;

			ActualizarDatos(string.Empty);
		}

		private void ActualizarDatos(string cadenabuscar)
		{
			var usuarios = _usuarioServicio.Obtener(cadenabuscar);

			dgvGrilla.DataSource = usuarios;

			FormatearGrilla(dgvGrilla);
		}

		public override void FormatearGrilla(DataGridView dgv)
		{
			base.FormatearGrilla(dgv);

			dgv.Columns["ApyNomEmpleado"].Visible = true;
			dgv.Columns["ApyNomEmpleado"].HeaderText = "Apellido y Nombre";
			dgv.Columns["ApyNomEmpleado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			dgv.Columns["NombreUsuario"].Visible = true;
			dgv.Columns["NombreUsuario"].HeaderText = "Usuario";
			dgv.Columns["NombreUsuario"].Width = 150;

			dgv.Columns["EstaBloqueadoStr"].Visible = true;
			dgv.Columns["EstaBloqueadoStr"].HeaderText = "Bloqueado";
			dgv.Columns["EstaBloqueadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgv.Columns["EstaBloqueadoStr"].Width = 70;



		}
		private void btnNuevo_Click(object sender, System.EventArgs e)
		{
			var usuario = (UsuarioDto)EntidadSeleccionada;

			_usuarioServicio.Crear(usuario.EmpleadoId, usuario.ApellidoEmpleado, usuario.NombreEmpleado);
			ActualizarDatos(string.Empty);


		}

		private void btnBuscar_Click(object sender, System.EventArgs e)
		{
			ActualizarDatos(txtBuscar.Text);
		}

		private void btnActualizar_Click(object sender, System.EventArgs e)
		{
			btnBuscar.PerformClick();
		}

		private void btnSalir_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (dgvGrilla.RowCount <= 0) return;

			entidadId = (long)dgvGrilla["Id", e.RowIndex].Value;

			// Obtener el Objeto completo seleccionado
			EntidadSeleccionada = dgvGrilla.Rows[e.RowIndex].DataBoundItem;


			
		}

		private void btnEliminar_Click(object sender, System.EventArgs e)
		{
			var usuario = (UsuarioDto)EntidadSeleccionada;

			_usuarioServicio.ResetPassword(usuario.Id);

			ActualizarDatos(string.Empty);
		}

		private void btnModificar_Click(object sender, System.EventArgs e)
		{
			var usuario = (UsuarioDto)EntidadSeleccionada;

			_usuarioServicio.Bloquear(usuario.Id);

			ActualizarDatos(string.Empty);
		}
	} 
}
