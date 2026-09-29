using backend.Models;

namespace backend.Data;

public static class ListingRepository
{
    public static List<Listing> Listings { get; } =
    [
        new Listing
        {
            Id = "A1",
            Source = "MLS_A",
            Address = "123 Main St, Apt 4B",
            City = "Springfield",
            State = "VA",
            Zip = "22150",
            Price = 450000,
            Bedrooms = 2,
            Bathrooms = 1.5,
            Sqft = 980,
            Latitude = 38.7893,
            Longitude = -77.1873,
            ListedDate = new DateTime(2026, 8, 29),
            Status = "active",
            Description = "Bright top-floor condo near shops and transit. Pet friendly."
        },
        new Listing
        {
            Id = "B7",
            Source = "MLS_B",
            Address = "123 Main Street, Unit 4B",
            City = "Springfield",
            State = "VA",
            Zip = "22150",
            Price = 452000,
            Bedrooms = 2,
            Bathrooms = 1.5,
            Sqft = 980,
            Latitude = 38.7893,
            Longitude = -77.1873,
            ListedDate = new DateTime(2026, 8, 27),
            Status = "active",
            Description = "Top floor condo, walk to shopping. Pets allowed."
        },
        new Listing
        {
            Id = "A2",
            Source = "MLS_A",
            Address = "456 Oak Ave",
            City = "Springfield",
            State = "VA",
            Zip = "22150",
            Price = 525000,
            Bedrooms = 3,
            Bathrooms = 2.0,
            Sqft = 1450,
            Latitude = 38.7791,
            Longitude = -77.1901,
            ListedDate = new DateTime(2026, 9, 2),
            Status = "active",
            Description = "Updated kitchen, fenced yard, close to schools."
        },
        new Listing
        {
            Id = "B8",
            Source = "MLS_B",
            Address = "456 Oak Avenue",
            City = "Springfield",
            State = "VA",
            Zip = "22151",
            Price = 527500,
            Bedrooms = 3,
            Bathrooms = 2.0,
            Sqft = 1450,
            Latitude = 38.7791,
            Longitude = -77.1901,
            ListedDate = new DateTime(2026, 8, 30),
            Status = "active",
            Description = "Renovated kitchen, fenced backyard, near schools."
        },
        new Listing
        {
            Id = "A3",
            Source = "MLS_A",
            Address = "789 Pine Rd",
            City = "Fairfax",
            State = "VA",
            Zip = "22030",
            Price = 399000,
            Bedrooms = 2,
            Bathrooms = 1.0,
            Sqft = 850,
            Latitude = 38.8462,
            Longitude = -77.3064,
            ListedDate = new DateTime(2026, 9, 1),
            Status = "active",
            Description = "Cozy starter home, no pets."
        },
        new Listing
    {
        Id = "B9",
        Source = "MLS_B",
        Address = "789 Pine Rd",
        City = "Fairfax",
        State = "VA",
        Zip = "22030",
        Price = 399500,
        Bedrooms = 2,
        Bathrooms = 1.0,
        Sqft = 850,
        Latitude = 38.8462,
        Longitude = -77.3064,
        ListedDate = new DateTime(2026, 8, 25),
        Status = "active",
        Description = "Cozy starter home, pets not permitted."
    },
    new Listing
    {
        Id = "A4",
        Source = "MLS_A",
        Address = "22 Birch Ln",
        City = "Reston",
        State = "VA",
        Zip = "20190",
        Price = 610000,
        Bedrooms = 4,
        Bathrooms = 3.0,
        Sqft = 2100,
        Latitude = 38.9586,
        Longitude = -77.3570,
        ListedDate = new DateTime(2026, 9, 3),
        Status = "active",
        Description = "Spacious family home near Reston Town Center. Pets welcome."
    },
    new Listing
    {
        Id = "B10",
        Source = "MLS_B",
        Address = "100 Maple Dr",
        City = "Reston",
        State = "VA",
        Zip = "20190",
        Price = 585000,
        Bedrooms = 3,
        Bathrooms = 2.5,
        Sqft = 1900,
        Latitude = 38.9601,
        Longitude = -77.3499,
        ListedDate = new DateTime(2026, 8, 20),
        Status = "active",
        Description = "Townhome with 2-car garage, community pool."
    },
    new Listing
    {
        Id = "A5",
        Source = "MLS_A",
        Address = "55 Elm Ct",
        City = "Vienna",
        State = "VA",
        Zip = "22180",
        Price = 470000,
        Bedrooms = 3,
        Bathrooms = 2.0,
        Sqft = 1300,
        Latitude = 38.9012,
        Longitude = -77.2653,
        ListedDate = new DateTime(2026, 9, 4),
        Status = "active",
        Description = "Quiet cul-de-sac, walkable to Metro. No pets."
    },
    new Listing
    {
        Id = "B11",
        Source = "MLS_B",
        Address = "55 Elm Court",
        City = "Vienna",
        State = "VA",
        Zip = "22180",
        Price = 465000,
        Bedrooms = 3,
        Bathrooms = 2.0,
        Sqft = 1300,
        Latitude = 38.9012,
        Longitude = -77.2653,
        ListedDate = new DateTime(2026, 8, 15),
        Status = "active",
        Description = "Peaceful street, close to Metro. Pet restrictions apply."
    },
    new Listing
    {
        Id = "A6",
        Source = "MLS_A",
        Address = "300 Cedar Blvd",
        City = "Manassas",
        State = "VA",
        Zip = "20110",
        Price = 415000,
        Bedrooms = 3,
        Bathrooms = 2.0,
        Sqft = 1600,
        Latitude = 38.7509,
        Longitude = -77.4753,
        ListedDate = new DateTime(2026, 8, 10),
        Status = "active",
        Description = "Split-level home, large driveway, pets allowed."
    },
    new Listing
    {
        Id = "A7",
        Source = "MLS_A",
        Address = "42 Willow Way",
        City = "Chantilly",
        State = "VA",
        Zip = "20151",
        Price = 540000,
        Bedrooms = 4,
        Bathrooms = 2.5,
        Sqft = 1950,
        Latitude = 38.8909,
        Longitude = -77.4316,
        ListedDate = new DateTime(2026, 7, 28),
        Status = "pending",
        Description = "Corner lot, recently painted, no pets due to HOA."
    }
    ];
}