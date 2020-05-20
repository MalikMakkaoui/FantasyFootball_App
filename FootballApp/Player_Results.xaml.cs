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
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace FootballApp
{
    /// <summary>
    /// Interaction logic for Player_Results.xaml
    /// </summary>
    public partial class Player_Results : Window
    {
        public Player_Results()
        {
            InitializeComponent();

         

        }
        public void CAT_Click(object sender, RoutedEventArgs e)
        {
            var HomePage = new Player_Categories();
            HomePage.Show();
            this.Close();
            

        }





    }
}
