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
        public RankViewModel HidenObject;
        public RankList()
        {
            InitializeComponent();
            MouseUp += new MouseButtonEventHandler(DropCancel);

        }

        private void Drop(object sender, DragEventArgs e)
        {
            (sender as RankViewModel).BorderBrush = new SolidColorBrush();
            var source = e.Data.GetData("Source");
            if(HidenObject != null)
                HidenObject.Visibility = Visibility.Visible;
            int DropTarget = 0, DropedRank = 0, cunt = 0; ;
            int temp = 0;
            foreach (var rank in (DataContext as RanksViewModel).RankItems)
            {
                if(rank.Rank.Id == Convert.ToInt32(source))
                    DropedRank = cunt;
                if (rank.Rank.Id == ((sender as RankViewModel).DataContext as RankItemViewModel).Rank.Id)
                    DropTarget = cunt;
                cunt++;
            }
            Swap((DataContext as RanksViewModel).RankItems, DropedRank, DropTarget);
            var name = (DataContext as RanksViewModel).RankItems;
            (DataContext as RanksViewModel).RaisePropertyChanged(nameof(name));
        }

        private void PreviewMouseMove(object sender, MouseEventArgs e)
        {
            var data = new DataObject();
            data.SetData("Source", ((sender as RankViewModel).DataContext as RankItemViewModel).Rank.Id.ToString());
            
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount((RankViewModel)sender); i++)
            {
                var chld = VisualTreeHelper.GetChild((RankViewModel)sender, i);
            }
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                base.OnMouseMove(e);
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    //(sender as RankView).Visibility = Visibility.Hidden;
                    if (HidenObject != null)
                    {
                        HidenObject.Visibility = Visibility.Visible;
                        HidenObject = (sender as RankViewModel);
                    }
                    else
                        HidenObject = sender as RankViewModel;
                    try
                    {
                        DragDrop.DoDragDrop(sender as RankViewModel, data, DragDropEffects.Move);
                    }catch(InvalidOperationException) { }
                    e.Handled = true;
                }
            }
        }
        private void RankView_DragOver(object sender, DragEventArgs e)
        {
            (sender as RankViewModel).BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF3066"));
        }
        private void RankView_DragLeave(object sender, DragEventArgs e)
        {
            (sender as RankViewModel).BorderBrush = new SolidColorBrush();
        }

        public static void Swap<T>(IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }

        private void DropCancel(object sender, EventArgs e)
        {
            Trace.WriteLine("podnal!!!!!!!!!!!!!!!!!");
            if(HidenObject != null)
            {
                HidenObject.Visibility = Visibility.Visible;
                HidenObject = null;
            }
            //Trace.WriteLine("asfdasdsadsadasdasdas");
        }
    }
}
