using IServicio.Persona;
using IServicio.Persona.DTOs;
using PresentacionBase.Formularios;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.Core.Empleado
{
    public partial class EmpleadoLookUp : FormLookUp
    {
        private readonly IEmpleadoServicio _empleadoServicio;

        public EmpleadoLookUp(IEmpleadoServicio empleadoServicio)
        {
            InitializeComponent();

            _empleadoServicio = empleadoServicio;
            EntidadSeleccionada = null;
        }

        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            dgv.DataSource = (List<EmpleadoDto>)_empleadoServicio
                .Obtener(typeof(EmpleadoDto), !string.IsNullOrEmpty(cadenaBuscar) ? cadenaBuscar : string.Empty);

            FormatearGrilla(dgv);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["ApyNom"].HeaderText = "Apellido y Nombre";
            dgv.Columns["ApyNom"].Visible = true;
            dgv.Columns["ApyNom"].DisplayIndex = 1;

            dgv.Columns["Dni"].Width = 100;
            dgv.Columns["Dni"].HeaderText = "DNI";
            dgv.Columns["Dni"].Visible = true;
            dgv.Columns["Dni"].DisplayIndex = 2;

            dgv.Columns["Telefono"].Width = 120;
            dgv.Columns["Telefono"].HeaderText = "Teléfono";
            dgv.Columns["Telefono"].Visible = true;
            dgv.Columns["Telefono"].DisplayIndex = 3;
        }
    }
}

