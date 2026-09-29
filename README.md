# Listing Search Service

A small full-stack property listing search application built with:

- ASP.NET Core Web API
- React
- TypeScript
- In-memory data storage
- xUnit tests

## Features

Users can search property listings using:

- Minimum price
- Maximum price
- Minimum bedrooms
- City
- Description keyword
- Target budget

Results are ranked by relevance and support pagination.

## Relevance Scoring

The relevance score combines:

- 70% budget match
- 30% listing recency

Budget score measures how close the listing price is to the user's
target budget.

Recency score favors listings posted within the last 90 days.

The final score is:

relevanceScore = (0.7 * budgetScore) + (0.3 * recencyScore)

If no target budget is provided, the budget portion receives full
credit and ranking is primarily affected by recency.

For deterministic ordering, equal scores are sorted by:

1. Newer listed date
2. Listing ID

## Running the Backend

From the backend directory:

```bash
dotnet run