using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net.Http;
namespace FootballApp
{

    // Basically same class as QB class but needs to load a different URL and provides different data but same fields.
    //
    //

    class Get_WRs
    {

        public string name;

        public List<PlayersList> WRList = new List<PlayersList>();

        public async void GetWRs()
        {

            //var url = "http://www.nfl.com/stats/categorystats?tabSeq=0&statisticCategory=RECEIVING&conference=null&season=2018&seasonType=REG&d-447263-s=RECEIVING_YARDS&d-447263-o=2&d-447263-n=1";
            var url = "https://www.nfl.com/stats/player-stats/category/receiving/2019/REG/all/receivingreceptions/desc";

            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);



            var productsHtml_TABLE = htmlDocument.DocumentNode.Descendants("tr")
            .Where(node => node.GetAttributeValue("class", "")
            .Contains("")).ToList();


            foreach (var item in productsHtml_TABLE)
            {

                name = item.ChildNodes[3].InnerText.Trim();
            
                if (name == "Player")
                {
                    continue;
                }
                else
                {
                    WRList.Add(new PlayersList { PlayerName = item.ChildNodes[1].InnerText.Trim(), PlayerTeam = "", PlayerYards = item.ChildNodes[5].InnerText.Trim().Replace(",",""), PlayerTouchdowns = item.ChildNodes[7].InnerText.Trim() });
                }




            }
        }

    }
}
