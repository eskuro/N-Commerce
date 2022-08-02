using IServicio.Persona;
using IServicio.Persona.DTOs;
using PresentacionBase.Formularios;
using System.Windows.Forms;

namespace Presentacion.Core.Empleado
{
	public partial class _00007_Empleado : FormConsulta
	{
		private readonly IEmpleadoServicio _empleadoServicio;
		public _00007_Empleado(IEmpleadoServicio empleadoServicio)
		{
			InitializeComponent();

			_empleadoServicio = empleadoServicio;
		}

		public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
		{
			dgv.DataSource = _empleadoServicio.Obtener(typeof(EmpleadoDto), cadenaBuscar);

			base.ActualizarDatos(dgv, cadenaBuscar);
		}

		public override void FormatearGrilla(DataGridView dgv)
		{
			base.FormatearGrilla(dgv);


			dgv.Columns["Apellido"].Visible = true;
			dgv.Columns["Apellido"].Width = 100;

			dgv.Columns["Nombre"].Visible = true;
			dgv.Columns["Nombre"].Width = 100;

			dgv.Columns["Legajo"].Visible = true;
			dgv.Columns["Legajo"].Width = 100;

			dgv.Columns["Direccion"].Visible = true;
			dgv.Columns["Direccion"].Width = 100;

			dgv.Columns["Dni"].Visible = true;
			dgv.Columns["Dni"].Width = 100;


			dgv.Columns["Telefono"].Visible = true;
			dgv.Columns["Telefono"].Width = 100;

			dgv.Columns["Mail"].Visible = true;
			dgv.Columns["Mail"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

		}
		public override bool EjecutarComando(TipoOperacion tipoOperacion, long? id = null)
		{

			var form = new _00008_Abm_Empleado(tipoOperacion,id);

			form.ShowDialog();
			return form.RealizoAlgunaOperacion;
		}
	}
}
