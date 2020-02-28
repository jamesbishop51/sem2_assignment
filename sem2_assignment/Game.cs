using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace sem2_assignment
{
    abstract class Game : IComparable
    {
        #region props
        public string Name { get; set; }
        public DateTime Released { get; set; }
        public double Sales { get; set; }
        public string Description { get; set; }

        public Review[] review { get; set; }

        public string GameImg { get; set; }






        #endregion props
        public Game()
        {
            review = new Review[20];
        }

        #region ctor
        #endregion ctor
        #region methods
        //sort the games

        public override string ToString()
        {
            return string.Format($"{Name}");
        }
        public int CompareTo(Object obj)
        {
            if (obj == null) return 1;
            Game games = obj as Game;
            if (games != null)
                return this.Name.CompareTo(games.Name);
            else
                throw new ArgumentException("");
        }
        #endregion methods
    }
    #region AbstractClasses
    class FpsGame : Game
    {

    }
    class LooterGame : Game
    {

    }
    class RtsGame : Game
    {

    }
    class SurvivalGames : Game
    {

    }
    class RpgGame : Game
    {

    }
    #endregion AbstractClasses
}
