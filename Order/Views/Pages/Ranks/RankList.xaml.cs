using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Order.WPF.Views.Pages.Ranks;
using Order.WPF.ViewModels;
using ReactiveUI;

namespace Order.WPF.Views.Pages.Ranks
{                                               //TODO: Drag cancel and Statistic
    /// <summary>
    /// Логика взаимодействия для RankList.xaml
    /// </summary>
    public partial class RankList : Page
    {
        public RankList()
        {
            InitializeComponent();
        }
    }
}
