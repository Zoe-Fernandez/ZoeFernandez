using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TarjetaDeCreditoMVC.Datos.Repositorios;
using TarjetaDeCreditoMVC.Entidades.Entidades;

namespace TarjetaDeCreditoMVC.Datos
{
    public class TarjetasDeCreditoDbContext: DbContext
    {
        public TarjetasDeCreditoDbContext() : base("MiConexion")
        {
            Database.CommandTimeout = 50;
            Configuration.UseDatabaseNullSemantics = true;

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<TarjetasDeCreditoDbContext>(null);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); //evita el borrado en cascada
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly()); //le digo que tome las configuraciones del  mismo assembly
        }

        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<TipoDeDocumento> TipoDeDocumentos { get; set; }
        public DbSet<CarteraDeConsumo> CarteraDeConsumos { get; set; }

        public static implicit operator TarjetasDeCreditoDbContext(RepositorioCarteraConsumo v)
        {
            throw new NotImplementedException();
        }
    }
}
