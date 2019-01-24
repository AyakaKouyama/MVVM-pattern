using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVVM.ViewModel;
using MVVM;
using System.Windows.Controls;
using System.Threading.Tasks;
using System.Threading;
using Zadanie3;
using System.Linq;

namespace Test
{
    [TestClass]
    public class ViewModelTest
    {
        [TestMethod]
        public void LoadButtonTest()
        {
            MainViewModel main = new MainViewModel();
            LoadButton load = new LoadButton(main);

            Assert.IsNull(main.List);
            Assert.IsNull(main.Employees);
            Assert.IsNull(main.Names);

            load.Load.Execute(null);

            Assert.IsNotNull(main.List);
            Assert.IsNotNull(main.Employees);
            Assert.IsNotNull(main.Names);
        }

        [TestMethod]
        public void AddButtonTest()
        {
            MainViewModel main = new MainViewModel(new ConsoleMessage());
            AddButton add = new AddButton(main);
            Assert.AreEqual(main.SaveVisibility, false);
            add.Add.Execute(null);
            Assert.AreEqual(main.SaveVisibility, true);
        }

        [TestMethod]
        public void ModifySaveRemoveButtonButtonTest()
        {
            MainViewModel main = new MainViewModel(new ConsoleMessage());
            main.List = new System.Collections.ObjectModel.ObservableCollection<Zadanie3.Employee>();
            main.Names = new System.Collections.ObjectModel.ObservableCollection<Zadanie3.Person>();
            main.Employees = new MVVM.Model.Employees();
            SaveButton save = new SaveButton(main);
            ModifyButton modify = new ModifyButton(main);
            RemoveButton remove = new RemoveButton(main);

            main.CurrentPerson = new Zadanie3.Person();
            main.CurrentPerson.BusinessEntityID = 99999;
            main.CurrentPerson.FirstName = "test";
            main.CurrentPerson.LastName = "new";
            main.CurrentPerson.ModifiedDate = DateTime.Today;
            main.CurrentPerson.rowguid = Guid.NewGuid();
            main.CurrentPerson.NameStyle = true;
            main.CurrentPerson.PersonType = "EM";

            main.CurrentEmployee = new Zadanie3.Employee();
            main.CurrentEmployee.BusinessEntityID = 999999;
            main.CurrentEmployee.NationalIDNumber = "123456";
            main.CurrentEmployee.LoginID = "987456";
            main.CurrentEmployee.JobTitle = "test";
            main.CurrentEmployee.BirthDate = DateTime.Parse("01-01-2000");
            main.CurrentEmployee.MaritalStatus = 'S';
            main.CurrentEmployee.Gender = 'M';
            main.CurrentEmployee.HireDate = DateTime.Parse("01-01-2010");
            main.CurrentEmployee.SalariedFlag = true;
            main.CurrentEmployee.VacationHours = 0;
            main.CurrentEmployee.SickLeaveHours = 0;
            main.CurrentEmployee.CurrentFlag = true;
            main.CurrentEmployee.rowguid = Guid.NewGuid();
            main.CurrentEmployee.ModifiedDate = DateTime.Today;


            // Add new Employee
            save.Save.Execute(null);
            Thread.Sleep(3000);

            using (Zadanie3.DataBaseDataContext db = new DataBaseDataContext())
            {
                Person person = db.Person.Single(i => i.BusinessEntityID == 999999);
                Assert.AreEqual(person.FirstName, "test");
                Assert.AreEqual(person.LastName, "new");
                Assert.AreEqual(person.PersonType, "EM");

                Employee emp = db.Employee.Single(i => i.BusinessEntityID == 999999);
                Assert.AreEqual(emp.NationalIDNumber, "123456");
                Assert.AreEqual(emp.LoginID, "987456");
                Assert.AreEqual(emp.JobTitle, "test");
                Assert.AreEqual(emp.Gender, 'M');
                Assert.AreEqual(emp.MaritalStatus, 'S');
            }


            //Modify Employee in db
            main.CurrentPerson.FirstName = "new firstname";
            main.CurrentPerson.LastName = "new lastname";
            main.CurrentPerson.PersonType = "IN";
            main.CurrentEmployee.NationalIDNumber = "132";
            main.CurrentEmployee.JobTitle = "new";
            main.CurrentEmployee.Gender = 'F';
            main.CurrentEmployee.MaritalStatus = 'M';

            modify.Modify.Execute(null);
            Thread.Sleep(3000);

            using (Zadanie3.DataBaseDataContext db = new DataBaseDataContext())
            {
                Person res = db.Person.Single(i => i.BusinessEntityID == 999999);
                Assert.AreEqual(res.FirstName, "new firstname");
                Assert.AreEqual(res.LastName, "new lastname");
                Assert.AreEqual(res.PersonType, "IN");

                Employee res_e = db.Employee.Single(i => i.BusinessEntityID == 999999);
                Assert.AreEqual(res_e.NationalIDNumber, "132");
                Assert.AreEqual(res_e.JobTitle, "new");
                Assert.AreEqual(res_e.Gender, 'F');
                Assert.AreEqual(res_e.MaritalStatus, 'M');
            }

            //Remove from db
            remove.Remove.Execute(null);
            Thread.Sleep(3000);

            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                IQueryable<Person> res_p_3 = db.Person.Where(i => i.BusinessEntityID == 999999);
                foreach (Person i in res_p_3)
                {
                    Assert.IsNull(i);
                }

                IQueryable<Employee> res_e_3 = db.Employee.Where(i => i.BusinessEntityID == 999999);
                foreach (Employee i in res_e_3)
                {
                    Assert.IsNull(i);
                }
            }
        }

    }
}
