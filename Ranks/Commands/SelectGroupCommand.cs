using Ranks.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ranks.Commands
{
    class SelectGroupCommand : ICommand
    {
        public GroupsViewModel viewModel { get; set; }

        public SelectGroupCommand(GroupsViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if(parameter != null)
            {
                if ((parameter as Models.Group).Users.Count > 0)
                    return true;
            }
            return false;
        }
        public void Execute(object parameter)
        {
            this.viewModel.SelectGroup(parameter as Models.Group);
        }
    }
}
