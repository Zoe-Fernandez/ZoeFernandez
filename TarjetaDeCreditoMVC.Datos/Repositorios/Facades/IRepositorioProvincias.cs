using System.Collections.Generic;
using TarjetaDeCreditoMVC.Entidades.DTOs.Provincia;
using TarjetaDeCreditoMVC.Entidades.Entidades;

namespace TarjetaDeCreditoMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioProvincias
    {
        List<ProvinciaListDto> GetLista();
        ProvinciaEditDto GetProvinciaPorId(int? id);
        void Guardar(Provincia provincia);
        void Borrar(int? id);
        bool Existe(Provincia provincia);
    }
}
