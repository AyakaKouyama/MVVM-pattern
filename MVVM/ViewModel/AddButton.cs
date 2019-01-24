using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie3;

namespace MVVM.ViewModel
{
    public class AddButton
    {
        private MainViewModel main;
        public RealyCommand Add { get; set; }
        public AddButton(MainViewModel main)
        {
            this.main = main;
            Add = new RealyCommand(() => Add_f());
        }

        public void Add_f()
        {
            try
            {
                main.ResetValues();
                main.PopUp.Show("Fill required values and click Save button to add new Employee to database.", 2);
                main.SaveVisibility = true;
            }
            catch (Exception exc)
            {
                main.PopUp.Show(exc.Message, 1);
            }
        }

    }

}

