using System.Collections.Generic;
using TarjetaDeCreditoMVC.Entidades.DTOs.TipoDocumento;

namespace TarjetaDeCreditoMVC.Servicios.Servicios.Facades
{
    public interface IServiciosTipoDocumento
    {
        List<TipoDocumentoListDto> GetLista();
        TipoDocumentoEditDto GetTipoDocumentoPorId(int? id);
        void Guardar(TipoDocumentoEditDto tipoProducto);
        void Borrar(int? id);
        bool Existe(TipoDocumentoEditDto tipoProducto);
    }
}
