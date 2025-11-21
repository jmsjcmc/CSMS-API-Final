using AutoMapper;

namespace CSMS_API.Models
{
    public class PalletMapper : Profile
    {
        public PalletMapper()
        {
            CreateMap<CreatePalletRequest, Pallet>();
            CreateMap<UpdatePalletRequest, Pallet>();
        }
    }
    public class PalletPositionMapper : Profile
    {
        public PalletPositionMapper()
        {
            CreateMap<CreatePalletPositionRequest, PalletPosition>();
            CreateMap<UpdatePalletPositionRequest, PalletPosition>();
        }
    }
    public static class ManualPalletMapping
    {
        public static PalletOnlyResponse ManualPalletOnlyResponse(Pallet pallet)
        {
            return new PalletOnlyResponse
            {
                ID = pallet.ID,
                Type = pallet.Type,
                Number = pallet.Number,
                CreatedOn = pallet.CreatedOn,
                RecordStatus = pallet.RecordStatus,
                PalletOccupationStatus = pallet.PalletOccupationStatus
            };
        }
        public static List<PalletOnlyResponse> ManualPalletOnlyListResponse(List<Pallet> pallets)
        {
            return pallets
                .Select(ManualPalletOnlyResponse)
                .ToList();
        }
        public static PalletPositionOnlyResponse ManualPalletPositionOnlyResponse(PalletPosition palletPosition)
        {
            return new PalletPositionOnlyResponse
            {
                ID = palletPosition.ID,
                Wing = palletPosition.Wing,
                Floor = palletPosition.Floor,
                Column = palletPosition.Column,
                Side = palletPosition.Side,
                CreatedOn = palletPosition.CreatedOn,
                RecordStatus = palletPosition.RecordStatus,
                PalletPositionStatus = palletPosition.PalletPositionStatus
            };
        }
        public static List<PalletPositionOnlyResponse> ManualPalletPositionOnlyListResponse(List<PalletPosition> palletPositions)
        {
            return palletPositions
                .Select(ManualPalletPositionOnlyResponse)
                .ToList();
        }
        public static PalletPositionWithColdStorageResponse ManualPalletPositionWithColdStorageResponse(PalletPosition palletPosition)
        {
            return new PalletPositionWithColdStorageResponse
            {
                ID = palletPosition.ID,
                ColdStorageID = palletPosition.ColdStorageID,
                ColdStorageNumber = palletPosition.ColdStorage.Number,
                Wing = palletPosition.Wing,
                Floor = palletPosition.Floor,
                Column = palletPosition.Column,
                Side = palletPosition.Side,
                CreatedOn = palletPosition.CreatedOn,
                RecordStatus = palletPosition.RecordStatus,
                PalletPositionStatus = palletPosition.PalletPositionStatus
            };
        }
        public static List<PalletPositionWithColdStorageResponse> ManualPalletPositionWithColdStorageListResponse(List<PalletPosition> palletPositions)
        {
            return palletPositions
                .Select(ManualPalletPositionWithColdStorageResponse)
                .ToList();
        }
        public static PalletPositionWithColdStorageObjectResponse ManualPalletPositionWithColdStorageObjectResponse(PalletPosition palletPosition)
        {
            return new PalletPositionWithColdStorageObjectResponse
            {
                ID = palletPosition.ID,
                Wing = palletPosition.Wing,
                Floor = palletPosition.Floor,
                Column = palletPosition.Column,
                Side = palletPosition.Side,
                CreatedOn = palletPosition.CreatedOn,
                RecordStatus = palletPosition.RecordStatus,
                PalletPositionStatus = palletPosition.PalletPositionStatus,
                ColdStorage = palletPosition.ColdStorage != null
                ? ManualColdStorageMapping.ManualColdStorageOnlyResponse(palletPosition.ColdStorage)
                : null
            };
        }
        public static List<PalletPositionWithColdStorageObjectResponse> ManualPalletPositionWithColdStorageObjectListResponse(List<PalletPosition> palletPositions)
        {
            return palletPositions
                .Select(ManualPalletPositionWithColdStorageObjectResponse)
                .ToList();
        }
    }
    public static class ManualColdStorageMapping
    {
        public static ColdStorageOnlyResponse ManualColdStorageOnlyResponse(ColdStorage coldStorage)
        {
            return new ColdStorageOnlyResponse
            {
                ID = coldStorage.ID,
                Number = coldStorage.Number,
                CreatedOn = coldStorage.CreatedOn,
                RecordStatus = coldStorage.RecordStatus
            };
        }
        public static List<ColdStorageOnlyResponse> ManualColdStorageOnlyListResponse(List<ColdStorage> coldStorages)
        {
            return coldStorages
                .Select(ManualColdStorageOnlyResponse)
                .ToList();
        }
    }
}