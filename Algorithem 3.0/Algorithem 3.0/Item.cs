using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithem_3._0
{
    class Item
    {
        public byte[] ItemValue { get; set; }
        public int ItemLength { get; set; }
        public int ItemInnerId { get; set; }
        public int FileOuterId { get; set; }


        public Item(int ItemInnerLengthTemperar, int ItemInnerIdTemperar, int FileOuterIdTemperar  /*,byte?[] ItemValue*/)
        {
            ItemValue = new byte[ItemInnerLengthTemperar];
            ItemLength = ItemInnerLengthTemperar;
            ItemInnerId = ItemInnerIdTemperar;
            FileOuterId = FileOuterIdTemperar;
        }
    }
}
