using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using InterfazSCI_1._0.Windows;

namespace InterfazSCI_1._0.Windows
{
    public abstract class ViewModel : ObservableObject, IDataErrorInfo
    {
        public string this[string columnName] => OnValidate(columnName);
         
        public string Error => throw new NotSupportedException();

        protected virtual string OnValidate(string propertyName)
        {
            var context = new ValidationContext(this)
            {
                MemberName = propertyName
            };

            var results = new Collection<ValidationResult>();
            var isValid = Validator.TryValidateObject(this, context, results, true);

            return !isValid ? results[0].ErrorMessage : null;
        }
    }
}
