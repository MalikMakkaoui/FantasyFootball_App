using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net.Http;
namespace FootballApp
{
    public class Get_QBs
    {

        public string name;



        public List<PlayersList> QBList = new List<PlayersList>();
        

        

        public async void GetQBs()
        {


            // Loading URL and throwing player Data into a List
            //
            //
            //var QBurl = "http://www.nfl.com/stats/categorystats?tabSeq=0&statisticCategory=PASSING&conference=null&season=2018&seasonType=REG&d-447263-s=PASSING_YARDS&d-447263-o=2&d-447263-n=1"; 
            var QBurl = "https://www.nfl.com/stats/player-stats/";

            var QBhttpClient = new HttpClient();
            var QBhtml = await QBhttpClient.GetStringAsync(QBurl);

            var QBhtmlDocument = new HtmlDocument();
            QBhtmlDocument.LoadHtml(QBhtml);



            var QBproductsHtml_TABLE = QBhtmlDocument.DocumentNode.Descendants("tr")
            .Where(node => node.GetAttributeValue("class", "")
            .Contains("")).ToList();

            //*******************************************************************************************************


            //Takes all players from list and puts them in a new list of type PlayesrList and assigns each player a name, team, yards amount, and touchdown amount.
            //
            //
            foreach (var item in QBproductsHtml_TABLE)
            {
                name = item.ChildNodes[3].InnerText.Trim();
                if (name == "Player")
                {
                    continue;
                }
                else     // Changed Playername from 3 to 1 NO PLAYERTeaM ("+ item.ChildNodes[5].InnerText.Trim() + "). 
                {
                    QBList.Add(new PlayersList { PlayerName = item.ChildNodes[1].InnerText.Trim(), PlayerTeam = "", PlayerYards = item.ChildNodes[3].InnerText.Trim().Replace(",",""), PlayerTouchdowns = item.ChildNodes[13].InnerText.Trim()});
                    
                }
                
            }

            

            

            //*************************************************************************************************




        }
           



    }
}
     
