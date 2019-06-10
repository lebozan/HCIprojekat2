using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ResourcesApplication.Beans;
namespace ResourcesApplication.Validation
{
    public class TypeIdValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            Database db = new Database();
            db.serijalizacija.RESOURCES_DATA = "resources.bin";
            db.deserijalizacija.RESOURCES_DATA = "resources.bin";
            db.loadData();
            try
            {
                var text = value as string;
                foreach (ResourceType tp in db.Types)
                {
                    if (tp.Id.Equals(text))
                    {
                        return new ValidationResult(false, "id mora biti jedinstven");
                    }
                }

                return new ValidationResult(true, "");
            }
            catch
            {
                return new ValidationResult(false, "Desila se neočekivana greška.");
            }
        }
    }
}
