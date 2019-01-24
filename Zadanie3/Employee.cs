using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public partial class Employee : IDataErrorInfo
    {

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                if (columnName == "Gender")
                {
                    if (_Gender.Equals('F') == false && _Gender.Equals('M') == false && _Gender.Equals('f') == false && _Gender.Equals('m') == false)
                    {
                        return "available values are: F - Female, M - Male.";
                    }
                }
                if (columnName == "MaritalStatus")
                {
                    if (_MaritalStatus.Equals('M') == false && _MaritalStatus.Equals('S') == false)
                    {
                        return "available values are: M - Marriage S - Single.";
                    }
                }
                if (columnName == "NationalIDNumber")
                {
                    if (_NationalIDNumber == null || _NationalIDNumber == string.Empty)
                    {
                        return "Cannot be NULL";
                    }
                    else if (_NationalIDNumber != null && _NationalIDNumber.ToString().Length > 15)
                    {
                        return "Max length: 15 characters.";
                    }
                    else if (int.TryParse(_NationalIDNumber, out int res) == false)
                    {
                        return "ID must contain only numbers";
                    }
                }
                if (columnName == "LoginID")
                {
                    if (_LoginID == null || _LoginID == string.Empty)
                    {
                        return "Cannot be NULL";
                    }
                    else if (_LoginID != null && _LoginID.ToString().Length > 255)
                    {
                        return "Max length: 255 characters.";
                    }
                }
                if (columnName == "JobTitle")
                {
                    if (_JobTitle == null || _JobTitle == string.Empty)
                    {
                        return "Cannot be NULL";
                    }
                    if (JobTitle != null && _JobTitle.ToString().Length > 50)
                    {
                        return "Max length 50 characters.";
                    }
                }
                if (columnName == "SickLeaveHours")
                {
                    if (_SickLeaveHours < 0 || _SickLeaveHours > 120)
                    {
                        return "Values must be between 0 and 120.";
                    }
                }
                if (columnName == "VacationHours")
                {
                    if (_VacationHours < -40 || _VacationHours > 240)
                    {
                        return "Values must be between -40 and 240.";
                    }
                }
                if (columnName == "BirthDate")
                {
                    if (_BirthDate == null)
                    {
                        return "Cannot be NULL";
                    }
                    else if (DateTime.Compare(_BirthDate, DateTime.Parse("1930-01-01")) < 0 || ((DateTime.Today.Year - _BirthDate.Year) < 18))
                    {
                        return "Employee must be at least 18 years old and birth date must be greater than 1930-01-01.";
                    }
                }
                if (columnName == "HireDate")
                {
                    if (_HireDate == null)
                    {
                        return "Cannot be NULL";
                    }
                    else if (DateTime.Compare(_HireDate, DateTime.Parse("1996-07-01")) < 0 || (DateTime.Compare(_HireDate, DateTime.Today)) > 0)
                    {
                        return "Hire date must be greater than 1996-07-01 and not bigger than " + DateTime.Today + ".";
                    }
                }

                return string.Empty;
            }
        }
    }
}
