using IServicio.Articulo;
using IServicio.ListaPrecio;
using IServicio.Marca;
using IServicio.Rubro;
using IServicios.Precio;
using PresentacionBase.Formularios;
using System;
using System.Windows.Forms;

namespace Presentacion.Core.Articulo
{
    public partial class _00031_ActualizarPrecios : FormBase
    {
        private readonly IMarcaServicio _marcaServicio;
        private readonly IListaPrecioServicio _listaPrecioServicio;
        private readonly IRubroServicio _rubroServicio;
        private readonly IArticuloServicio _articuloServicio;
        private readonly IPrecioServicio _precioServicio;
        public _00031_ActualizarPrecios(IMarcaServicio marcaServicio,
                                            IRubroServicio rubroServicio,
                                            IArticuloServicio articuloServicio,
                                            IListaPrecioServicio listaPrecioServicio,
                                            IPrecioServicio precioServicio)
        {


            InitializeComponent();

            _marcaServicio = marcaServicio;
            _rubroServicio = rubroServicio;
            _articuloServicio = articuloServicio;
            _listaPrecioServicio = listaPrecioServicio;
            _precioServicio = precioServicio;

            CargarDatos();
        }

		private void CargarDatos()
		{
            PoblarComboBox(cmbMarca, _marcaServicio.Obtener(string.Empty), "Descripcion", "Id");
            PoblarComboBox(cmbRubro, _rubroServicio.Obtener(string.Empty), "Descripcion", "Id");
            PoblarComboBox(cmbListaPrecio, _listaPrecioServicio.Obtener(string.Empty), "Descripcion", "Id");
            
        }

		private void chkMarca_CheckedChanged(object sender, EventArgs e)
		{
           
                cmbMarca.Enabled = chkMarca.Checked;
        }

		private void chkRubro_CheckedChanged(object sender, EventArgs e)
		{
            
                cmbRubro.Enabled = chkRubro.Checked;
        }

		private void chkArticulo_CheckedChanged(object sender, EventArgs e)
		{
            
                nudCodigoDesde.Enabled = chkArticulo.Checked;
                nudCodigoHasta.Enabled = chkArticulo.Checked;
        }

		private void btnEjecutar_Click(object sender, EventArgs e)
		{
            try
            {
                var rubroId = chkRubro.Checked
                    ? (long)cmbRubro.SelectedValue
                    : (long?)null;

                var marcaId = chkMarca.Checked
                    ? (long)cmbMarca.SelectedValue
                    : (long?)null;

                var listaPrecioId = chkListaPrecio.Checked
                    ? (long)cmbListaPrecio.SelectedValue
                    : (long?)null;

                var codigoDesde = chkArticulo.Checked
                    ? Convert.ToInt32(nudCodigoDesde.Value)
                    : (int?)null;

                var codigoHasta = chkArticulo.Checked
                    ? Convert.ToInt32(nudCodigoHasta.Value)
                    : (int?)null;

                _precioServicio.ActualizarPrecio(nudValor.Value
                    , rdbPorcentaje.Checked
                    , marcaId
                    , rubroId
                    , codigoDesde
                    , codigoHasta);

                MessageBox.Show("Los Precios se Actualizaron Correctamente");
                Limpiar();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

		private void chkListaPrecio_CheckedChanged(object sender, EventArgs e)
		{
            cmbListaPrecio.Enabled = chkListaPrecio.Checked;
        }

		private void btnSalir_Click(object sender, EventArgs e)
		{
            this.Close();
		}

        private void Limpiar()
        {
            dtpFechaAct.MinDate = DateTime.Today;
            dtpFechaAct.Value = DateTime.Now;

            

            nudCodigoDesde.Value = 0;
            nudCodigoHasta.Value = 0;

            chkRubro.Checked = false;
            chkArticulo.Checked = false;
            chkMarca.Checked = false;
            chkListaPrecio.Checked = false;

            nudValor.Value = 0;

            rdbPorcentaje.Checked = false;
            RdbPrecio.Checked = true;
        }
    }
}
