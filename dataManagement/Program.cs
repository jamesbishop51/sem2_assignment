using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sem2_assignment;
using System.Data.Entity;

namespace dataManagement
{
    class Program
    {
        static void Main(string[] args)
        {

            GameData db = new GameData();

            using(db)
            {
                Game f1 = new Game() { GameId = 1, Name = "Call of Duty: Modern Warfare", Released = new DateTime(2019, 8, 23), Sales = 15000000, Description = "Call of Duty: Modern Warfare is a first-person shooter video game developed by Infinity Ward and published by Activision. ... The game's Special Ops mode features cooperative play missions that follow up the campaign's story. The multiplayer mode supports cross-platform multiplayer for the first time in the series.", GameImg = "https://visual-studio-images.s3.eu-west-1.amazonaws.com/img/cod.jpg", Genre = "fps" };
                Review re1 = new Review() { ReviewId = 1, Name = "Digital Chumps", ReviewDate = new DateTime(2019, 10, 24), Reviews = "Call of Duty: Modern Warfare puts the franchise back where it needs to be. You get a wonderful campaign, team-oriented spec ops, and a variety of multiplayer options that cater to those who love large and small scale warfare.", score = 80, GameId = 1, Game = f1 };

                Game f2 = new Game() { GameId = 2, Name = "BattleField 5", Released = new DateTime(2018, 11, 9), Sales = 7300000, Description = "The latest entry in an iconic series that dates back to 2002, Battlefield 5 is a celebration of the chaos and the drama of combined arms warfare. At its core is the concept of the squad, a small group of players that can cooperate and coordinate together to achieve goals in-game.", GameImg = "https://visual-studio-images.s3.eu-west-1.amazonaws.com/img/bf5.jpg", Genre = "fps" };
                Review re2 = new Review() { ReviewId = 2, Name = "TrueGaming", ReviewDate = new DateTime(2018, 12, 12), Reviews = "Battlefield V is another fun entry in this well established shooter series. The problem is that it's full of bugs and feels unfinished at launch.", score = 73, GameId = 2, Game = f2};

                Game l1 = new Game() { GameId = 3, Name = "Borderlands 3", Released = new DateTime(2019, 9, 13), Sales = 20000000, Description = " Borderlands 3 is an action role-playing first-person shooter video game developed by Gearbox Software and published by 2K Games. It is the sequel to 2012's Borderlands 2, and the fourth main entry in the Borderlands series. ", GameImg = "https://visual-studio-images.s3.eu-west-1.amazonaws.com/img/borderlands3.jpg", Genre = "looter" };
                Review re3 = new Review() { ReviewId = 3, Name = "PSX-Sense.nl", ReviewDate = new DateTime(2019, 9, 13), Reviews = "Borderlands 3 is more of the same in the best possible way, while some small tweaks to gunplay and exploration - being able to fight your way through multiple planets is invigorating - are welcome additions to the franchise.", score = 78, GameId = 3, Game = l1 };

                Game l2 = new Game() { GameId = 4, Name = "Tom Clancy's the division 2", Released = new DateTime(2019, 3, 13), Sales = 45000000, Description = "Tom Clancy's The Division 2 is a shooter RPG with campaign, co-op, and PvP modes that offers more variety in missions and challenges, new progression systems with unique twists and surprises, and fresh innovations that offer new ways to play.", GameImg = "https://visual-studio-images.s3.eu-west-1.amazonaws.com/img/division2.jpg", Genre = "looter" };
                Review re4 = new Review() { ReviewId = 4, Name = "Screen Rant", ReviewDate = new DateTime(2019, 3, 28), Reviews = "The negatives are vastly outweighed by all the brilliance The Division 2 brings to the table. There's a genuine argument to be made for the game's main campaign as being worth it on its own, far before the endgame gets its hooks in you. That's a genre first.", score = 82, GameId = 4, Game = l2};

                Game r1 = new Game() { GameId = 5, Name = "Supreme commander forged alliance", Released = new DateTime(2007, 11, 6), Sales = 2000000, Description = " Search ResultsFeatured snippet from the webSupreme Commander: Forged Alliance is a standalone real - time strategy video game expansion to Supreme Commander, and was released in November 2007, developed by Gas Powered Games and published by THQ, and the second title in the franchise. ", GameImg = "https://visual-studio-images.s3.eu-west-1.amazonaws.com/img/scfa.jpg", Genre = "rts" };
                Review re5 = new Review() { ReviewId = 5, Name = "My Gamer", ReviewDate = new DateTime(2007, 11, 6), Reviews = "Supreme Commander manages to excel on so many fronts that other strategy games fell short of, with giant maps and a monetary system that makes sense and simplifies making an army.", score = 81, GameId = 5, Game = r1 };

                Game r2 = new Game() { GameId = 6, Name = "Company of Heroes 2", Released = new DateTime(2013, 6, 25), Sales = 4000000, Description = "Company of Heroes 2 is a real-time strategy video game developed by Relic Entertainment and published by Sega for Microsoft Windows, OS X, and Linux. It is the sequel to the 2006 game Company of Heroes.", GameImg = "https://visual-studio-images.s3.eu-west-1.amazonaws.com/img/heroes2.jpg", Genre = "rts" };
                Review re6 = new Review() { ReviewId = 6, Name = "Destructoid", ReviewDate = new DateTime(2013, 6, 25), Reviews = "A shining example of what an RTS game should be: a mix of classic mechanics with new features and technology.", score = 80, GameId = 6, Game = r2 };

                Game s1 = new Game() { GameId = 7, Name = "No man's sky", Released = new DateTime(2016, 8, 9), Sales = 3000000, Description = "No Man's Sky is an action-adventure survival game played from a first or third person perspective that allows players to engage in four principal activities: exploration, survival, combat, and trading.", GameImg = "https://visual-studio-images.s3.eu-west-1.amazonaws.com/img/nms.jpg", Genre = "survival" };
                Review re7 = new Review() { ReviewId = 7, Name = "Hobby Consolas", ReviewDate = new DateTime(2016, 08, 18), Reviews = "No Man's Sky is a totally new experience. All Hello Games' promises are in the final game. The original soundtrack is awesome. It's a spectacular journey across the universe.", score = 71, GameId = 7, Game = s1 };

                Game s2 = new Game() { GameId = 8, Name = "Minecraft", Released = new DateTime(2009, 5, 17), Sales = 112000000, Description = "Minecraft is a sandbox video game created by Swedish developer Markus Persson, released by Mojang in 2011 and purchased by Microsoft in 2014. It is the single best-selling video game of all time, selling over 180 million copies across all platforms by late 2019, with over 112 million monthly active players.", GameImg = "https://visual-studio-images.s3.eu-west-1.amazonaws.com/img/minecraft.jpg", Genre = "survival" };
                Review re8 = new Review() { ReviewId = 8, Name = "1UP", ReviewDate = new DateTime(2011, 11, 21), Reviews = "Meanwhile, Minecraft, with all its flaws and quirks, has already joined Super Mario Brothers, Wolfenstein 3D, and Tetris in the pantheon of games that prototyped an entire genre.", score = 91, GameId = 8, Game = s2 };

                Game rp1 = new Game() { GameId = 9, Name = "Fallout 4", Released = new DateTime(2015, 11, 11), Sales = 14910000, Description = "Fallout 4 is an action role-playing game developed by Bethesda Game Studios and published by Bethesda Softworks. ... The player explores the game's dilapidated world, completes various quests, helps out factions, and acquires experience points to level up and increase the abilities of their character.", GameImg = "https://visual-studio-images.s3.eu-west-1.amazonaws.com/img/fallout4.jpg", Genre = "rpg" };
                Review re9 = new Review() { ReviewId = 9, Name = "JeuxActu", ReviewDate = new DateTime(2015, 11, 10), Reviews = "Unsurprisingly, Fallout 4 is closer to Fallout 3 than it is to the former episodes. And it comes with all the qualities and problems we already know. But Fallout 4 belongs to this hypnotizing kind of games that you should not miss if you love Western RPGs.", score = 84, GameId = 9, Game = rp1 };

                Game rp2 = new Game() { GameId = 10, Name = "Skyrim", Released = new DateTime(2011, 11, 11), Sales = 30000000, Description = "The Elder Scrolls V: Skyrim is an action role-playing game, playable from either a first or third-person perspective. The player may freely roam over the land of Skyrim which is an open world environment consisting of wilderness expanses, dungeons, cities, towns, fortresses, and villages. ", GameImg = "https://visual-studio-images.s3.eu-west-1.amazonaws.com/img/skyrim.jpg", Genre = "rpg" };
                Review re10 = new Review() { ReviewId = 10, Name = "Absolute Games", ReviewDate = new DateTime(2011, 11, 23), Reviews = "You will have to spend dozens of hours to fully explore Skyrim. Like any other Bethesda game, it has its share of imperfections and broken promises, but it's exciting and fascinating nevertheless.", score = 91, GameId = 10, Game = rp2 };

                db.Games.Add(f1);
                db.Games.Add(f2);
                db.Games.Add(l1);
                db.Games.Add(l2);
                db.Games.Add(r1);
                db.Games.Add(r2);
                db.Games.Add(s1);
                db.Games.Add(s2);
                db.Games.Add(rp1);
                db.Games.Add(rp2);

                Console.WriteLine("Added the games to the database");

                db.reviews.Add(re1);
                db.reviews.Add(re2);
                db.reviews.Add(re3);
                db.reviews.Add(re4);
                db.reviews.Add(re5);
                db.reviews.Add(re6);
                db.reviews.Add(re7);
                db.reviews.Add(re8);
                db.reviews.Add(re9);
                db.reviews.Add(re10);

                Console.WriteLine("Added the reviews to the database");

                db.SaveChanges();

                Console.WriteLine("saved to database");



            }



        }
    }
}
