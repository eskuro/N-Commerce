using IServicio.Articulo;
using IServicio.Articulo.DTOs;
using PresentacionBase.Formularios;
using StructureMap;
using System.Windows.Forms;

namespace Presentacion.Core.Articulo
{
    public partial class ArticuloLookUp : FormLookUp
    {

        private readonly IArticuloServicio _articuloServicio;

		private long _listaPrecioId;
		public ArticuloDto ArticuloSeleccionado => (ArticuloDto)EntidadSeleccionada;
		public ArticuloLookUp(long listaPrecioId)
		{
			InitializeComponent();

			_articuloServicio = ObjectFactory.GetInstance<IArticuloServicio>();
			_listaPrecioId = listaPrecioId;
		}
		public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
		{
			
			dgv.DataSource = _articuloServicio.Obtener(cadenaBuscar);
			base.ActualizarDatos(dgv, cadenaBuscar);
			FormatearGrilla(dgv);
		}


		public override void FormatearGrilla(DataGridView dgv)
		{
            base.FormatearGrilla(dgv);

			dgv.Columns["Codigo"].Visible = true;
			dgv.Columns["Codigo"].Width = 70;
			dgv.Columns["Codigo"].HeaderText = "Código";
			dgv.Columns["CodigoBarra"].Visible = true;
			dgv.Columns["CodigoBarra"].Width = 100;
			dgv.Columns["CodigoBarra"].HeaderText = "Código Barra";
			
			
			dgv.Columns["Descripcion"].Visible = true;
			dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgv.Columns["Descripcion"].HeaderText = @"Descripción";

			dgv.Columns["EliminadoStr"].Visible = true;
			dgv.Columns["EliminadoStr"].Width = 60;
			dgv.Columns["EliminadoStr"].HeaderText = "Eliminado";
			dgv.Columns["EliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

			dgv.Columns["StockActual"].Visible = true;
			dgv.Columns["StockActual"].Width = 60;
			dgv.Columns["StockActual"].HeaderText = "Stock";
			


		}


	}
}
