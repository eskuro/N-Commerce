using IServicio.Seguridad;
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

namespace Presentacion.Core.Comprobantes.Clases
{
	public partial class AutorizacionListaPrecio : Form
	{

        private readonly ISeguridadServicio _seguridad;

        private bool _tienePermiso;
        public bool PermisoAutorizado => _tienePermiso;

        public AutorizacionListaPrecio(ISeguridadServicio seguridad)
        {
            InitializeComponent();

            _seguridad = seguridad;
            _tienePermiso = false;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
		{
            try
            {
                _tienePermiso = _seguridad.VerificarAcceso(txtUsuario.Text, txtPassword.Text);

                if (_tienePermiso)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("El usuario o el Password son Icorrectos");
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

		private void btnCancelar_Click(object sender, EventArgs e)
		{
            _tienePermiso = false;
            Close();
        }
	}
}
