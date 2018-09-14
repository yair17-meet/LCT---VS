using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithem_3._0
{
    class Data
    {


        public int InnerID { get; set; }
        public int OuterID { get; set; }
        public int Location { get; set; }




        public Data(int TempOuterID, int TempInnerID, int TempLocation)
        {
            InnerID = TempInnerID;
            OuterID = TempOuterID;
            Location = TempLocation;



        }
    }
}
