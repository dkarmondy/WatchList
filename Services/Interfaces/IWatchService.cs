using FluentResults;
using WatchList.Dtos;
using WatchList.Models;

public interface IWatchService
{
    Task<Result<Watch>> AddWatchAsync(WatchDto watchDto);
    Task<Result<Watch>> UpdateWatchAsync(int id, WatchDto watchDto);
    Task<Watch> GetWatchByIdAsync(int id);
    Task<IEnumerable<Watch>> GetAllWatchesAsync();
}
