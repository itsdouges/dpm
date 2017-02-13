public class MatchLre : IPropertyMatcher {
    private const decimal CloseThresholdInMetres = 200;
    private const decimal KilometresToTheDegree = 111;
    private const decimal MetresToTheKilometre = 1000;

    private bool IsNear(decimal degrees1, decimal degrees2)
    {
        var degrees1AsMetres = degrees1 * KilometresToTheDegree * MetresToTheKilometre;
        var degrees2AsMetres = degrees2 * KilometresToTheDegree * MetresToTheKilometre;

        return (degrees1AsMetres - degrees2AsMetres) <= CloseThresholdInMetres;
    }

    public bool IsMatch(Property agencyProperty, Property databaseProperty)
    {
        if (agencyProperty.AgencyCode != databaseProperty.AgencyCode)
        {
            return false;
        }

        return IsNear(agencyProperty.Longitude, databaseProperty.Longitude) &&
            IsNear(agencyProperty.Latitude, databaseProperty.Latitude);
    }
}
