using System;

namespace TarjetaDeCreditoMVC.Entidades.DTOs.CarteraConsumo
{
    public class CarteraConsumoListDto: ICloneable
    {
        public int CarteraDeConsumoId { get; set; }
        public string Descripcion { get; set; }
        public decimal LimiteDeCredito { get; set; }
        public decimal CostoDeRenovacion { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
