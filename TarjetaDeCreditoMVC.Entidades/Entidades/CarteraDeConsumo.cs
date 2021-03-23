namespace TarjetaDeCreditoMVC.Entidades.Entidades
{
    public class CarteraDeConsumo
    {
        public int CarteraDeConsumoId { get; set; }
        public string Descripcion { get; set; }
        public decimal LimiteDeCredito { get; set; }
        public decimal CostoDeRenovacion { get; set; }
    }
}
