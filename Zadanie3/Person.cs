using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public partial class Person : IDataErrorInfo
    {
        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                if (columnName == "FirstName")
                {
                    if (_FirstName == null || _FirstName == string.Empty)
                    {
                        return "Cannot be NULL";
                    }
                    else if (_FirstName.All(c => char.IsLetter(c)) == false)
                    {
                        return "Firstname must contain only letters.";
                    }
                }
                if (columnName == "LastName")
                {
                    if (_LastName == null || _LastName == string.Empty)
                    {
                        return "Cannot be NULL";
                    }
                    else if (_LastName.All(c => char.IsLetter(c)) == false)
                    {
                        return "Lastname must contain only letters.";
                    }
                }
                if (columnName == "EmailPromotion")
                {
                    if (_EmailPromotion < 0 || _EmailPromotion > 2)
                    {
                        return "Available values are: 0 = Contact does not wish to receive e-mail promotions, " +
                            "1 = Contact does wish to receive e-mail promotions from AdventureWorks, " +
                            "2 = Contact does wish to receive e-mail promotions from AdventureWorks and selected partners.";
                    }
                }

                return string.Empty;
            }
        }
    }
}
