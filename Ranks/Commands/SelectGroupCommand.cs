using Ranks.ViewModels;
using System;
using System.Windows.Input;

namespace Ranks.Commands
{
    class SelectGroupCommand : ICommand
    {
        public GroupViewModel viewModel { get; set; }

        public SelectGroupCommand(GroupViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (viewModel.Group.users.Count > 0)
                return true;
            return false;
        }
        public void Execute(object parameter)
        {
            this.viewModel.Select();
        }
    }
}
