using Microsoft.AspNetCore.Mvc;
using WatchList.Dtos;

[ApiController]
[Route("api/[controller]")]
public class WatchController : ControllerBase
{
    private readonly IWatchService _watchService;

    public WatchController(IWatchService watchService)
    {
        _watchService = watchService;
    }

    [HttpPost]
    public async Task<IActionResult> AddWatch([FromBody] WatchDto watch)
    {
        var result = await _watchService.AddWatchAsync(watch);
        if (result.Success)
        {
            return CreatedAtAction(nameof(GetWatch), new { id = result.Watch.Id }, result.Watch);
        }
        return BadRequest(result.Message);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetWatch(int id)
    {
        var watch = await _watchService.GetWatchByIdAsync(id);
        if (watch == null)
        {
            return NotFound();
        }
        return Ok(watch);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateWatch(int id, [FromBody] WatchDto watch)
    {
        var result = await _watchService.UpdateWatchAsync(id, watch);
        if (result.Success)
        {
            return Ok(result.Watch);
        }
        return BadRequest(result.Message);
    }
}
