using System.Collections.Generic;
using TarjetaDeCreditoMVC.Entidades.DTOs.CarteraConsumo;

namespace TarjetaDeCreditoMVC.Servicios.Servicios.Facades
{
    public interface IServiciosCarteraConsumo
    {
        List<CarteraConsumoListDto> GetLista();
        CarteraConsumoEditDto GetCarteraPorId(int? id);
        void Guardar(CarteraConsumoEditDto cartera);
        void Borrar(int? id);
        bool Existe(CarteraConsumoEditDto cartera);
    }
}
