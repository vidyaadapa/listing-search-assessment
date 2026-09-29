namespace backend.Models;

public class ListingSearchResult
{
    public string Id { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Bedrooms { get; set; }
    public DateTime ListedDate { get; set; }
    public double RelevanceScore { get; set; }
}

public class PagedListingResponse
{
    public List<ListingSearchResult> Items { get; set; } = [];
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
}