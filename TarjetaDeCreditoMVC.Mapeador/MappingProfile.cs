using AutoMapper;
using TarjetaDeCreditoMVC.Entidades.DTOs.CarteraConsumo;
using TarjetaDeCreditoMVC.Entidades.DTOs.Provincia;
using TarjetaDeCreditoMVC.Entidades.DTOs.TipoDocumento;
using TarjetaDeCreditoMVC.Entidades.Entidades;
using TarjetaDeCreditoMVC.Entidades.ViewModels.CarteraConsumo;
using TarjetaDeCreditoMVC.Entidades.ViewModels.Provincia;
using TarjetaDeCreditoMVC.Entidades.ViewModels.TipoDocumento;

namespace TarjetaDeCreditoMVC.Mapeador
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            LoadTipoDocumentoMapping();
            LoadProvinciasMapping();
            LoadCarteraConsumoMapping();
        }

        private void LoadCarteraConsumoMapping()
        {
            CreateMap<CarteraDeConsumo, CarteraConsumoListDto>();
            CreateMap<CarteraDeConsumo, CarteraConsumoEditDto>().ReverseMap();
            CreateMap<CarteraConsumoListDto, CarteraConsumoListViewModel>().ReverseMap();
            CreateMap<CarteraConsumoEditDto, CarteraConsumoEditViewModel>().ReverseMap();
            CreateMap<CarteraConsumoEditDto, CarteraConsumoListDto>().ReverseMap();
        }

        private void LoadTipoDocumentoMapping()
        {
            CreateMap<TipoDeDocumento, TipoDocumentoListDto>();
            CreateMap<TipoDeDocumento, TipoDocumentoEditDto>().ReverseMap();
            CreateMap<TipoDocumentoListDto, TipoDocumentoListViewModel>().ReverseMap();
            CreateMap<TipoDocumentoEditDto, TipoDocumentoEditViewModel>().ReverseMap();
            CreateMap<TipoDocumentoEditDto, TipoDocumentoListDto>().ReverseMap();
        }

        private void LoadProvinciasMapping()
        {
            CreateMap<Provincia, ProvinciaListDto>();
            CreateMap<Provincia, ProvinciaEditDto>().ReverseMap();
            CreateMap<ProvinciaListDto, ProvinciaListViewModel>().ReverseMap();
            CreateMap<ProvinciaEditDto, ProvinciasEditViewModel>().ReverseMap();
            CreateMap<ProvinciaEditDto, ProvinciaListDto>().ReverseMap();
        }
    }
}
