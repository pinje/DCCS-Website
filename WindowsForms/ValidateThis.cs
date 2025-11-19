using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WindowsForms
{
    public class ValidateThis
    {
        public static IEnumerable<ValidationResult> ValidateObject(object obj)
        {
            var validation = new List<ValidationResult>();
            var context = new ValidationContext(obj, null, null);

            Validator.TryValidateObject(obj, context, validation, true);

            return validation;
        }
    }
}
