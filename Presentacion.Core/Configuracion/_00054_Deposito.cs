using IServicio.Deposito;
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

namespace Presentacion.Core.Configuracion
{
	public partial class _00054_Deposito : FormConsulta
	{
		private readonly IDepositoSevicio _depositoServicio;

		public _00054_Deposito(IDepositoSevicio depositoServicio)
		{
			InitializeComponent();
			_depositoServicio = depositoServicio;
		}

		public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
		{
			dgv.DataSource = _depositoServicio.Obtener(cadenaBuscar);

			base.ActualizarDatos(dgv, cadenaBuscar);
		}

		public override void FormatearGrilla(DataGridView dgv)
		{
			base.FormatearGrilla(dgv); // Pongo Invisible las Columnas

			dgv.Columns["Descripcion"].Visible = true;
			dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgv.Columns["Descripcion"].HeaderText = @"Descripción";

			dgv.Columns["Ubicacion"].Visible = true;
			dgv.Columns["Ubicacion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgv.Columns["Ubicacion"].HeaderText = @"Ubicación";
		}


		public override bool EjecutarComando(TipoOperacion tipoOperacion, long? id = null)
		{
			var form = new _00055_Abm_Deposito(tipoOperacion, id);
			form.ShowDialog();
			return form.RealizoAlgunaOperacion;
		}
	}
}
