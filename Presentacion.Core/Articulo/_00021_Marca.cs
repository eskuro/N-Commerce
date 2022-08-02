using IServicio.Marca;
using PresentacionBase.Formularios;
using System.Windows.Forms;

namespace Presentacion.Core.Articulo
{
    public partial class _00021_Marca : FormConsulta
    {
		private readonly IMarcaServicio _marcaServicio;

		public _00021_Marca(IMarcaServicio marcaServicio)
		{
			InitializeComponent();
			_marcaServicio = marcaServicio;
		}

		public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
		{
			dgv.DataSource = _marcaServicio.Obtener(cadenaBuscar);

			base.ActualizarDatos(dgv, cadenaBuscar);
		}

		public override void FormatearGrilla(DataGridView dgv)
		{
			base.FormatearGrilla(dgv); // Pongo Invisible las Columnas

			dgv.Columns["Descripcion"].Visible = true;
			dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgv.Columns["Descripcion"].HeaderText = @"Descripción";

			
		}


		public override bool EjecutarComando(TipoOperacion tipoOperacion, long? id = null)
		{
			var form = new _00022_Abm_Marca(tipoOperacion, id);
			form.ShowDialog();
			return form.RealizoAlgunaOperacion;
		}
	}
}
