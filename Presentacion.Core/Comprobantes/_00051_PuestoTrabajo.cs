using IServicios.PuestoTrabajo;
using PresentacionBase.Formularios;
using System.Windows.Forms;

namespace Presentacion.Core.Comprobantes
{
    public partial class _00051_PuestoTrabajo : FormConsulta
    {
        private readonly IPuestoTrabajoServicio _puestoTrabajoServicio;
        public _00051_PuestoTrabajo(IPuestoTrabajoServicio puestoTrabajoServicio)
        {
            InitializeComponent();

            _puestoTrabajoServicio = puestoTrabajoServicio;
        }


        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            // Codigo agregado por Nosotros
            dgv.DataSource = _puestoTrabajoServicio.Obtener(cadenaBuscar);

            // Codigo del PAPA
            base.ActualizarDatos(dgv, cadenaBuscar);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv); // Pongo Invisible las Columnas

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Descripcion"].HeaderText = @"Descripción";

            dgv.Columns["Codigo"].Visible = true;
            dgv.Columns["Codigo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            
        }

        public override bool EjecutarComando(TipoOperacion tipoOperacion, long? id = null)
        {
            var formulario = new _00052_Abm_PuestoTrabajo(tipoOperacion, id);

            formulario.ShowDialog();

            return formulario.RealizoAlgunaOperacion;
        }
    }
}
