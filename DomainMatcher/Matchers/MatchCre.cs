using DomainMatcher.Lib;

public class MatchCre : IPropertyMatcher
{
    public bool IsMatch(Property agencyProperty, Property databaseProperty)
    {
        return agencyProperty.Name.ReverseWords() == databaseProperty.Name;
    }
}
