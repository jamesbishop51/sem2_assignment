using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem2_assignment
{
    abstract class Games : IComparable
    {
        #region props
        public string Name { get; set; }
        public DateTime Released { get; set; }
        public int Sales { get; set; }
        public string Description { get; set; }
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
