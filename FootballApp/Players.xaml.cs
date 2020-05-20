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
    /// Interaction logic for Players.xaml
    /// </summary>
    /// 


    public partial class Players: Window
    {
     
       
        public string name1;
        public string type;
        public Players(string type)
        {
            InitializeComponent();
            this.type = type;
            ButtonClicked();
            
        }
        // Checks Which button was clicked and assigns the correct list to the comboboxes
        //
        //
        public void ButtonClicked()
        {
            if (type == "QB")
            {
                var PlayersQB = new Get_QBs();
                PlayersQB.GetQBs();
                Player1.ItemsSource = PlayersQB.QBList;
                Player2.ItemsSource = PlayersQB.QBList;
                
            }
            else if (type == "RB")
            {
                var PlayersRb = new Get_Rbs();
                PlayersRb.GetRBs();
                Player1.ItemsSource = PlayersRb.RBList;
                Player2.ItemsSource = PlayersRb.RBList;
            }
            else if (type == "WR")
            {
                var PlayersWr = new Get_WRs();
                PlayersWr.GetWRs();
                Player1.ItemsSource = PlayersWr.WRList;
                Player2.ItemsSource = PlayersWr.WRList;
            }
        }

        //******************************************************************************

        public void Back_Click(object sender, RoutedEventArgs e)
        {
            var GoBack = new Player_Categories();
            GoBack.Show();
            this.Close();

        }
            public void Compare_Click(object sender, RoutedEventArgs e)
        {

            if (Player1.SelectionBoxItem.ToString() == "" || Player2.SelectionBoxItem.ToString() == "")
            {
                MessageBox.Show("MISSING PLAYER..... PLEASE SELECT 1 PLAYER FROM EACH COMBOBOX");
            }

            else
            {
                var WindowPlayerResults = new Player_Results();
                WindowPlayerResults.Show();
                this.Close();



                var player = Player1.SelectionBoxItem;
                var player2 = Player2.SelectionBoxItem;

                // Assigns Whatever player was selected in the 2 comboboxs to the 2 TextBoxs on Results Window
                //
                //

                var P_Name = ((FootballApp.PlayersList)player).PlayerName;
                var P_Team = ((FootballApp.PlayersList)player).PlayerTeam;
                var P_Yards = ((FootballApp.PlayersList)player).PlayerYards;
                var P_Touchdowns = ((FootballApp.PlayersList)player).PlayerTouchdowns;

                var P_Name2 = ((FootballApp.PlayersList)player2).PlayerName;
                var P_Team2 = ((FootballApp.PlayersList)player2).PlayerTeam;
                var P_Yards2 = ((FootballApp.PlayersList)player2).PlayerYards;
                var P_Touchdowns2 = ((FootballApp.PlayersList)player2).PlayerTouchdowns;

                if (type == "QB")
                {
                    WindowPlayerResults.Title = "QuarterBacks";

                }
                else if (type == "RB")
                {
                    WindowPlayerResults.Title = "RunningBacks";
                }
                else if (type == "WR")
                {
                    WindowPlayerResults.Title = "WideReceivers";
                }


                // Displaying Text on Result Window
                //
                //




                WindowPlayerResults.Textbox1NameTeam.Text = $"{P_Name}{P_Team}";
                WindowPlayerResults.Textbox1Yards.Text = $"{P_Yards}";
                WindowPlayerResults.Textbox1Touchdowns.Text = $"{P_Touchdowns}";

                WindowPlayerResults.Textbox2NameTeam.Text = $"{P_Name2}{P_Team2}";
                WindowPlayerResults.Textbox2Yards.Text = $"{P_Yards2}";
                WindowPlayerResults.Textbox2Touchdowns.Text = $"{P_Touchdowns2}";

                //**********************************************************************************************

                // Comparing Yards and Touchdowns between players in order to figure out who scored more fantasy points. Every touchdown counts as 6 points and every yards counts as 0.1 points.
                //
                //

                int player1Yards = Int32.Parse(P_Yards);
                int player2Yards = Int32.Parse(P_Yards2);
                int player1Touchdowns = Int32.Parse(P_Touchdowns);
                int player2Touchdowns = Int32.Parse(P_Touchdowns2);


                var points1 = player1Yards * 0.1 + player1Touchdowns * 6;
                var points2 = player2Yards * 0.1 + player2Touchdowns * 6;


                if (points1 > points2)
                {


                    MessageBox.Show($"                                     -WINNER: {P_Name}{P_Team}-\n\n\n{P_Name}{P_Team} had {points1 - points2} more fantasy points than {P_Name2}{P_Team2}");

                }
                if (points2 > points1)
                {

                    MessageBox.Show($"                                     -WINNER: {P_Name2}{P_Team2}-\n\n\n{P_Name2}{P_Team2} had {points2 - points1} more fantasy points than {P_Name}{P_Team}");

                }

                if(points1 == points2)
                {

                    MessageBox.Show($"                                                              -TIE-\n\n\n{P_Name}{P_Team} has the same amount of fantasy points as {P_Name2}{P_Team2}");

                }

                //******************************************************************************************************************************************




            }

            }



            private void Player1_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {

            }

            private void Player2_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {

            }

        
        
    }
}
