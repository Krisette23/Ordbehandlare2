using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordbehandlare2
{
    public interface ICommand
    {
        event EventHandler CanExecutedChanged;


        bool CanExecute(object parameter);
        void Execute(object parameter);
    }
}
