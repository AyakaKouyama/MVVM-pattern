using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie3;

namespace Logic
{
    public class DataRepository
    {

        public List<Employee> GetAllEmployees()
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                IQueryable<Employee> res = db.Employee;
                return res.ToList();
            }
        }

        public List<Person> GetAllPeople()
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                IQueryable<Person> res = from i in db.Person
                                         from j in db.Employee
                                         orderby i.LastName
                                         where i.BusinessEntityID == j.BusinessEntityID
                                         select i;
                return res.ToList();
            }
        }

        public void AddEmployee(Employee employee)
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                db.Employee.InsertOnSubmit(employee);
                db.SubmitChanges();
            }
        }

        public void AddPerson(Person person)
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                db.Person.InsertOnSubmit(person);
                db.SubmitChanges();
            }
        }

        public void RemoveEmployee(Employee employee)
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                Employee find = db.Employee.Single(o => o.Equals(employee));
                db.Employee.DeleteOnSubmit(find);
                db.SubmitChanges();
            }
        }

        public void RemovePerson(Person person)
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                Person find = db.Person.Single(o => o.Equals(person));
                db.Person.DeleteOnSubmit(find);
                db.SubmitChanges();
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                IQueryable<Employee> res = from i in db.Employee
                          where i.BusinessEntityID == employee.BusinessEntityID
                          select i;

                foreach (Employee i in res)
                {
                    i.BusinessEntityID = employee.BusinessEntityID;
                    i.NationalIDNumber = employee.NationalIDNumber;
                    i.LoginID = employee.LoginID;
                    i.JobTitle = employee.JobTitle;
                    i.BirthDate = employee.BirthDate;
                    i.MaritalStatus = employee.MaritalStatus;
                    i.Gender = employee.Gender;
                    i.HireDate = employee.HireDate;
                    i.SalariedFlag = employee.SalariedFlag;
                    i.VacationHours = employee.VacationHours;
                    i.SickLeaveHours = employee.SickLeaveHours;
                    i.CurrentFlag = employee.CurrentFlag;
                    i.rowguid = employee.rowguid;
                    i.ModifiedDate = employee.ModifiedDate;
                }

                db.SubmitChanges();
            }
        }

        public void UpdatePerson(Person person)
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                IQueryable<Person> res = from i in db.Person
                          where i.BusinessEntityID == person.BusinessEntityID
                          select i;

                foreach (Person i in res)
                {
                    i.BusinessEntityID = person.BusinessEntityID;
                    i.FirstName = person.FirstName;
                    i.LastName = person.LastName;
                    i.NameStyle = person.NameStyle;
                    i.EmailPromotion = person.EmailPromotion;
                    i.PersonType = person.PersonType;
                }
                db.SubmitChanges();

            }
        }

    }
}
