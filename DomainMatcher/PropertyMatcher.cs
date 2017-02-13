using System.Collections.Generic;

public class PropertyMatcher : IPropertyMatcher {
    private IList<IPropertyMatcher> _matchers;

    public PropertyMatcher (IList<IPropertyMatcher> matchers) {
        _matchers = matchers;
    }

    public bool IsMatch (Property agencyProperty, Property databaseProperty) {
        foreach (IPropertyMatcher matcher in _matchers) {
            if (matcher.IsMatch(agencyProperty, databaseProperty)) {
                return true;
            }
        }

        return false;
    }
}
