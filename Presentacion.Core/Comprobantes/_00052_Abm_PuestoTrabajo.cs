using Dominio.MetaData;
using IServicio.Provincia;
using IServicios.PuestoTrabajo;
using IServicios.PuestoTrabajo.DTOs;
using PresentacionBase.Formularios;
using StructureMap;
using System;
using System.Windows.Forms;

namespace Presentacion.Core.Comprobantes
{
    public partial class _00052_Abm_PuestoTrabajo : FormAbm
    {
        private readonly IPuestoTrabajoServicio _puestoTrabajoServicio;

        public _00052_Abm_PuestoTrabajo(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _puestoTrabajoServicio = ObjectFactory.GetInstance<IPuestoTrabajoServicio>();
        }

		public override void CargarDatos(long? entidadId)
		{
			base.CargarDatos(entidadId);


            if (entidadId.HasValue)
            {
                var resultado = (PuestoTrabajoDto)_puestoTrabajoServicio.Obtener(entidadId.Value);

                if (resultado == null)
                {
                    MessageBox.Show("Ocurrio un error al obtener el registro seleccionado");
                    Close();
                }

                txtDescripcion.Text = resultado.Descripcion;

                if (TipoOperacion == TipoOperacion.Eliminar)
                    DesactivarControles(this);
            }
            else // Nuevo
            {
                btnEjecutar.Text = "Nuevo";
            }
        }

		public override void EjecutarComandoNuevo()	
		{
            _puestoTrabajoServicio.Insertar(new PuestoTrabajoDto
            {
				Descripcion = txtDescripcion.Text,
				Codigo = int.Parse(txtCodigo.Text),
                Eliminado =false,
                
            });
        }

		public override void EjecutarComandoModificar()
		{
            txtCodigo.Enabled = false;
          

            var modificarRegistro = new PuestoTrabajoDto();
            modificarRegistro.Id = EntidadId.Value;
            modificarRegistro.Descripcion = txtDescripcion.Text;
            modificarRegistro.Codigo = int.Parse(txtCodigo.Text);
            modificarRegistro.Eliminado = false;

            _puestoTrabajoServicio.Modificar(modificarRegistro);
        }

		public override void EjecutarComandoEliminar()
		{
            _puestoTrabajoServicio.Eliminar(EntidadId.Value);
        }

		public override bool VerificarDatosObligatorios()
		{
            if (string.IsNullOrEmpty(txtDescripcion.Text)) 
            {
                return false;
            }


            if (string.IsNullOrEmpty(txtCodigo.Text)) 
            {

                return false;
            }

            return true;

        }
	}
}
