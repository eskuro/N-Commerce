using Aplicacion.Constantes;
using IServicio.Seguridad;
using IServicio.Usuario;
using PresentacionBase.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Usuario
{
	public partial class Login : Form
	{
		public bool PuedeAcceder { get; private set; }
		private readonly ISeguridadServicio _seguridadServicio;
		public Login( ISeguridadServicio seguridadServicio)
		{
			InitializeComponent();

			_seguridadServicio = seguridadServicio;
			imgLogin.Image = Imagen.ImagenLogin;

			txtUsuario.Text = "mibañez";
			txtPassword.Text = "P$assword123";

		}

		private void VerificarDatos(string usuario, string contraseña)
		{

			try
			{
				

				if (UsuarioAdmin.Usuario == txtUsuario.Text && UsuarioAdmin.Password == txtPassword.Text)
				{
					Identidad.Apellido = "Administrador";

					PuedeAcceder = true;
					this.Close();
					return;

				}

				var usuarioLogin = _seguridadServicio.ObtenerUsuarioLogin(usuario);

				if (usuarioLogin != null)
				{
					if (VerificarAcceso(usuario, contraseña) == true)
					{

						Identidad.EmpleadoId = usuarioLogin.EmpleadoId;
						Identidad.Nombre = usuarioLogin.NombreEmpleado;
						Identidad.Apellido = usuarioLogin.ApellidoEmpleado;
						Identidad.Foto = usuarioLogin.FotoEmpleado;
						// ================================================ //
						Identidad.UsuarioId = usuarioLogin.Id;
						Identidad.Usuario = usuarioLogin.NombreUsuario;

						PuedeAcceder = true;

						this.Close();
						return;

					}
					else
					{
						PuedeAcceder = false;
					}

				}
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
				txtPassword.Clear();
				txtPassword.Focus();
			}


		}

		private bool VerificarAcceso(string usuario, string contraseña) 
		{

			return _seguridadServicio.VerificarAcceso(usuario, contraseña);
		}

		private void btnIngresar_Click(object sender, EventArgs e)
		{
			
			VerificarDatos(txtUsuario.Text, txtPassword.Text);

		}

		private void btnSalir_Click(object sender, EventArgs e)
		{

		}

		private void btnCerrar_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void btnMinimizar_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}
	}
}
