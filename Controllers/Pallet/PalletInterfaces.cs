using CSMS_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CSMS_API.Controllers
{
    public interface IPalletController
    {
        Task<ActionResult<PalletOnlyResponse>> CreatePalletAsync(CreatePalletRequest request);
        Task<ActionResult<PalletOnlyResponse>> PatchPalletByIDAsync(int ID, UpdatePalletRequest request);
        Task<ActionResult<PalletOnlyResponse>> PatchPalletStatusByIDAsync(int ID, RecordStatus status);
        Task<ActionResult<PalletOnlyResponse>> PatchPalletOccupationStatusByIDAsync(int ID, PalletOccupationStatus status);
        Task<ActionResult<PalletOnlyResponse>> DeletePalletByIDAsync(int ID);
        Task<ActionResult<PalletOnlyResponse>> GetPalletByIDAsync(int ID);
        Task<Paginate<ActionResult<PalletOnlyResponse>>> GetPaginatedPalletsAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus,
            PalletOccupationStatus? palletOccupationStatus);
        Task<List<ActionResult<PalletOnlyResponse>>> GetListedPalletsAsync(string? searchTerm, RecordStatus? recordStatus, PalletOccupationStatus? palletOccupationStatus);
    }
    public interface IPalletService
    {
        Task<PalletOnlyResponse> CreatePalletAsync(CreatePalletRequest request, ClaimsPrincipal user);
        Task<PalletOnlyResponse> PatchPalletByIDAsync(int ID, UpdatePalletRequest request, ClaimsPrincipal user);
        Task<PalletOnlyResponse> PatchPalletStatusByIDAsync(int ID, RecordStatus status, ClaimsPrincipal user);
        Task<PalletOnlyResponse> PatchPalletOccupationStatusByIDAsync(int ID, PalletOccupationStatus status, ClaimsPrincipal user);
        Task<PalletOnlyResponse> DeletePalletByIDAsync(int ID);
        Task<PalletOnlyResponse> GetPalletByIDAsync(int ID);
        Task<Paginate<PalletOnlyResponse>> GetPaginatedPalletsAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus,
            PalletOccupationStatus? palletOccupationStatus);
        Task<List<PalletOnlyResponse>> GetListedPalletsAsync(string? searchTerm, RecordStatus? recordStatus, PalletOccupationStatus? palletOccupationStatus);
    }
    public interface IPalletQueries
    {
        Task<Pallet?> PatchPalletByIDAsync(int ID);
        Task<PalletOnlyResponse?> PalletOnlyResponseByIDAsync(int ID);
        IQueryable<PalletOnlyResponse> PalletOnlyResponseAsync(string? searchTerm, RecordStatus? recordStatus, PalletOccupationStatus? palletOccupationStatus);
    }
}