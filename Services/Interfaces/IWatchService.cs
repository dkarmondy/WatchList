using FluentResults;
using WatchList.Dtos;
using WatchList.Models;

namespace WatchList.Services.Interfaces
{
    public interface IWatchService
    {
        //Task<Result<Watch>> AddWatchAsync(WatchDto watchDto);
        //Task<Result<Watch>> UpdateWatchAsync(int id, WatchDto watchDto);
        Task<Result<Watch>> GetWatchByIdAsync(int id);
        //Task<IEnumerable<Watch>> GetAllWatchesAsync();
    }
}
