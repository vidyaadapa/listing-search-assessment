using backend.Data;
using backend.Models;

namespace backend.Services;

public class ListingSearchService
{
    private readonly RelevanceScorer _scorer;

    public ListingSearchService(RelevanceScorer scorer)
    {
        _scorer = scorer;
    }

    public PagedListingResponse Search(ListingSearchRequest request)
    {
        if (request.MinPrice.HasValue &&
            request.MaxPrice.HasValue &&
            request.MinPrice > request.MaxPrice)
        {
            throw new ArgumentException("minPrice cannot be greater than maxPrice.");
        }

        if (request.Page <= 0)
        {
            throw new ArgumentException("page must be greater than 0.");
        }

        if (request.PageSize <= 0)
        {
            throw new ArgumentException("pageSize must be greater than 0.");
        }

        var query = ListingRepository.Listings.AsEnumerable();

        if (request.MinPrice.HasValue)
        {
            query = query.Where(x => x.Price >= request.MinPrice.Value);
        }

        if (request.MaxPrice.HasValue)
        {
            query = query.Where(x => x.Price <= request.MaxPrice.Value);
        }

        if (request.MinBedrooms.HasValue)
        {
            query = query.Where(x => x.Bedrooms >= request.MinBedrooms.Value);
        }

        if (!string.IsNullOrWhiteSpace(request.City))
        {
            query = query.Where(x =>
                x.City.Equals(
                    request.City,
                    StringComparison.OrdinalIgnoreCase
                )
            );
        }

        if (!string.IsNullOrWhiteSpace(request.Keyword))
        {
            query = query.Where(x =>
                x.Description.Contains(
                    request.Keyword,
                    StringComparison.OrdinalIgnoreCase
                )
            );
        }

        var rankedResults = query
            .Select(x => new ListingSearchResult
            {
                Id = x.Id,
                Source = x.Source,
                Address = x.Address,
                City = x.City,
                Price = x.Price,
                Bedrooms = x.Bedrooms,
                ListedDate = x.ListedDate,
                RelevanceScore = _scorer.CalculateScore(
                    x,
                    request.TargetBudget
                )
            })
            .OrderByDescending(x => x.RelevanceScore)
            .ThenByDescending(x => x.ListedDate)
            .ThenBy(x => x.Id)
            .ToList();

        var totalItems = rankedResults.Count;

        var items = rankedResults
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();

        return new PagedListingResponse
        {
            Items = items,
            Page = request.Page,
            PageSize = request.PageSize,
            TotalItems = totalItems,
            TotalPages = (int)Math.Ceiling(
                totalItems / (double)request.PageSize
            )
        };
    }
}