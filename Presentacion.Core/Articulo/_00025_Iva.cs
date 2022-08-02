﻿using IServicio.Iva;
using PresentacionBase.Formularios;
using System.Windows.Forms;

namespace Presentacion.Core.Articulo
{
    public partial class __00025_Iva : FormConsulta
    {
	    private readonly IIvaServicio _ivaServicio;

	    public __00025_Iva(IIvaServicio ivaServicio)
	    {
		    InitializeComponent();
		    _ivaServicio = ivaServicio;
	    }

	    public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
	    {
		    dgv.DataSource = _ivaServicio.Obtener(cadenaBuscar);

		    base.ActualizarDatos(dgv, cadenaBuscar);
	    }

	    public override void FormatearGrilla(DataGridView dgv)
	    {
		    base.FormatearGrilla(dgv); // Pongo Invisible las Columnas

		    dgv.Columns["Descripcion"].Visible = true;
		    dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		    dgv.Columns["Descripcion"].HeaderText = @"Descripción";

		    dgv.Columns["Porcentaje"].Visible = true;
		    dgv.Columns["Porcentaje"].Width = 100;
		    dgv.Columns["Porcentaje"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
	    }


	    public override bool EjecutarComando(TipoOperacion tipoOperacion, long? id = null)
	    {
		    var form = new _00026_Abm_Iva(tipoOperacion, id);
		    form.ShowDialog();
		    return form.RealizoAlgunaOperacion;
	    }
    }
}
