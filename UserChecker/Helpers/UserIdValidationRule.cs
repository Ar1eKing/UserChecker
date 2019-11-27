using System.Windows.Controls;

namespace UserChecker
{
    public class UserIdValidationRule : ValidationRule
    {
        private static string _regex = "[^0-9]";

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(value.ToString(), _regex))
                return new ValidationResult(true, null);

            return new ValidationResult(false, null);
        }
    }
}