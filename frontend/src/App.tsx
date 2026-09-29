import { useState } from "react";

type Listing = {
  id: string;
  source: string;
  address: string;
  city: string;
  price: number;
  bedrooms: number;
  listedDate: string;
  relevanceScore: number;
};

type SearchResponse = {
  items: Listing[];
  page: number;
  pageSize: number;
  totalItems: number;
  totalPages: number;
};

function App() {
  const [minPrice, setMinPrice] = useState("");
  const [maxPrice, setMaxPrice] = useState("");
  const [minBedrooms, setMinBedrooms] = useState("");
  const [city, setCity] = useState("");
  const [keyword, setKeyword] = useState("");
  const [targetBudget, setTargetBudget] = useState("");

  const [results, setResults] = useState<Listing[]>([]);
  const [page, setPage] = useState(1);
  const [totalPages, setTotalPages] = useState(0);

  const [loading, setLoading] = useState(false);
  const [error, setError] = useState("");

  async function searchListings(searchPage = 1) {
    setLoading(true);
    setError("");

    const params = new URLSearchParams();

    if (minPrice) params.append("minPrice", minPrice);
    if (maxPrice) params.append("maxPrice", maxPrice);
    if (minBedrooms) params.append("minBedrooms", minBedrooms);
    if (city) params.append("city", city);
    if (keyword) params.append("keyword", keyword);
    if (targetBudget) params.append("targetBudget", targetBudget);

    params.append("page", searchPage.toString());
    params.append("pageSize", "5");

    try {
      const response = await fetch(
        `http://localhost:5228/api/listings?${params.toString()}`
      );

      const data = await response.json();

      if (!response.ok) {
        throw new Error(data.error || "Search failed");
      }

      const searchResponse = data as SearchResponse;

      setResults(searchResponse.items);
      setPage(searchResponse.page);
      setTotalPages(searchResponse.totalPages);
    } catch (err) {
      setResults([]);

      if (err instanceof Error) {
        setError(err.message);
      } else {
        setError("Something went wrong");
      }
    } finally {
      setLoading(false);
    }
  }

  return (
    <div style={{ padding: "20px", maxWidth: "700px", margin: "0 auto" }}>
      <h1>Listing Search</h1>

      <div>
        <label>Min Price</label>
        <br />
        <input
          type="number"
          value={minPrice}
          onChange={(e) => setMinPrice(e.target.value)}
        />
      </div>

      <div>
        <label>Max Price</label>
        <br />
        <input
          type="number"
          value={maxPrice}
          onChange={(e) => setMaxPrice(e.target.value)}
        />
      </div>

      <div>
        <label>Minimum Bedrooms</label>
        <br />
        <input
          type="number"
          value={minBedrooms}
          onChange={(e) => setMinBedrooms(e.target.value)}
        />
      </div>

      <div>
        <label>City</label>
        <br />
        <input
          type="text"
          value={city}
          onChange={(e) => setCity(e.target.value)}
        />
      </div>

      <div>
        <label>Keyword</label>
        <br />
        <input
          type="text"
          value={keyword}
          onChange={(e) => setKeyword(e.target.value)}
        />
      </div>

      <div>
        <label>Target Budget</label>
        <br />
        <input
          type="number"
          value={targetBudget}
          onChange={(e) => setTargetBudget(e.target.value)}
        />
      </div>

      <button
        style={{ marginTop: "20px" }}
        onClick={() => searchListings(1)}
      >
        Search
      </button>

      {loading && <p>Loading...</p>}

      {error && <p>{error}</p>}

      {!loading && !error && results.length === 0 && (
        <p>No listings found.</p>
      )}

      {results.map((listing) => (
        <div key={`${listing.source}-${listing.id}`}>
          <hr />
          <h3>{listing.address}</h3>
          <p>City: {listing.city}</p>
          <p>Price: ${listing.price.toLocaleString()}</p>
          <p>Bedrooms: {listing.bedrooms}</p>
          <p>Score: {listing.relevanceScore}</p>
        </div>
      ))}

      {results.length > 0 && (
        <div style={{ marginTop: "20px" }}>
          <button
            disabled={page <= 1}
            onClick={() => searchListings(page - 1)}
          >
            Previous
          </button>

          <span style={{ margin: "0 10px" }}>
            Page {page} of {totalPages}
          </span>

          <button
            disabled={page >= totalPages}
            onClick={() => searchListings(page + 1)}
          >
            Next
          </button>
        </div>
      )}
    </div>
  );
}

export default App;