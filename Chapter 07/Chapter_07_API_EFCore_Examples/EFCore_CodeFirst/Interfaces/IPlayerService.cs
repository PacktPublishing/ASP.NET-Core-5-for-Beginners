using EFCore_CodeFirst.Dto;
using EFCore_CodeFirst.Dto.Players;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore_CodeFirst.Interfaces
{
    public interface IPlayerService
    {
        Task CreatePlayerAsync(CreatePlayerRequest playerRequest);
        Task<bool> UpdatePlayerAsync(int id, UpdatePlayerRequest playerRequest);
        Task<bool> DeletePlayerAsync(int id);
        Task<GetPlayerDetailResponse> GetPlayerDetailAsync(int id);
        Task<PagedResponse<GetPlayerResponse>> GetPlayersAsync(UrlQueryParameters urlQueryParameters);
    }
}


