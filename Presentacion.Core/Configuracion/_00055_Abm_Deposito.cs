using IServicio.Deposito;
using IServicio.Deposito.DTOs;
using PresentacionBase.Formularios;
using StructureMap;
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
	public partial class _00055_Abm_Deposito : FormAbm
	{
        private readonly IDepositoSevicio _depositoServicio;

        public _00055_Abm_Deposito(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _depositoServicio = ObjectFactory.GetInstance<IDepositoSevicio>();
        }

        public override void CargarDatos(long? entidadId)
        {
            base.CargarDatos(entidadId);

            if (entidadId.HasValue)
            {
                var resultado = (DepositoDto)_depositoServicio.Obtener(entidadId.Value);

                if (resultado == null)
                {
                    MessageBox.Show("Ocurrio un error al obtener el registro seleccionado");
                    Close();
                }

                txtDescripcion.Text = resultado.Descripcion;
                txtUbicacion.Text = resultado.Ubicacion;

                if (TipoOperacion == TipoOperacion.Eliminar)
                    DesactivarControles(this);
            }
            else // Nuevo
            {
                btnEjecutar.Text = "Nuevo";
            }
        }

        public override bool VerificarDatosObligatorios()
        {
            return !string.IsNullOrEmpty(txtDescripcion.Text);
        }

        //public override bool VerificarSiExiste(long? id = null)
        //{
        //    return _depositoServicio.VerificarSiExiste(txtDescripcion.Text, id);
        //}

        public override void EjecutarComandoNuevo()
        {
            var nuevoRegistro = new DepositoDto();
            nuevoRegistro.Descripcion = txtDescripcion.Text;
            nuevoRegistro.Eliminado = false;
            nuevoRegistro.Ubicacion = txtUbicacion.Text;

            _depositoServicio.Insertar(nuevoRegistro);
        }

        public override void EjecutarComandoModificar()
        {
            var modificarRegistro = new DepositoDto();
            modificarRegistro.Id = EntidadId.Value;
            modificarRegistro.Descripcion = txtDescripcion.Text;
            modificarRegistro.Ubicacion = txtUbicacion.Text;
            modificarRegistro.Eliminado = false;

            _depositoServicio.Modificar(modificarRegistro);
        }


        public override void EjecutarComandoEliminar()
        {
            _depositoServicio.Eliminar(EntidadId.Value);
        }

        public override void LimpiarControles(Form formulario)
        {
            base.LimpiarControles(formulario);

            txtDescripcion.Focus();
        }
    }
}
