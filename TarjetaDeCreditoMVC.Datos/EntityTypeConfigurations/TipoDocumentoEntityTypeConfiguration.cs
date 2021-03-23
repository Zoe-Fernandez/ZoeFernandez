using System.Data.Entity.ModelConfiguration;
using TarjetaDeCreditoMVC.Entidades.Entidades;

namespace TarjetaDeCreditoMVC.Datos.EntityTypeConfigurations
{
    public class TipoDocumentoEntityTypeConfiguration : EntityTypeConfiguration<TipoDeDocumento>
    {
        public TipoDocumentoEntityTypeConfiguration()
        {
            ToTable("TiposDeDocumentos");
        }
    }
}
