using System.Collections.Generic;
using TarjetaDeCreditoMVC.Entidades.DTOs.CarteraConsumo;
using TarjetaDeCreditoMVC.Entidades.Entidades;

namespace TarjetaDeCreditoMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioCarterasConsumos
    {
        List<CarteraConsumoListDto> GetLista();
        CarteraConsumoEditDto GetCarteraPorId(int? id);
        void Guardar(CarteraDeConsumo carteraDeConsumo);
        void Borrar(int? id);
        bool Existe(CarteraDeConsumo carteraDeConsumo);
    }
}
