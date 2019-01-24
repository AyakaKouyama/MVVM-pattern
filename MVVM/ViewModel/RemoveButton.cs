using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModel
{
    public class RemoveButton
    {
        private MainViewModel main;
        public RealyCommand Remove { get; set; }

        public RemoveButton(MainViewModel main)
        {
            this.main = main;
            Remove = new RealyCommand(() => Remove_f());
        }

        public void Remove_f()
        {
            Task.Run(() =>
            {
                try
                {
                    main.Employees.RemovePerson(main.CurrentPerson);
                    main.Employees.RemoveEmployee(main.CurrentEmployee);
                }
                catch(Exception exc)
                {
                    main.PopUp.Show(exc.Message, 1);
                }
            });

            main.Names.Remove(main.CurrentPerson);
            main.List.Remove(main.CurrentEmployee);
        }
    }
}
