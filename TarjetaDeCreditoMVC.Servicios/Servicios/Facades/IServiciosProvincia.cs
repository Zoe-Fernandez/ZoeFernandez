using System.Collections.Generic;
using TarjetaDeCreditoMVC.Entidades.DTOs.Provincia;

namespace TarjetaDeCreditoMVC.Servicios.Servicios.Facades
{
    public interface IServiciosProvincia
    {
        List<ProvinciaListDto> GetLista();
        ProvinciaEditDto GetProvinciaPorId(int? id);
        void Guardar(ProvinciaEditDto provincia);
        void Borrar(int? id);
        bool Existe(ProvinciaEditDto provincia);
    }
}
