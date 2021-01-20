using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyGame
{
    /// <summary>
    /// Логика взаимодействия для RankList.xaml
    /// </summary>
    public partial class RankList : UserControl
    {
        public RankList()
        {
            InitializeComponent();
            List<string> ranks= Db.GetRanks();
            Console.WriteLine(ranks.Count);
            int i = 1;
            foreach(string rank in ranks)
            {
                RankView rankPanel = new RankView(rank,i++);
                /*rankPanel.createRank += addNewRank;
                rankPanel.deleteRank += deleteRank;*/
                rankUl.Children.Add(rankPanel);
            }
        }

        /*private void addNewRank(object ranksender,EventArgs e)
        {
            RankView rank = ranksender as RankView;
            //int index = rankUl.Children.IndexOf(rank) + 2;
            int index = rank.rankN + 1;
            RankView newRank = new RankView("Введите новый ранг", index);
            newRank.createRank += addNewRank;
            newRank.deleteRank += deleteRank;
            foreach (RankView element in LogicalTreeHelper.GetChildren(rankUl).OfType<RankView>().Where((x) => x.rankN >= index))
                element.ChangeRankNum(1);
            rankUl.Children.Insert(rankUl.Children.IndexOf(rank)+1, newRank);
            

        }
        private void deleteRank(object ranksender,EventArgs e)
        {
            RankView rank = ranksender as RankView;
            int index = rank.rankN + 1;
            foreach (RankView element in LogicalTreeHelper.GetChildren(rankUl).OfType<RankView>().Where((x) => x.rankN >= index))
                element.ChangeRankNum(-1);
            rankUl.Children.Remove(rank);
        }*/

        private void saveChanges(object sender, RoutedEventArgs e)
        {
            List<string> ranks = new List<string> { };
            foreach (RankView element in LogicalTreeHelper.GetChildren(rankUl).OfType<RankView>())
                ranks.Add(element.rankname);
            Db.UpdateRanks(ranks);
        }

    }
}
