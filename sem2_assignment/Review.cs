using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem2_assignment
{
    class Review
    {
        #region props
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReviewDate { get; set; }
        public string Reviews { get; set; }

        public int score { get; set; }
        #endregion props
        #region ctor


        #endregion ctor
        #region methods

        #endregion methods
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
