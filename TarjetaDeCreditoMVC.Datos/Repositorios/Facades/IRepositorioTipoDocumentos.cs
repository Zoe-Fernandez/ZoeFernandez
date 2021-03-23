using System.Collections.Generic;
using TarjetaDeCreditoMVC.Entidades.DTOs.TipoDocumento;
using TarjetaDeCreditoMVC.Entidades.Entidades;

namespace TarjetaDeCreditoMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioTipoDocumentos
    {
        List<TipoDocumentoListDto> GetLista();
        TipoDocumentoEditDto GetTipoPorId(int? id);
        void Guardar(TipoDeDocumento tipoDeDocumento);
        void Borrar(int? id);
        bool Existe(TipoDeDocumento tipoDeDocumento);
    }
}
