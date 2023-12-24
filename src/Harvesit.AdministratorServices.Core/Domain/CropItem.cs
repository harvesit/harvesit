﻿using System.Globalization;

/// <summary>
/// Related entities and other classes (like GrowingConditions, NutritionalInformation, UserRating, SeasonalAvailability) would be defined separately.
/// </summary>
public class CropItem
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string ScientificName { get; private set; }
    public Dictionary<CultureInfo, string> LocalizedName { get; private set; }
    public string Variety { get; private set; }
    public string Description { get; private set; }
    //public GrowingConditions GrowingConditions { get; private set; }
    public string HarvestTime { get; private set; }
    public List<string> PotentialPests { get; private set; }
    public Uri ImageURL { get; private set; }
    //public NutritionalInformation NutritionalInformation { get; private set; }
    public List<Uri> RecommendedRecipes { get; private set; }
    //public List<UserRating> UserRatings { get; private set; }
    //public SeasonalAvailability SeasonalAvailability { get; private set; }

    public CropItem(Guid id, string name, string scientificName, string variety,
                    string description, string harvestTime, Uri imageURL)
    {
        ValidateId(id);
        ValidateString(name, "Name");
        ValidateString(scientificName, "Scientific Name");
        ValidateString(variety, "Variety", false);
        ValidateString(description, "Description");
        ValidateString(harvestTime, "Harvest Time");
        ValidateUri(imageURL, "Image URL");

        Id = id;
        Name = name;
        ScientificName = scientificName;
        Variety = variety;
        Description = description;
        HarvestTime = harvestTime;
        ImageURL = imageURL;

        LocalizedName = new Dictionary<CultureInfo, string>();
        PotentialPests = new List<string>();
        RecommendedRecipes = new List<Uri>();
        //UserRatings = new List<UserRating>();
    }

    public void AddLocalizedName(CultureInfo locale, string name)
    {
        ValidateString(name, "Localized Name");
        if (locale == null) throw new ArgumentNullException(nameof(locale));

        LocalizedName[locale] = name;
    }

    //public void UpdateGrowingConditions(GrowingConditions conditions)
    //{
    //    // Validation logic for GrowingConditions
    //    GrowingConditions = conditions ?? throw new ArgumentNullException(nameof(conditions));
    //}

    //public void AddUserRating(UserRating rating)
    //{
    //    // Validation logic for UserRating
    //    UserRatings.Add(rating ?? throw new ArgumentNullException(nameof(rating)));
    //}

    //public double CalculateAverageRating()
    //{
    //    if (UserRatings.Count == 0) return 0;
    //    return UserRatings.Average(r => r.Rating);
    //}

    //public bool IsInSeason(int currentMonth)
    //{
    //    if (currentMonth < 1 || currentMonth > 12)
    //        throw new ArgumentOutOfRangeException(nameof(currentMonth), "Month must be between 1 and 12");

    //    return SeasonalAvailability.IsInSeason(currentMonth);
    //}

    private void ValidateId(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Id must be a non-empty GUID", nameof(id));
    }

    private void ValidateString(string value, string fieldName, bool required = true)
    {
        if (required && string.IsNullOrWhiteSpace(value))
            throw new ArgumentException($"{fieldName} cannot be null or empty.", nameof(value));
    }

    private void ValidateUri(Uri uri, string fieldName)
    {
        if (uri == null || !uri.IsAbsoluteUri)
            throw new ArgumentException($"{fieldName} must be a valid URL.", nameof(uri));
    }
}
