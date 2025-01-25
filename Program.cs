using WatchList.Dtos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
// Register services for Watch functionality
builder.Services.AddScoped<IWatchService, WatchService>();
builder.Services.AddScoped<IWatchRepository, WatchRepository>(); // Your repository for watch data
builder.Services.AddScoped<IUploadService, UploadService>(); // Upload service for managing images (if needed)

// Add OpenAPI support for documentation
builder.Services.AddOpenApi();

// Add Controllers (important for REST API endpoints)
builder.Services.AddControllers();

// Azure-related services - Add these if you're integrating Azure features
// Example: Register Azure Blob Storage, API Management, etc.
builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddBlobServiceClient(builder.Configuration.GetSection("AzureBlobStorage"));
    // Add other Azure clients like Service Bus or Function clients here if needed
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    // OpenAPI documentation
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Map your Watch API endpoints
app.MapControllers();

// Sample WatchController for handling watch-related requests
app.MapPost("/api/watches", async (IWatchService watchService, WatchDto watchDto) =>
{
    var result = await watchService.AddWatchAsync(watchDto);
    if (result.Success)
    {
        return Results.Created($"/api/watches/{result.Watch.Id}", result.Watch);
    }
    return Results.BadRequest(result.Message);
});

app.MapGet("/api/watches/{id}", async (IWatchService watchService, int id) =>
{
    var watch = await watchService.GetWatchByIdAsync(id);
    if (watch == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(watch);
});

app.MapPut("/api/watches/{id}", async (IWatchService watchService, int id, WatchDto watchDto) =>
{
    var result = await watchService.UpdateWatchAsync(id, watchDto);
    if (result.Success)
    {
        return Results.Ok(result.Watch);
    }
    return Results.BadRequest(result.Message);
});

// Run the app
app.Run();
