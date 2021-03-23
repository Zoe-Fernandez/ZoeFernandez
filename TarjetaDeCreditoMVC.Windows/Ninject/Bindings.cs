using Ninject.Modules;
using TarjetaDeCreditoMVC.Datos;
using TarjetaDeCreditoMVC.Datos.Repositorios;
using TarjetaDeCreditoMVC.Datos.Repositorios.Facades;
using TarjetaDeCreditoMVC.Servicios.Servicios;
using TarjetaDeCreditoMVC.Servicios.Servicios.Facades;

namespace TarjetaDeCreditoMVC.Windows.Ninject
{
    public class Bindings: NinjectModule
    {
        public override void Load()
        {
            Bind<TarjetasDeCreditoDbContext>().ToSelf().InSingletonScope();
            Bind<IUnitOfWork>().To<UnitOfWork>();

            Bind<IRepositorioProvincias>().To<RepositorioProvincias>();
            Bind<IServiciosProvincia>().To<ServiciosProvincia>();

            Bind<IRepositorioTipoDocumentos>().To<RepositorioTipoDocumento>();
            Bind<IServiciosTipoDocumento>().To<ServiciosTipoDocumento>();

            Bind<IRepositorioCarterasConsumos>().To<RepositorioCarteraConsumo>();
            Bind<IServiciosCarteraConsumo>().To<ServiciosCarteraConsumo>();

        }
    }
}
