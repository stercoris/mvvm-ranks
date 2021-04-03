using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Order.View
{                                               //TODO: Вырезать
    /// <summary>
    /// Логика взаимодействия для RankList.xaml
    /// </summary>
    public partial class RankList : Page
    {
        //public List<RankView> ranksList = new();

        public RankList()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //var ranksListsGrandfather = VisualTreeHelper.GetChild(RanksItemControl, 0);//я не смог напрямую обратиться к листу с рангами (
            //var ranksListsFather = VisualTreeHelper.GetChild(ranksListsGrandfather, 0);
            //var ranksList = VisualTreeHelper.GetChild(ranksListsFather, 0);
            //for (int i = 0; i < VisualTreeHelper.GetChildrenCount(ranksList); i++)
            //{
            //    var chld = VisualTreeHelper.GetChild(ranksList, i);
            //    RankView rankView = VisualTreeHelper.GetChild(chld, 0) as RankView;
            //    this.ranksList.Add(rankView);
            //    //Trace.WriteLine(rankView.TranslatePoint(new Point(0, 0), ranksListsFather as ItemsPresenter).Y);
            //}
        }
    }
}
