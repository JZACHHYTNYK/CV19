using CV19WpfApp.Infastructure.Commands.Base;
using System.Windows;

namespace CV19WpfApp.Infastructure.Commands
{
    internal class CloseApplicationCommand : Command
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)=> Application.Current.Shutdown();
    }
}
