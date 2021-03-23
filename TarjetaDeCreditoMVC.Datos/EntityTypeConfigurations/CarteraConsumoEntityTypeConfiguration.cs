using System.Data.Entity.ModelConfiguration;
using TarjetaDeCreditoMVC.Entidades.Entidades;

namespace TarjetaDeCreditoMVC.Datos.EntityTypeConfigurations
{
    public class CarteraConsumoEntityTypeConfiguration : EntityTypeConfiguration<CarteraDeConsumo>
    {
        public CarteraConsumoEntityTypeConfiguration()
        {
            ToTable("CarterasDeConsumos");
        }
    }
}
