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
using System.IO;

namespace sem2_assignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Games[] AllGames;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //puts the games into an array
            AllGames = GetGames();


            LbxGames.ItemsSource = AllGames;
        }
        // creating the bands.
        private Games[] GetGames()
        {
            //fps games
            FpsGame f1 = new FpsGame() { Name = "Call of Duty: Modern Warfare ", Released = new DateTime(23/8/2019), Sales = 15000000, Description = "Call of Duty: Modern Warfare is a first-person shooter video game developed by Infinity Ward and published by Activision. ... The game's Special Ops mode features cooperative play missions that follow up the campaign's story. The multiplayer mode supports cross-platform multiplayer for the first time in the series." };
            FpsGame f2 = new FpsGame() { Name = "BattleField 5", Released = new DateTime(9/11/2018), Sales = 7300000, Description = "The latest entry in an iconic series that dates back to 2002, Battlefield 5 is a celebration of the chaos and the drama of combined arms warfare. At its core is the concept of the squad, a small group of players that can cooperate and coordinate together to achieve goals in-game." };

            //looter games
            LooterGame l1 = new LooterGame() { Name = "Borderlands 3", Released = new DateTime(13/9/2019), Sales = 20000000, Description = " Borderlands 3 is an action role-playing first-person shooter video game developed by Gearbox Software and published by 2K Games. It is the sequel to 2012's Borderlands 2, and the fourth main entry in the Borderlands series. " };
            LooterGame l2 = new LooterGame() { Name = "Tom Clancy's the division 2", Released = new DateTime(13/3/2019), Sales = 45000000, Description = "Tom Clancy's The Division 2 is a shooter RPG with campaign, co-op, and PvP modes that offers more variety in missions and challenges, new progression systems with unique twists and surprises, and fresh innovations that offer new ways to play."};

            //rts games
            RtsGame r1 = new RtsGame() { Name = "Supreme commander forged alliance", Released = new DateTime(6/11/2007), Sales = 2000000, Description = " Search ResultsFeatured snippet from the webSupreme Commander: Forged Alliance is a standalone real - time strategy video game expansion to Supreme Commander, and was released in November 2007, developed by Gas Powered Games and published by THQ, and the second title in the franchise. " };
            RtsGame r2 = new RtsGame() { Name = "Company of Heroes 2", Released = new DateTime(25/6/2013), Sales = 4000000, Description = "Company of Heroes 2 is a real-time strategy video game developed by Relic Entertainment and published by Sega for Microsoft Windows, OS X, and Linux. It is the sequel to the 2006 game Company of Heroes." };

            //indie games
            SurvivalGames s1 = new SurvivalGames() {Name = "No man's sky", Released = new DateTime(9/8/2016), Sales = 3000000, Description = "No Man's Sky is an action-adventure survival game played from a first or third person perspective that allows players to engage in four principal activities: exploration, survival, combat, and trading." };
            SurvivalGames s2 = new SurvivalGames() {Name = "Minecraft", Released = new DateTime(17/5/2009), Sales = 112000000, Description = "Minecraft is a sandbox video game created by Swedish developer Markus Persson, released by Mojang in 2011 and purchased by Microsoft in 2014. It is the single best-selling video game of all time, selling over 180 million copies across all platforms by late 2019, with over 112 million monthly active players." };

            // rpg games
            RpgGame rp1 = new RpgGame() { Name = "Fallout 4", Released = new DateTime(11/11/2015), Sales = 14910000, Description = "Fallout 4 is an action role-playing game developed by Bethesda Game Studios and published by Bethesda Softworks. ... The player explores the game's dilapidated world, completes various quests, helps out factions, and acquires experience points to level up and increase the abilities of their character." };
            RpgGame rp2 = new RpgGame() { Name = "Skyrim", Released = new DateTime(11/11/2011), Sales =  30000000, Description = "The Elder Scrolls V: Skyrim is an action role-playing game, playable from either a first or third-person perspective. The player may freely roam over the land of Skyrim which is an open world environment consisting of wilderness expanses, dungeons, cities, towns, fortresses, and villages. " };




            Games[] GamesCreated = { f1, f2, l1, l2, r1, r2, s1, s2, rp1, rp2 };
            return GamesCreated;
        }
    }
}
