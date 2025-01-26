using FluentResults;
using Microsoft.EntityFrameworkCore;
using WatchList.Dtos;
using WatchList.Models;
using WatchList.Services.Interfaces;

namespace WatchList.Services
{
    public class WatchService : IWatchService
    {
        private readonly ApplicationDbContext _dbContext;

        public WatchService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<Watch>> GetWatchByIdAsync(int watchId)
        {
            var watch = await _dbContext.Watch
                .AsNoTracking()
                .FirstOrDefaultAsync(w => w.WatchId == watchId);

            if (watch == null)
            {
                return Result.Fail<Watch>($"Watch with ID {watchId} not found.");
            }

            return Result.Ok(watch);
        }
    }
}
