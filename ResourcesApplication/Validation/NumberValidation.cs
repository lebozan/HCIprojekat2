using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Threading.Tasks;

namespace ResourcesApplication.Validation
{
    public class NumberValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {

            try
            {
                int broj = int.Parse(value as string);

                if (broj < 0)
                {
                    return new ValidationResult(false, "Cena mora biti pozitivna");
                }
                else
                {
                    return new ValidationResult(true, "");
                }

            }
            catch
            {
                return new ValidationResult(false, "Cena mora biti broj.");
            }
        }
    }
}

