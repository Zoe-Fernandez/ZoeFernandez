namespace TarjetaDeCreditoMVC.Datos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TarjetasDeCreditoDbContext _context;

        public UnitOfWork(TarjetasDeCreditoDbContext context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
