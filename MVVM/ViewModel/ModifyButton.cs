using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModel
{
    public class ModifyButton
    {
        private MainViewModel main;
        public RealyCommand Modify { get; set; }

        public ModifyButton(MainViewModel main)
        {
            this.main = main;
            Modify = new RealyCommand(() => Modify_f());
        }

        public void Modify_f()
        {
            Task.Run(() =>
            {
                try
                {
                    main.Employees.UpdateEmployee(main.CurrentEmployee);
                    main.Employees.UpdatePerson(main.CurrentPerson);
                    main.PopUp.Show("Updated values.", 2);
                }
                catch (Exception exc)
                {
                    main.PopUp.Show(exc.Message, 1);
                }

            });
          
        }
    }
}
