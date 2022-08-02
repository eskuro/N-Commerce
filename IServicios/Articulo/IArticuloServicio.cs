using IServicios.Articulo.DTOs;

namespace IServicio.Articulo
{
    public interface IArticuloServicio : Base.IServicio
    {
        bool VerificarSiExiste(string datoVerificar, long? entidadId = null);

        int ObtenerSiguienteNroCodigo();

        int ObtenerCantidadArticulos();

        ArticuloVentaDto ObtenerPorCodigo(string codigo, long listaPrecioId, long depositoId);
    }
}
