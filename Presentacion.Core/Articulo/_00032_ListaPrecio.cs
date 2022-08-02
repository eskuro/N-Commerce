using PresentacionBase.Formularios;
using IServicio.ListaPrecio;
using System.Windows.Forms;

namespace Presentacion.Core.Articulo
{
    public partial class _00032_ListaPrecio : FormConsulta
    {
		private readonly IListaPrecioServicio _listaPrecioServicio;

		public _00032_ListaPrecio(IListaPrecioServicio listaPrecioServicio)
		{
			InitializeComponent();
			_listaPrecioServicio = listaPrecioServicio;
		}

		public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
		{
			dgv.DataSource = _listaPrecioServicio.Obtener(cadenaBuscar);

			base.ActualizarDatos(dgv, cadenaBuscar);
		}

		public override void FormatearGrilla(DataGridView dgv)
		{
			base.FormatearGrilla(dgv); // Pongo Invisible las Columnas

			dgv.Columns["Descripcion"].Visible = true;
			dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgv.Columns["Descripcion"].HeaderText = @"Descripción";

			dgv.Columns["PorcentajeGanancia"].Visible = true;
			dgv.Columns["PorcentajeGanancia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgv.Columns["PorcentajeGanancia"].HeaderText = @"Porcentajé Ganancia";


		}


		public override bool EjecutarComando(TipoOperacion tipoOperacion, long? id = null)
		{
			var form = new _00033_Abm_ListaPrecio(tipoOperacion, id);
			form.ShowDialog();
			return form.RealizoAlgunaOperacion;
		}
	}
}
