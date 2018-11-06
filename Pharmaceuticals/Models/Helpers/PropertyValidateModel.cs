using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace System.ComponentModel.DataAnnotations
{
    public abstract class PropertyValidateModel : IDataErrorInfo
    {
        // check for general model error    
        [NotMapped]
        public string Error
        {
            get
            {
                var validationResults = new List<ValidationResult>();

                if (Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true))
                {
                    return null;
                }

                StringBuilder sb = new StringBuilder();

                foreach (var validationResult in validationResults)
                {
                    sb.AppendLine(validationResult.ErrorMessage);
                }

                return sb.ToString();
            }
        }

        // check for property errors  
        [NotMapped]
        public string this[string columnName]
        {
            get
            {
                var validationResults = new List<ValidationResult>();

                var property = GetType().GetProperty(columnName).GetValue(this);

                if (Validator.TryValidateProperty(property, new ValidationContext(this) { MemberName = columnName }, validationResults))
                {
                    return null;
                }

                return validationResults.First().ErrorMessage;
            }
        }

        public bool TryValidate()
        {
            var results = new List<ValidationResult>();

            var context = new ValidationContext(this, null, null);

            results = new List<ValidationResult>();

            return Validator.TryValidateObject(this, context, results, validateAllProperties: true);
        }
    }
}
