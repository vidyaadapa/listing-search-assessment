using backend.Models;

namespace backend.Services;

public class RelevanceScorer
{
    public double CalculateScore(Listing listing, decimal? targetBudget)
    {
        double budgetScore = 1.0;

        if (targetBudget.HasValue && targetBudget.Value > 0)
        {
            var difference = Math.Abs(listing.Price - targetBudget.Value);
            budgetScore = Math.Max(
                0,
                1 - (double)(difference / targetBudget.Value)
            );
        }

        var ageInDays = Math.Max(
            0,
            (DateTime.UtcNow.Date - listing.ListedDate.Date).TotalDays
        );

        var recencyScore = Math.Max(
            0,
            1 - (ageInDays / 90.0)
        );

        return Math.Round(
            (0.7 * budgetScore) + (0.3 * recencyScore),
            4
        );
    }
}