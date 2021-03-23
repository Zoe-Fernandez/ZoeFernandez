namespace TarjetaDeCreditoMVC.Entidades.DTOs.CarteraConsumo
{
    public class CarteraConsumoEditDto
    {
        public int CarteraDeConsumoId { get; set; }
        public string Descripcion { get; set; }
        public decimal LimiteDeCredito { get; set; }
        public decimal CostoDeRenovacion { get; set; }
    }
}
