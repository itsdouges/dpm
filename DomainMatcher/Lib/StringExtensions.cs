using System;
using System.Text.RegularExpressions;

namespace DomainMatcher.Lib
{
    public static class StringExtensions
    {
        public static string CleanPunctuation(this string value)
        {
            var regex = new Regex(@"[~!@#\\$%\^&\*\(\)_\+\/\{}\[\]:;,'""]");
            var cleanText = regex.Replace(value, String.Empty);
            return cleanText.Replace("-", " ");
        }

        public static string ReverseWords(this string value)
        {
            var sentanceArray = value.Split(' ');
            Array.Reverse(sentanceArray);
            return string.Join(" ", sentanceArray);
        }
    }
}
