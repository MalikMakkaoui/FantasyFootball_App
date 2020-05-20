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
using System.Windows.Shapes;

namespace FootballApp
{
    /// <summary>
    /// Interaction logic for Player_Categories.xaml
    /// </summary>
    public partial class Player_Categories : Window
    {
        public Player_Categories()
        {
            InitializeComponent();
        }

        private void QB_Click(object sender, RoutedEventArgs e)
        {
            
            var Window = new Players("QB");
            Window.Show();
            this.Close();
            Window.Title = "QuarterBacks";
        }

        private void RB_Click(object sender, RoutedEventArgs e)
        {
           
            var Window = new Players("RB");
            Window.Show();
            this.Close();
            Window.Title = "RunningBacks";
        }

        private void WR_Click(object sender, RoutedEventArgs e)
        {
            
            var Window = new Players("WR");
            Window.Show();
            this.Close();
            Window.Title = "WideReceivers";
        }
    }
}
