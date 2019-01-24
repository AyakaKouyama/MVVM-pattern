using MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModel
{
    public class LoadButton
    {
        private MainViewModel main;
        public RealyCommand Load { get; set; }

        public LoadButton(MainViewModel main)
        {
            this.main = main;
            Load = new RealyCommand(() => main.Employees = new Employees());
        }

    }
}
