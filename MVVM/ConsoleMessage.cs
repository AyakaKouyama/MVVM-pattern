using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    public class ConsoleMessage : IShowPopUp
    {
        public void Show(string message, int mode)
        {
            Console.WriteLine(message);
        }
    }
}
