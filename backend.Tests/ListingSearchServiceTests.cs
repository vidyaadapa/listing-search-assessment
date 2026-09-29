using backend.Models;
using backend.Services;

namespace backend.Tests;

public class ListingSearchServiceTests
{
    private ListingSearchService CreateService()
    {
        var scorer = new RelevanceScorer();
        return new ListingSearchService(scorer);
    }

    [Fact]
    public void Search_ReturnsNoMatches_ForUnknownCity()
    {
        var service = CreateService();

        var request = new ListingSearchRequest
        {
            City = "Seattle"
        };

        var result = service.Search(request);

        Assert.Empty(result.Items);
        Assert.Equal(0, result.TotalItems);
    }

    [Fact]
    public void Search_Throws_WhenMinPriceGreaterThanMaxPrice()
    {
        var service = CreateService();

        var request = new ListingSearchRequest
        {
            MinPrice = 600000,
            MaxPrice = 400000
        };

        Assert.Throws<ArgumentException>(() =>
            service.Search(request)
        );
    }

    [Fact]
    public void Search_Throws_WhenPageSizeIsZero()
    {
        var service = CreateService();

        var request = new ListingSearchRequest
        {
            PageSize = 0
        };

        Assert.Throws<ArgumentException>(() =>
            service.Search(request)
        );
    }

    [Fact]
    public void Search_PaginatesResults()
    {
        var service = CreateService();

        var request = new ListingSearchRequest
        {
            Page = 1,
            PageSize = 3
        };

        var result = service.Search(request);

        Assert.Equal(3, result.Items.Count);
        Assert.Equal(12, result.TotalItems);
        Assert.Equal(4, result.TotalPages);
    }

    [Fact]
    public void Search_UsesDeterministicOrdering_WhenScoresTie()
    {
        var service = CreateService();

        var request = new ListingSearchRequest
        {
            TargetBudget = 500000,
            PageSize = 20
        };

        var result1 = service.Search(request);
        var result2 = service.Search(request);

        var ids1 = result1.Items.Select(x => x.Id).ToList();
        var ids2 = result2.Items.Select(x => x.Id).ToList();

        Assert.Equal(ids1, ids2);
    }
}