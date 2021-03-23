using System.ComponentModel.DataAnnotations;

namespace TarjetaDeCreditoMVC.Entidades.ViewModels.CarteraConsumo
{
    public class CarteraConsumoListViewModel
    {
        public int CarteraDeConsumoId { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Limite de credito")]
        public decimal LimiteDeCredito { get; set; }

        [Display(Name = "Costo de renovacion")]
        public decimal CostoDeRenovacion { get; set; }
    }
}
