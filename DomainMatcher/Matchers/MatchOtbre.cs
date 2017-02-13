using DomainMatcher.Lib;
using System;

public class MatchOtbre : IPropertyMatcher {
    public bool IsMatch(Property agencyProperty, Property databaseProperty)
    {
        return String.Equals(
            agencyProperty.Address.CleanPunctuation(),
            databaseProperty.Address.CleanPunctuation(),
            StringComparison.InvariantCultureIgnoreCase
        ) && String.Equals(
            databaseProperty.Name.CleanPunctuation(),
            agencyProperty.Name.CleanPunctuation(),
            StringComparison.InvariantCultureIgnoreCase
        );
    }
}
