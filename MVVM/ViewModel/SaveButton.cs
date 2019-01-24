using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie3;

namespace MVVM.ViewModel
{
    public class SaveButton
    {
        private MainViewModel main;
        public RealyCommand Save { get; set; }

        public SaveButton(MainViewModel main)
        {
            this.main = main;
            Save = new RealyCommand(() => { AddButton(); });
        }

        public void AddButton()
        {
           main.CurrentPerson.BusinessEntityID = main.CurrentEmployee.BusinessEntityID;
           main.List.Add(main.CurrentEmployee);
           main.Names.Add(main.CurrentPerson);

            Task.Run(() =>
            {
                try
                {
                    main.Employees.AddEmployee(main.CurrentEmployee);
                    main.Employees.AddPerson(main.CurrentPerson);
                    main.PopUp.Show("Added new Employee.", 2);
                }
                catch (Exception exc)
                {
                    main.PopUp.Show(exc.Message, 1);
                    main.ResetValues();
                    main.SaveVisibility = true;
                }
            });
           

        }
    }
}
