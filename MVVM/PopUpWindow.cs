using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM
{
    class PopUpWindow : IShowPopUp
    {
        internal Func<string, string, MessageBoxButton, MessageBoxImage, MessageBoxResult> MessageBoxShowDelegate { get; set; } = MessageBox.Show;

        public void Show(string message, int mode)
        {
            if(mode == 1)
            {
                 MessageBoxShowDelegate(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBoxShowDelegate(message, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
           
        }
    }
}
