using AutoMapper;

namespace TarjetaDeCreditoMVC.Mapeador
{
    public class Mapeador
    {
        private static AutoMapper.Mapper _mapper;

        static readonly MapperConfiguration Config = new MapperConfiguration(cfg =>
            cfg.AddProfile<MappingProfile>());

        public static AutoMapper.Mapper CrearMapper()
        {
            _mapper = new AutoMapper.Mapper(Config);
            return _mapper;
        }
    }
}
