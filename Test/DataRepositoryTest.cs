using System;
using System.Linq;
using System.Threading;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie3;

namespace Test
{
    [TestClass]
    public class DataRepositoryTest
    {
        [TestMethod]
        public void AddAndRemoveEmployeeTest()
        {
            Employee emp = new Employee();
            emp.BusinessEntityID = 999999;
            emp.NationalIDNumber = "123456";
            emp.LoginID = "987456";
            emp.JobTitle = "test";
            emp.BirthDate = DateTime.Parse("01-01-2000");
            emp.MaritalStatus = 'S';
            emp.Gender = 'M';
            emp.HireDate = DateTime.Parse("01-01-2010");
            emp.SalariedFlag = true;
            emp.VacationHours = 0;
            emp.SickLeaveHours = 0;
            emp.CurrentFlag = true;
            emp.rowguid = Guid.NewGuid();
            emp.ModifiedDate = DateTime.Today;


            DataRepository repository = new DataRepository();
            repository.AddEmployee(emp);

            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                Employee res = db.Employee.Single(i => i.BusinessEntityID == 999999);

                Assert.IsNotNull(res);

                Assert.AreEqual(res.NationalIDNumber, "123456");
                Assert.AreEqual(res.LoginID, "987456");
                Assert.AreEqual(res.JobTitle, "test");
                Assert.AreEqual(res.BirthDate, DateTime.Parse("01-01-2000"));
                Assert.AreEqual(res.MaritalStatus, 'S');
                Assert.AreEqual(res.Gender, 'M');

                repository.RemoveEmployee(emp);
            }
        }

        [TestMethod]
        public void UpdateEmployeeTest()
        {
            Employee emp = new Employee();
            emp.BusinessEntityID = 999999;
            emp.NationalIDNumber = "123456";
            emp.LoginID = "987456";
            emp.JobTitle = "test";
            emp.BirthDate = DateTime.Parse("01-01-2000");
            emp.MaritalStatus = 'S';
            emp.Gender = 'M';
            emp.HireDate = DateTime.Parse("01-01-2010");
            emp.SalariedFlag = true;
            emp.VacationHours = 0;
            emp.SickLeaveHours = 0;
            emp.CurrentFlag = true;
            emp.rowguid = Guid.NewGuid();
            emp.ModifiedDate = DateTime.Today;


            DataRepository repository = new DataRepository();
            repository.AddEmployee(emp);

            emp.NationalIDNumber = "33333";
            emp.LoginID = "321";
            emp.JobTitle = "new";
            emp.MaritalStatus = 'S';
            emp.Gender = 'F';

            repository.UpdateEmployee(emp);

            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                Employee res = db.Employee.Single(i => i.BusinessEntityID == 999999);
                Assert.AreEqual(res.NationalIDNumber, "33333");
                Assert.AreEqual(res.LoginID, "321");
                Assert.AreEqual(res.JobTitle, "new");
                Assert.AreEqual(res.MaritalStatus, 'S');
                Assert.AreEqual(res.Gender, 'F');
            }

            repository.RemoveEmployee(emp);
        }

        [TestMethod]
        public void AddAndRemovePersonTets()
        {
            Person person = new Person();
            person.BusinessEntityID = 99999;
            person.FirstName = "test";
            person.LastName = "new";
            person.ModifiedDate = DateTime.Today;
            person.rowguid = Guid.NewGuid();
            person.NameStyle = true;
            person.PersonType = "EM";

            DataRepository repository = new DataRepository();
            repository.AddPerson(person);

            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                Person res = db.Person.Single(i => i.BusinessEntityID == 99999);

                Assert.IsNotNull(res);
                Assert.AreEqual(res.BusinessEntityID, 99999);
                Assert.AreEqual(res.FirstName, "test");
                Assert.AreEqual(res.LastName, "new");
                Assert.AreEqual(res.ModifiedDate, DateTime.Today);
                Assert.AreEqual(res.NameStyle, true);
                Assert.AreEqual(res.PersonType, "EM");

                repository.RemovePerson(person);
                IQueryable<Person> res_r = db.Person.Where(i => i.BusinessEntityID == 999999);
                foreach (Person i in res_r)
                {
                    Assert.IsNull(i);
                }
            }
        }

        [TestMethod]
        public void UpdatePerson()
        {
            Person person = new Person();
            person.BusinessEntityID = 99999;
            person.FirstName = "test";
            person.LastName = "new";
            person.ModifiedDate = DateTime.Today;
            person.rowguid = Guid.NewGuid();
            person.NameStyle = true;
            person.PersonType = "EM";

            DataRepository repository = new DataRepository();
            repository.AddPerson(person);

            person.FirstName = "new name";
            person.LastName = "new lastname";
            person.NameStyle = false;
            person.PersonType = "IN";

            repository.UpdatePerson(person);

            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                Person res = db.Person.Single(i => i.BusinessEntityID == 99999);

                Assert.AreEqual(res.FirstName, "new name");
                Assert.AreEqual(res.LastName, "new lastname");
                Assert.AreEqual(res.NameStyle, false);
                Assert.AreEqual(res.PersonType, "IN");
            }

            repository.RemovePerson(person);
        }
    }
}
