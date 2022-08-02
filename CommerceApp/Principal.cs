using System;
using System.Windows.Forms;
using Presentacion.Core.Articulo;
using Presentacion.Core.Cliente;
using Presentacion.Core.Comprobantes;
using Presentacion.Core.CondicionIva;
using Presentacion.Core.Configuracion;
using Presentacion.Core.Departamento;
using Presentacion.Core.Empleado;
using Presentacion.Core.Localidad;
using Presentacion.Core.Provincia;
using Presentacion.Core.Usuario;
using PresentacionBase.Formularios;
using StructureMap;
using System.Runtime.InteropServices;
using Aplicacion.Constantes;

namespace CommerceApp
{
	public partial class Principal : Form
	{
		[DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
		private extern static void ReleaseCapture();
		[DllImport("user32.DLL", EntryPoint = "SendMessage")]
		private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);

		public Principal()
		{
			InitializeComponent();


			lblApUsu.Text = $"{Identidad.Apellido}";
			lblnombreUsu.Text = $"{Identidad.Nombre}";
			imgUsuario.Image = Imagen.ConvertirImagen(Identidad.Foto);

			imgUsuario.Visible = Identidad.Apellido != "Administrador";
		}

		private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var fconsulta = ObjectFactory.GetInstance<_00001_Provincia>();
			AgregarFormulario(fconsulta);
		}

		private void consultaToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			var fconsulta = ObjectFactory.GetInstance<_00003_Departamento>();
			AgregarFormulario(fconsulta);
		}

		private void consultaToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			var fconsulta = ObjectFactory.GetInstance<_00005_Localidad>();
			AgregarFormulario(fconsulta);
		}

		private void consultaDeCondicionIvaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var fconsulta = ObjectFactory.GetInstance<_00013_CondicionIva>();
			AgregarFormulario(fconsulta);
		}

		private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var fconsulta = ObjectFactory.GetInstance<_00012_Configuracion>();
			AgregarFormulario(fconsulta);
		}

		

		private void nuevaCondicionIvaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var fNuevo = new _00014_Abm_CondicionIva(TipoOperacion.Nuevo);
			AgregarFormulario(fNuevo);
		}

		private void nuevoIvaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var fNuevo = new _00026_Abm_Iva(TipoOperacion.Nuevo);

			AgregarFormulario(fNuevo);

		}

		private void consultaToolStripMenuItem4_Click(object sender, EventArgs e)
		{

			var fconsulta = ObjectFactory.GetInstance<__00025_Iva>();
			AgregarFormulario(fconsulta);

		}

		private void consultaToolStripMenuItem5_Click(object sender, EventArgs e)
		{
			var fconsulta = ObjectFactory.GetInstance<_00021_Marca>();
			AgregarFormulario(fconsulta);
		}

		private void nuevaMarcaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var fNuevo = new _00022_Abm_Marca(TipoOperacion.Nuevo);

			AgregarFormulario(fNuevo);
		}

		private void consultaToolStripMenuItem6_Click(object sender, EventArgs e)
		{
			var fconsulta = ObjectFactory.GetInstance<_00019_Rubro>();
			AgregarFormulario(fconsulta);
		}

		private void nuevoRubroToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var fNuevo = new _00020_Abm_Rubro(TipoOperacion.Nuevo);

			AgregarFormulario(fNuevo);
		}

		private void consultaToolStripMenuItem7_Click(object sender, EventArgs e)
		{
			var fconsulta = ObjectFactory.GetInstance<_00023_UnidadDeMedida>();
			AgregarFormulario(fconsulta);
		}

		private void nuevaUnidadToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var fNuevo = new _00024_Abm_UnidadDeMedida(TipoOperacion.Nuevo);

			AgregarFormulario(fNuevo);
		}

	

		private void consultaToolStripMenuItem8_Click(object sender, EventArgs e)
		{
			var fconsulta = ObjectFactory.GetInstance<_00032_ListaPrecio>();
			AgregarFormulario(fconsulta);
		}

		private void nuevaListaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var fNuevo = new _00033_Abm_ListaPrecio(TipoOperacion.Nuevo);

			AgregarFormulario(fNuevo);
		}

		private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var fNuevo = new _00010_Abm_Cliente(TipoOperacion.Nuevo);

			AgregarFormulario(fNuevo);
		}

		private void consultaToolStripMenuItem9_Click(object sender, EventArgs e)
		{
			var fconsulta = ObjectFactory.GetInstance<_00009_Cliente>();
			AgregarFormulario(fconsulta);
		}

		private void consultaToolStripMenuItem10_Click(object sender, EventArgs e)
		{
			var fconsulta = ObjectFactory.GetInstance<_00054_Deposito>();
			AgregarFormulario(fconsulta);
		}

		private void nuevoDepositoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var fNuevo = new _00055_Abm_Deposito(TipoOperacion.Nuevo);

			AgregarFormulario(fNuevo);
		}

		private void consultaToolStripMenuItem11_Click(object sender, EventArgs e)
		{
			var fconsulta = ObjectFactory.GetInstance<_00029_BajaDeArticulos>();
			AgregarFormulario(fconsulta);
		}

		private void darBajaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var fNuevo = new _00030_Abm_BajaArticulos(TipoOperacion.Nuevo);

			AgregarFormulario(fNuevo);
		}

		private void consultaToolStripMenuItem12_Click(object sender, EventArgs e)
		{
			var fconsulta = ObjectFactory.GetInstance<_00007_Empleado>();
			AgregarFormulario(fconsulta);
		}

		private void nuevoEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var fNuevo = new _00008_Abm_Empleado(TipoOperacion.Nuevo);

			AgregarFormulario(fNuevo);
		}

		private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var fconsulta = ObjectFactory.GetInstance<_00011_Usuario>();
			AgregarFormulario(fconsulta);
		}

		private void consultaToolStripMenuItem13_Click(object sender, EventArgs e)
		{
			var fconsulta = ObjectFactory.GetInstance<_00051_PuestoTrabajo>();
			AgregarFormulario(fconsulta);
		}
		private void nuevoPuestoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var fNuevo = new _00052_Abm_PuestoTrabajo(TipoOperacion.Nuevo);

			AgregarFormulario(fNuevo);
			
		}

		private void actualizarPreciosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var fconsulta = ObjectFactory.GetInstance<_00031_ActualizarPrecios>();

			AgregarFormulario(fconsulta);
		}


		

		private void btnCerrar1_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		

		private void panel5_MouseDown(object sender, MouseEventArgs e)
		{
			ReleaseCapture();
			SendMessage(this.Handle, 0x112, 0xf012, 0);
		}

		

		private void AgregarFormulario(object form) 
		{
			if (this.panelContenedor.Controls.Count > 0)
				this.panelContenedor.Controls.RemoveAt(0);
			Form fh = form as Form;

			fh.TopLevel = false;
			fh.Dock = DockStyle.Fill;

			this.panelContenedor.Controls.Add(fh);
			this.panelContenedor.Tag = fh;
			fh.Show();
		}

		private void nuevoArticuloToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			var fNuevo = new _00018_Abm_Articulo(TipoOperacion.Nuevo);

			AgregarFormulario(fNuevo);
		}

		private void consultaToolStripMenuItem14_Click(object sender, EventArgs e)
		{
			var fconsulta = ObjectFactory.GetInstance<_00017_Articulo>();
			AgregarFormulario(fconsulta);
		}

		private void nuevaProvinciaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var fNuevo = new _00002_Abm_Provincia(TipoOperacion.Nuevo);
			AgregarFormulario(fNuevo);
		}

		private void nuevoDepartamentoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var fNuevo = new _00004_Abm_Departamento(TipoOperacion.Nuevo);
			AgregarFormulario(fNuevo);
		}

		private void nuevaLocalidadToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var fNuevo = new _00006_AbmLocalidad(TipoOperacion.Nuevo);
			AgregarFormulario(fNuevo);
		}

		private void btnVentas_Click(object sender, EventArgs e)
		{


			ObjectFactory.GetInstance<_00050_Venta>().Show();

			

		}
	}
}
