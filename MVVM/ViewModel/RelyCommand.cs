using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM.ViewModel
{
    public class RealyCommand : ICommand
    {
        private readonly Func<bool> m_CanExecute;
        private readonly Action m_Execute;
        public event EventHandler CanExecuteChanged;

        public RealyCommand(Action execute) : this(execute, null) { }

        public RealyCommand(Action execute, Func<bool> canExecute)
        {
            this.m_Execute = execute;
            this.m_CanExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.m_Execute();
        }
    }
}
