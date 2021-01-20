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
    /// Логика взаимодействия для RankView.xaml
    /// </summary>
    public partial class RankView : UserControl
    {
        public event EventHandler createRank;
        public event EventHandler deleteRank;
        public string rankname{
            get{
                return (nameBox.Text);
            }
            set{
                nameBox.Text = value;
            }
        }

        public int rankN;

        public RankView(string name,int newrankN)
        {
            InitializeComponent();
            rankname = name;
            nameBox.Text = name;
            rankN = newrankN;
            rankNum.Content = $"{newrankN}.";
        }
        /*public void ChangeRankNum(int dif)
        {
            rankN = rankN + dif;
            rankNum.Content = $"{rankN}.";
        }

        private void addRankClick(object sender, RoutedEventArgs e)
        {
            createRank(this, e);
        }

        private void deleteRankClick(object sender, RoutedEventArgs e)
        {
            deleteRank(this, e);
        }*/
    }
}
