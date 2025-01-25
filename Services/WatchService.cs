using FluentResults;
using WatchList.Dtos;
using WatchList.Models;

public class WatchService : IWatchService
{
    private readonly IWatchRepository _watchRepository;
    private readonly IUploadService _uploadService;

    public WatchService(IWatchRepository watchRepository, IUploadService uploadService)
    {
        _watchRepository = watchRepository;
        _uploadService = uploadService;
    }

    public async Task<Result<Watch>> AddWatchAsync(WatchDto watchDto)
    {
        // Handle image upload if present
        if (watchDto.ImageUrl != null)
        {
            var imageUrl = await _uploadService.UploadImageAsync(watchDto.ImageUrl);
            watchDto.ImageUrl = imageUrl;
        }

        var watch = new Watch
        {
            Brand = watchDto.Brand,
            Model = watchDto.Model,
            Price = watchDto.Price,
            ImageUrl = watchDto.ImageUrl
        };

        await _watchRepository.AddWatchAsync(watch);

        return new Result<Watch> { Success = true, Watch = watch };
    }
}
