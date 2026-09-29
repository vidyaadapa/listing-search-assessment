using backend.Models;
using backend.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<RelevanceScorer>();
builder.Services.AddSingleton<ListingSearchService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("AllowFrontend");

app.MapGet("/api/listings", (
    decimal? minPrice,
    decimal? maxPrice,
    int? minBedrooms,
    string? city,
    string? keyword,
    decimal? targetBudget,
    int? page,
    int? pageSize,
    ListingSearchService searchService) =>
{
    try
    {
        var request = new ListingSearchRequest
        {
            MinPrice = minPrice,
            MaxPrice = maxPrice,
            MinBedrooms = minBedrooms,
            City = city,
            Keyword = keyword,
            TargetBudget = targetBudget,
            Page = page ?? 1,
            PageSize = pageSize ?? 5
        };

        var result = searchService.Search(request);

        return Results.Ok(result);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new
        {
            error = ex.Message
        });
    }
});

app.Run();