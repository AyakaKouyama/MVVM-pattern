using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;
using Zadanie3;

namespace MVVM.Model
{
    public class Employees
    {
        #region Private Fields
        private DataRepository repository;
        private ObservableCollection<Employee> emp;
        private ObservableCollection<Person> person;
        #endregion

        #region Properties
        public ObservableCollection<Employee> Employee
        {
            get
            {

                List<Employee> list = repository.GetAllEmployees();
                foreach (var i in list)
                {
                    emp.Add(i);
                }

                return emp;
            }
        }


        public ObservableCollection<Person> Person
        {
            get
            {

                List<Person> list = repository.GetAllPeople();
                foreach (var i in list)
                {
                    person.Add(i);
                }

                return person;
            }
        }
        #endregion

        #region Constructors

        public Employees()
        {
            repository = new DataRepository();
            emp = new ObservableCollection<Employee>();
            person = new ObservableCollection<Person>();
        }

        #endregion

        #region Methods
        public void AddEmployee(Employee employee)
        {
            repository.AddEmployee(employee);
        }

        public void RemoveEmployee(Employee employee)
        {
            repository.RemoveEmployee(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            repository.UpdateEmployee(employee);
        }

        public void AddPerson(Person person)
        {
            repository.AddPerson(person);
        }

        public void RemovePerson(Person person)
        {
            repository.RemovePerson(person);
        }

        public void UpdatePerson(Person person)
        {
            repository.UpdatePerson(person);
        }

        #endregion
    }

}
