using System.Globalization;
using System.Windows.Controls;

namespace GraphicalData.View.Validators
{
    public class NotNullAndEmptyString : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if ( ((string)value).Length == 0)
            {
                return new ValidationResult(false, "Name cannot be empty!");
            }
            if ( ((string)value) == null)
            {
                return new ValidationResult(false, "Name cannot be null!");
            }
            return new ValidationResult(true, null);
        }

    }
}
