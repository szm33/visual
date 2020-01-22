using System.Globalization;
using System.Windows.Controls;

namespace GraphicalData.View.Validators
{
    public class NotNullAndLowerThanZero : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (int.TryParse(value.ToString(), out int i))
            {
                if (i <= 0)
                {
                    return new ValidationResult(false, "ID cannot be lower than or equal to 0");
                }
                
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "ID has to be a number!");


        }
    }
}
