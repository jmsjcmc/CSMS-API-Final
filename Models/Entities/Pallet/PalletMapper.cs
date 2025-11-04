using AutoMapper;

namespace CSMS_API.Models
{
    public class PalletMapper : Profile
    {
        public PalletMapper()
        {
            CreateMap<CreatePalletRequest, Pallet>();
            CreateMap<UpdatePalletRequest, Pallet>();
            CreateMap<Pallet, PalletOnlyResponse>();
        }
    }
    public class PalletPositionMapper : Profile
    {
        public PalletPositionMapper()
        {
            CreateMap<CreatePalletPositionRequest, PalletPosition>();
            CreateMap<UpdatePalletPositionRequest, PalletPosition>();
            CreateMap<PalletPosition, PalletPositionOnlyResponse>();
            CreateMap<PalletPosition, PalletPositionWithColdStorageResponse>()
                .ForMember(d => d.ColdStorageID, o => o.MapFrom(s => s.ColdStorage.ID))
                .ForMember(d => d.ColdStorageNumber, o => o.MapFrom(s => s.ColdStorage.Number));
            CreateMap<PalletPosition, PalletPositionWithColdStorageObjectResponse>()
                .ForMember(d => d.ColdStorage, o => o.MapFrom(s => s.ColdStorage));
        }
    }
    public class ColdStorageMapper : Profile
    {
        public ColdStorageMapper()
        {
            CreateMap<ColdStorage, ColdStorageOnlyResponse>();
        }
    }
}