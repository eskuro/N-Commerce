using Aplicacion.Constantes;
using Dominio.MetaData;
using IServicio.Articulo;
using IServicios.BajaArticulo;
using IServicios.MotivoBaja;
using PresentacionBase.Formularios;
using StructureMap;
using Presentacion.Core.Articulo;
using IServicio.Articulo.DTOs;
using IServicios.Articulo.DTOs;
using IServicios.BajaArticulo.DTOs;
using System;
using IServicio.Deposito.DTOs;
using Dominio.Entidades;

namespace Presentacion.Core.Articulo
{
    public partial class _00030_Abm_BajaArticulos : FormAbm
    {
        private readonly IBajaArticuloServicio _bajaArticuloServicio;
        private readonly IMotivoBajaServicio _motivoBajaServicio;
        private readonly IArticuloServicio _articuloServicio;

        private ArticuloDto _articuloSeleccionado;
        public _00030_Abm_BajaArticulos(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _bajaArticuloServicio = ObjectFactory.GetInstance<IBajaArticuloServicio>();
            _motivoBajaServicio = ObjectFactory.GetInstance<IMotivoBajaServicio>();
            _articuloServicio = ObjectFactory.GetInstance<IArticuloServicio>();

            PoblarComboBox(cmbMotivoBaja, _motivoBajaServicio.Obtener(string.Empty), "Descripcion", "Id");

            imgFotoArticulo.Image = Imagen.ImagenProductoPorDefecto;
        }



		public override void EjecutarComandoNuevo()
		{
            base.EjecutarComandoNuevo();

           
            if (nudCantidadBaja.Value <= nudStockActual.Value) 
            {
                
                decimal nuevostock = nudStockActual.Value - nudCantidadBaja.Value;

                

                var nuevoBajaArticulo = new BajaArticuloDto 
                { 
                    ArticuloId = _articuloSeleccionado.Id,
                    MotivoBajaId = (long)cmbMotivoBaja.SelectedValue,                                   
                    Cantidad = nudCantidadBaja.Value,
                    Fecha = DateTime.Now,
                    Observacion = txtObservacion.Text,
                    Eliminado = false,
                    
                };

                _bajaArticuloServicio.Insertar(nuevoBajaArticulo);


            }





        }

		private void btnBuscarArticulo_Click(object sender, System.EventArgs e)
		{
            var lookUp = ObjectFactory.GetInstance<ArticuloLookUp>();

            lookUp.ShowDialog();

            if (lookUp.EntidadSeleccionada != null) 
            {
                var articulo = (ArticuloDto)lookUp.EntidadSeleccionada;
                if (articulo != null) 
                {
                    _articuloSeleccionado = articulo;
                    txtArticulo.Text = articulo.Descripcion;
                    nudStockActual.Value = articulo.StockActual;
                   

                }
                
            
            }  

		}

		private void btnNuevoMotivoBaja_Click(object sender, System.EventArgs e)
		{
            var nMotivo = new _00028_Abm_MotivoBaja(TipoOperacion.Nuevo);

            nMotivo.ShowDialog();

            if (nMotivo.RealizoAlgunaOperacion) 
            {
                PoblarComboBox(cmbMotivoBaja, _motivoBajaServicio.Obtener(string.Empty));
            
            }

		}
	}

    
}
