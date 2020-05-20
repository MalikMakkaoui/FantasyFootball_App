using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using NUnit.Framework;
using System.Linq;
using FootballAppTest;
using FootballApp;
using System.Threading.Tasks;
using System.Net.Http;
using System.Buffers;





namespace FootballAppTest
{



    [TestFixture]
    public class UnitTest1
    {
        public List<PlayersList> QBListTest = new List<PlayersList>();
        public List<PlayersList> RBListTest = new List<PlayersList>();
        public List<PlayersList> WRListTest = new List<PlayersList>();
        public string name;

        [Test]
        public async Task GetQBsTest()
        {
            // Loads all QB Players from NFL.com and puts them into a list

            var QBurl = "http://www.nfl.com/stats/categorystats?tabSeq=0&statisticCategory=PASSING&conference=null&season=2018&seasonType=REG&d-447263-s=PASSING_YARDS&d-447263-o=2&d-447263-n=1"; 

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
                else
                {
                   QBListTest.Add(new PlayersList { PlayerName = item.ChildNodes[3].InnerText.Trim(), PlayerTeam = "(" + item.ChildNodes[5].InnerText.Trim() + ")", PlayerYards = item.ChildNodes[17].InnerText.Trim().Replace(",", ""), PlayerTouchdowns = item.ChildNodes[23].InnerText.Trim() });

                }

            }

            // Testing if List was populated Correctly

            Assert.AreEqual("Ben Roethlisberger", QBListTest[0].PlayerName);
            Assert.AreEqual("Patrick Mahomes", QBListTest[1].PlayerName);
            Assert.AreEqual("Andy Dalton", QBListTest[24].PlayerName);
            Assert.AreEqual("Kyle Allen", QBListTest[49].PlayerName);

            //****************************************************************
        }


        [Test]
        public async Task GetRBsTest()
        {

            // Loads all RB Players from NFL.com and puts them into a list

            var url = "http://www.nfl.com/stats/categorystats?tabSeq=0&statisticCategory=RUSHING&conference=null&season=2018&seasonType=REG&d-447263-s=RUSHING_YARDS&d-447263-o=2&d-447263-n=1";


            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);



            var productsHtml_TABLE = htmlDocument.DocumentNode.Descendants("tr")
            .Where(node => node.GetAttributeValue("class", "")
            .Contains("")).ToList();

            //*******************************************************************************************************


            //Takes all players from list and puts them in a new list of type PlayesrList and assigns each player a name, team, yards amount, and touchdown amount.
            //
            //

            foreach (var item in productsHtml_TABLE)
            {
                name = item.ChildNodes[3].InnerText.Trim();
                if (name == "Player")
                {
                    continue;
                }
                else
                {
                    RBListTest.Add(new PlayersList { PlayerName = item.ChildNodes[3].InnerText.Trim(), PlayerTeam = "(" + item.ChildNodes[5].InnerText.Trim() + ")", PlayerYards = item.ChildNodes[13].InnerText.Trim().Replace(",", ""), PlayerTouchdowns = item.ChildNodes[19].InnerText.Trim() });

                }
            }

            
            Assert.AreEqual("Ezekiel Elliott", RBListTest[0].PlayerName);
            Assert.AreEqual("Saquon Barkley", RBListTest[1].PlayerName);
            Assert.AreEqual("Frank Gore", RBListTest[24].PlayerName);
            Assert.AreEqual("Rashaad Penny", RBListTest[49].PlayerName);


        }

        [Test]
        public async Task GetWRsTest()
        {

            // Loads all WR Players from NFL.com and puts them into a list

            var url = "http://www.nfl.com/stats/categorystats?tabSeq=0&statisticCategory=RECEIVING&conference=null&season=2018&seasonType=REG&d-447263-s=RECEIVING_YARDS&d-447263-o=2&d-447263-n=1";


            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);



            var productsHtml_TABLE = htmlDocument.DocumentNode.Descendants("tr")
            .Where(node => node.GetAttributeValue("class", "")
            .Contains("")).ToList();


            //*******************************************************************************************************


            //Takes all players from list and puts them in a new list of type PlayesrList and assigns each player a name, team, yards amount, and touchdown amount.
            //
            //

            foreach (var item in productsHtml_TABLE)
            {

                name = item.ChildNodes[3].InnerText.Trim();

                if (name == "Player")
                {
                    continue;
                }
                else
                {
                    WRListTest.Add(new PlayersList { PlayerName = item.ChildNodes[3].InnerText.Trim(), PlayerTeam = "(" + item.ChildNodes[5].InnerText.Trim() + ")", PlayerYards = item.ChildNodes[11].InnerText.Trim().Replace(",", ""), PlayerTouchdowns = item.ChildNodes[19].InnerText.Trim() });
                }




            }

            Assert.AreEqual("Julio Jones", WRListTest[0].PlayerName);
            Assert.AreEqual("DeAndre Hopkins", WRListTest[1].PlayerName);
            Assert.AreEqual("Sterling Shepard", WRListTest[24].PlayerName);
            Assert.AreEqual("Courtland Sutton", WRListTest[49].PlayerName);

        }

        [Test]

        public void Compare_Click_Test()
        {
            

  

        }




    }
}
