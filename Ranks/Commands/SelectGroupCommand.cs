﻿using GalaSoft.MvvmLight;
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
        public MainViewModel viewModel { get; set; }

        public SelectGroupCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if(parameter != null)
            {
                if ((parameter as Model.Group).Users.Count > 0)
                    return true;
            }
            return false;
        }
        public void Execute(object parameter)
        {
            this.viewModel.SelectGroup(parameter as Model.Group);
        }
    }
}