using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ResourcesApplication.Beans;


namespace ResourcesApplication.Validation
{
    public class ResourceIdValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            Database db = new Database();
            db.ser.RESOURCES_DATA = "resources.bin";
            db.der.RESOURCES_DATA = "resources.bin";
            db.loadData();
            try
            {
                var text = value as string;

                foreach (Resource res in db.Resources)
                {
                    if (res.Id.Equals(text))
                    {
                        return new ValidationResult(false, "Id mora biti jedinstven");
                    }
                }

                return new ValidationResult(true, "");
            }
            catch
            {
                return new ValidationResult(false, "Desila se neočekivana greška");
            }
        }
        }
    }

