﻿using System;
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
using System.IO;
using Amazon;
using Amazon.S3.IO;
using Amazon.S3.Model;


namespace sem2_assignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        GameData db = new GameData();
        List<Game> Allgames = new List<Game>();
        List<Review> Reviews = new List<Review>();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // sets the source for the combo box for the genres
            string[] genres = { "all", "fps", "looter", "rts", "survival", "rpg" };
            CbxGenre.ItemsSource = genres;

            //sets the source for the list box to the games
            var query = from g in db.Games

                        select g;

            Allgames = query.ToList();
            LbxGames.ItemsSource = Allgames;


        }



        //pressing the power button will shut down the program
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        // filters the games based on the list box selection.
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (CbxGenre.SelectedItem != null)
            {
                // gets the selection.
                string selectedGenre = CbxGenre.SelectedItem as string;



                switch (selectedGenre)
                {
                    case "all":
                        LbxGames.ItemsSource = null;
                        LbxGames.ItemsSource = Allgames;
                        break;

                    case "fps":

                        LbxGames.ItemsSource = null;
                        LbxGames.ItemsSource = Allgames.Where(g => g.Genre.Equals("fps"));
                        break;

                    case "looter":

                        LbxGames.ItemsSource = null;
                        LbxGames.ItemsSource = Allgames.Where(g => g.Genre.Equals("looter"));
                        break;

                    case "rts":

                        LbxGames.ItemsSource = null;
                        LbxGames.ItemsSource = Allgames.Where(g => g.Genre.Equals("rts"));
                        break;

                    case "survival":

                        LbxGames.ItemsSource = null;
                        LbxGames.ItemsSource = Allgames.Where(g => g.Genre.Equals("survival"));
                        break;

                    case "rpg":

                        LbxGames.ItemsSource = null;
                        LbxGames.ItemsSource = Allgames.Where(g => g.Genre.Equals("rpg"));
                        break;


                }
            }

        }

        //displays all the information based on the selected game.
        private void LbxGames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //gets the selected game
            Game selectedGame = LbxGames.SelectedItem as Game;

            // null check
            if (selectedGame != null)
            {


                string sales = $"Total Sales: {selectedGame.Sales}";
                TxtSales.Text = sales;

                string released = "Release Date: " + string.Format("{0:dd/MM/yyyy}", selectedGame.Released);
                TxtReleased.Text = released;

                TxtDescription.Text = selectedGame.Description;

                ImgCover.Source = new BitmapImage(new Uri(selectedGame.GameImg, UriKind.RelativeOrAbsolute));

                //gets the information for the review by matching the games id in the review table with the selected games id
                var query = from r in db.reviews
                            where r.GameId == selectedGame.GameId
                            select r;

                var review = query.FirstOrDefault();

                TxtReview.Text = review.Reviews;

                string reviewDate = "Review Date: " + string.Format("{0:dd/MM/yyyy}", review.ReviewDate);
                TxtReviewDate.Text = reviewDate;

                string reviewer = "Reviewed By: " + review.Name;
                TxtReviewer.Text = reviewer;

                string score = "Score: " + review.score;
                TxtScore.Text = score;





            }
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void TxtDescription_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }



        //this was code that was being used before the switch to a database
        #region oldcode

        //this was the code that was used to get everything working before making the switch to pulling the information from the database.

        //    //puts the games into an array
        //    AllGames = GetGames();


        //    //sorts the games(not sure how this will work when i make the change to pulling the data from a file.)
        //    Array.Sort(AllGames);

        //    //sets the source for the list box to the games
        //    LbxGames.ItemsSource = AllGames;


        //this was the way the i created the games before pulling the information from the database.
        #region creating the games
        // creating the games.
        //private Game[] GetGames()
        //{

        // using this method to create the games to get everything else working before i make the switch and test out using a file to get the data everything
        // games
        //fps games
        // FpsGame f1 = new FpsGame() { GameId = 1, Name = "Call of Duty: Modern Warfare ", Released = new DateTime(2019,8,23), Sales = 15000000, Description = "Call of Duty: Modern Warfare is a first-person shooter video game developed by Infinity Ward and published by Activision. ... The game's Special Ops mode features cooperative play missions that follow up the campaign's story. The multiplayer mode supports cross-platform multiplayer for the first time in the series.", GameImg = "https://visual-studio-images.s3.eu-west-1.amazonaws.com/img/cod.jpg"};
        //FpsGame f2 = new FpsGame() { GameId = 2,Name = "BattleField 5", Released = new DateTime(2018,11 ,9), Sales = 7300000, Description = "The latest entry in an iconic series that dates back to 2002, Battlefield 5 is a celebration of the chaos and the drama of combined arms warfare. At its core is the concept of the squad, a small group of players that can cooperate and coordinate together to achieve goals in-game.", GameImg = "https://visual-studio-images.s3.eu-west-1.amazonaws.com/img/bf5.jpg" };

        //looter games
        //LooterGame l1 = new LooterGame() { GameId = 3, Name = "Borderlands 3", Released = new DateTime(2019, 9, 13), Sales = 20000000, Description = " Borderlands 3 is an action role-playing first-person shooter video game developed by Gearbox Software and published by 2K Games. It is the sequel to 2012's Borderlands 2, and the fourth main entry in the Borderlands series. ", GameImg = "https://visual-studio-images.s3.eu-west-1.amazonaws.com/img/borderlands3.jpg" };
        //LooterGame l2 = new LooterGame() { GameId = 4, Name = "Tom Clancy's the division 2", Released = new DateTime(2019,3,13), Sales = 45000000, Description = "Tom Clancy's The Division 2 is a shooter RPG with campaign, co-op, and PvP modes that offers more variety in missions and challenges, new progression systems with unique twists and surprises, and fresh innovations that offer new ways to play.", GameImg = "https://visual-studio-images.s3.eu-west-1.amazonaws.com/img/division2.jpg" };

        //Rts games
        //RtsGame r1 = new RtsGame() { GameId = 5, Name = "Supreme commander forged alliance", Released = new DateTime(2007,11,6), Sales = 2000000, Description = " Search ResultsFeatured snippet from the webSupreme Commander: Forged Alliance is a standalone real - time strategy video game expansion to Supreme Commander, and was released in November 2007, developed by Gas Powered Games and published by THQ, and the second title in the franchise. ", GameImg = "https://visual-studio-images.s3.eu-west-1.amazonaws.com/img/scfa.jpg" };
        //RtsGame r2 = new RtsGame() { GameId = 6, Name = "Company of Heroes 2", Released = new DateTime(2013,6,25), Sales = 4000000, Description = "Company of Heroes 2 is a real-time strategy video game developed by Relic Entertainment and published by Sega for Microsoft Windows, OS X, and Linux. It is the sequel to the 2006 game Company of Heroes.", GameImg = "https://visual-studio-images.s3.eu-west-1.amazonaws.com/img/heroes2.jpg" };

        ////Survival games
        //SurvivalGames s1 = new SurvivalGames() { GameId = 7, Name = "No man's sky", Released = new DateTime(2016,8,9), Sales = 3000000, Description = "No Man's Sky is an action-adventure survival game played from a first or third person perspective that allows players to engage in four principal activities: exploration, survival, combat, and trading.", GameImg = "https://visual-studio-images.s3.eu-west-1.amazonaws.com/img/nms.jpg" };
        //SurvivalGames s2 = new SurvivalGames() {GameId = 8, Name = "Minecraft", Released = new DateTime(2009,5,17), Sales = 112000000, Description = "Minecraft is a sandbox video game created by Swedish developer Markus Persson, released by Mojang in 2011 and purchased by Microsoft in 2014. It is the single best-selling video game of all time, selling over 180 million copies across all platforms by late 2019, with over 112 million monthly active players.", GameImg = "https://visual-studio-images.s3.eu-west-1.amazonaws.com/img/minecraft.jpg" };

        //rpg games
        //RpgGame rp1 = new RpgGame() { GameId = 9, Name = "Fallout 4", Released = new DateTime(2015,11,11), Sales = 14910000, Description = "Fallout 4 is an action role-playing game developed by Bethesda Game Studios and published by Bethesda Softworks. ... The player explores the game's dilapidated world, completes various quests, helps out factions, and acquires experience points to level up and increase the abilities of their character.",GameImg = "https://visual-studio-images.s3.eu-west-1.amazonaws.com/img/fallout4.jpg" };
        //RpgGame rp2 = new RpgGame() { GameId = 10, Name = "Skyrim", Released = new DateTime(2011,11,11), Sales = 30000000, Description = "The Elder Scrolls V: Skyrim is an action role-playing game, playable from either a first or third-person perspective. The player may freely roam over the land of Skyrim which is an open world environment consisting of wilderness expanses, dungeons, cities, towns, fortresses, and villages. ", GameImg = "https://visual-studio-images.s3.eu-west-1.amazonaws.com/img/skyrim.jpg" };

        #region reviews
        //// fps reviews
        // Review re1 = new Review() { ReviewId = 1, Name = "Digital Chumps", ReviewDate = new DateTime(2019,10,24), Reviews = "Call of Duty: Modern Warfare puts the franchise back where it needs to be. You get a wonderful campaign, team-oriented spec ops, and a variety of multiplayer options that cater to those who love large and small scale warfare.", score = 80 };
        //Review re2 = new Review() { ReviewId = 2, Name = "TrueGaming", ReviewDate = new DateTime(2018,12,12), Reviews = "Battlefield V is another fun entry in this well established shooter series. The problem is that it's full of bugs and feels unfinished at launch.", score = 73 };
        //  f1.review[0] = re1;
        // f2.review[0] = re2;

        ////looter reviews
        //Review re3 = new Review() { ReviewId = 3, Name = "PSX-Sense.nl", ReviewDate = new DateTime(2019,9,13), Reviews = "Borderlands 3 is more of the same in the best possible way, while some small tweaks to gunplay and exploration - being able to fight your way through multiple planets is invigorating - are welcome additions to the franchise.", score = 78 };
        //Review re4 = new Review() { ReviewId = 4, Name = "Screen Rant", ReviewDate = new DateTime(2019,3,28), Reviews = "The negatives are vastly outweighed by all the brilliance The Division 2 brings to the table. There's a genuine argument to be made for the game's main campaign as being worth it on its own, far before the endgame gets its hooks in you. That's a genre first.", score = 82 };
        //l1.review[0] = re3;
        // l2.review[0] = re4;


        //// rts reviews
        //Review re5 = new Review() { ReviewId = 5, Name = "My Gamer", ReviewDate = new DateTime(2007,11,6), Reviews = "Supreme Commander manages to excel on so many fronts that other strategy games fell short of, with giant maps and a monetary system that makes sense and simplifies making an army.", score = 81 };
        //Review re6 = new Review() { ReviewId = 6, Name = "Destructoid", ReviewDate = new DateTime(2013,6,25), Reviews = "A shining example of what an RTS game should be: a mix of classic mechanics with new features and technology.", score = 80 };
        //r1.review[0] = re5;
        //r2.review[0] = re6;


        // survival reviews
        //Review re7 = new Review() { ReviewId = 7, Name = "Hobby Consolas", ReviewDate = new DateTime(2016,08,18), Reviews = "No Man's Sky is a totally new experience. All Hello Games' promises are in the final game. The original soundtrack is awesome. It's a spectacular journey across the universe.", score = 71 };
        //Review re8 = new Review() { ReviewId = 8, Name = "1UP", ReviewDate = new DateTime(2011,11,21), Reviews = "Meanwhile, Minecraft, with all its flaws and quirks, has already joined Super Mario Brothers, Wolfenstein 3D, and Tetris in the pantheon of games that prototyped an entire genre.", score = 91 };
        //s1.review[0] = re7;
        //s2.review[0] = re8;



        //rpg reviews
        //Review re9 = new Review() { ReviewId = 9, Name = "JeuxActu", ReviewDate = new DateTime(2015,11,10), Reviews = "Unsurprisingly, Fallout 4 is closer to Fallout 3 than it is to the former episodes. And it comes with all the qualities and problems we already know. But Fallout 4 belongs to this hypnotizing kind of games that you should not miss if you love Western RPGs.", score = 84 };
        //Review re10 = new Review() { ReviewId = 10, Name = "Absolute Games", ReviewDate = new DateTime(2011,11,23), Reviews = "You will have to spend dozens of hours to fully explore Skyrim. Like any other Bethesda game, it has its share of imperfections and broken promises, but it's exciting and fascinating nevertheless.", score = 91 };
        //rp1.review[0] = re9;
        //rp2.review[0] = re10;


        #endregion reviews




        //    Game[] GamesCreated = { f1, f2, l1, l2, r1, r2, s1, s2, rp1, rp2 };
        //    return GamesCreated;
        //}
        #endregion creating the games

        //this was how i was filtering the games via the combo box
        #region combo box filtering

        //         if (CbxGenre.SelectedItem != null)
        //            {
        //                 gets the selection.
        //                string selectedGenre = CbxGenre.SelectedItem as string;

        //        Game[] filteredgames = new Game[4];
        //        int counter = 0;

        //                switch (selectedGenre)
        //                {
        //                    case "all":
        //                        LbxGames.ItemsSource = null;
        //                        LbxGames.ItemsSource = Allgames;
        //                        break;

        //                    case "fps":

        //                        foreach (Game currentgame in AllGames)
        //                        {
        //                            if (currentgame is FpsGame)
        //                            {
        //                                filteredgames[counter] = currentgame;
        //                                counter++;
        //                            }
        //}
        //LbxGames.ItemsSource = null;
        //                        LbxGames.ItemsSource = Allgames.Where(g => g.Genre.Equals("fps"));
        //                        break;

        //                    case "looter":
        //                        foreach (Game currentgame in AllGames)
        //                        {
        //                            if (currentgame is LooterGame)
        //                            {
        //                                filteredgames[counter] = currentgame;
        //                                counter++;
        //                            }
        //                        }
        //                        LbxGames.ItemsSource = null;
        //                        LbxGames.ItemsSource = Allgames.Where(g => g.Genre.Equals("looter"));
        //                        break;

        //                    case "rts":
        //                        foreach (Game currentgame in AllGames)
        //                        {
        //                            if (currentgame is RtsGame)
        //                            {
        //                                filteredgames[counter] = currentgame;
        //                                counter++;
        //                            }
        //                        }
        //                        LbxGames.ItemsSource = null;
        //                        LbxGames.ItemsSource = Allgames.Where(g => g.Genre.Equals("rts"));
        //                        break;

        //                    case "survival":
        //                        foreach (Game currentgame in AllGames)
        //                        {
        //                            if (currentgame is SurvivalGames)
        //                            {
        //                                filteredgames[counter] = currentgame;
        //                                counter++;
        //                            }
        //                        }
        //                        LbxGames.ItemsSource = null;
        //                        LbxGames.ItemsSource = Allgames.Where(g => g.Genre.Equals("survival"));
        //                        break;

        //                    case "rpg":
        //                        foreach (Game currentgame in AllGames)
        //                        {
        //                            if (currentgame is RpgGame)
        //                            {
        //                                filteredgames[counter] = currentgame;
        //                                counter++;

        //                            }
        //                        }
        //                        LbxGames.ItemsSource = null;
        //                        LbxGames.ItemsSource = Allgames.Where(g => g.Genre.Equals("rpg"));
        //                        break;


        //                }
        //}


        #endregion combo box filtering

        //this is how i was setting the source for the information about the games and the reviews depending on what game was clicked
        #region selection change

        //Game selectedGame = LbxGames.SelectedItem as Game;

        //    // null check
        //    if (selectedGame != null)
        //    {

        //TxtSales.Text = "Total Sales: " + selectedgame.Sales;
        //TxtReleased.Text = "Release Date: " + string.Format("{0:dd/MM/yyyy}", selectedgame.Released);
        //TxtDescription.Text = selectedgame.Description;
        //TxtReview.Text = selectedgame.review[0].Reviews;
        //TxtReviewDate.Text = "review date: " + selectedgame.review[0].ReviewDate;
        //TxtReviewer.Text = "Reviewed By: " + selectedgame.review[0].Name;
        //TxtScore.Text = "Score: " + selectedgame.review[0].score;
        //ImgCover.Source = new BitmapImage(new Uri(selectedgame.GameImg, UriKind.RelativeOrAbsolute));



        //}



        #endregion selection change



        #endregion oldcode
    }
}

