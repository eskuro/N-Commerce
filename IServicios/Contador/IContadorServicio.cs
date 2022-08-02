using Aplicacion.Constantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServicios.Contador
{
	public interface IContadorServicio
	{
		int ObtenerSiguienteNumeroComprobante(TipoComprobante tipoComprobante);
	}
}
