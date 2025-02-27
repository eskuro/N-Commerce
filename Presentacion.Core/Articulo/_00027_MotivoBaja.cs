﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IServicios.MotivoBaja;
using PresentacionBase.Formularios;

namespace Presentacion.Core.Articulo
{
    public partial class _00027_MotivoBaja : FormConsulta
    {
		private readonly IMotivoBajaServicio _motivoBajaServicio;

		public _00027_MotivoBaja(IMotivoBajaServicio motivoBajaServicio)
		{
			InitializeComponent();
			_motivoBajaServicio = motivoBajaServicio;
		}

		public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
		{
			dgv.DataSource = _motivoBajaServicio.Obtener(cadenaBuscar);

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
			var form = new _00028_Abm_MotivoBaja(tipoOperacion, id);
			form.ShowDialog();
			return form.RealizoAlgunaOperacion;
		}
	}
}
