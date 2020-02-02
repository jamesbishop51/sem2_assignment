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
    abstract class Games : IComparable
    {
        #region props
        public string Name { get; set; }
        public DateTime Released { get; set; }
        public int Sales { get; set; }
        public string Description { get; set; }

        public Reviews[] review { get; set; }


        public string[] Cover { get; set; }

        //these are props that i tried to use for the cover images
        //public System.Windows.Media.ImageSource Cover { get; set; }
        //public BitmapImage Cover { get; set; }

        #endregion props
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
            Games games = obj as Games;
            if (games != null)
                return this.Name.CompareTo(games.Name);
            else
                throw new ArgumentException("");
        }
        #endregion methods
    }
    #region AbstractClasses
    class FpsGame : Games
    {

    }
    class LooterGame : Games
    {

    }
    class RtsGame : Games
    {

    }
    class SurvivalGames : Games
    {

    }
    class RpgGame : Games
    {

    }
    #endregion AbstractClasses
}
