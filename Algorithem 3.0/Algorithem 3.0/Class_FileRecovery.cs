using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithem_3._0
{
    class Class_FileRecovery
    {
        public static List<Data> FinalRestoredFileDataList(int OuterIDToRecover)
        {



            var queryAllCustomers = from data in Class_Data.DataList
                                    where data.OuterID == OuterIDToRecover
                                    orderby data.InnerID
                                    select data;
            List<Data> list = queryAllCustomers.ToList();
            List<Data> FinalList = new List<Data>();
            int Counter1 = 0;
            foreach (Data item in list)
            {

                if ((Counter1 + 1) != list.Count)
                {
                    if ((list[Counter1].InnerID) == list[Counter1 + 1].InnerID)
                    {
                        Counter1++;
                    }
                    else
                    {
                        Counter1++; FinalList.Add(item);
                    }
                }
                else
                {
                    FinalList.Add(item);
                }

            }
            return FinalList;
        }

        public static byte[] FileRecreation(List<Data> FinalDataList)
        {
            int FinalFileLength = 0;
            int Counter1 = 0;
            foreach (Data DataPart in FinalDataList)
            {
                FinalFileLength = FinalFileLength + File.ReadAllBytes(Class_Data.GeneralPathToSave + DataPart.Location + @"\" + DataPart.OuterID + "_" + DataPart.InnerID + ".dsys").Length;
            }
            byte[] FinalFile = new byte[FinalFileLength];

            foreach (Data DataPart in FinalDataList)
            {
                byte[] TempItem = File.ReadAllBytes(Class_Data.GeneralPathToSave + DataPart.Location + @"\" + DataPart.OuterID + "_" + DataPart.InnerID + ".dsys");
                for (int i = 0; i < TempItem.Length; i++)
                {
                    FinalFile[Counter1] = TempItem[i];
                    Counter1++;
                }

            }


            return FinalFile;
        }




































        /*public static List<Item> ItemListRecreation(int[] Folders, string GeneralPath, int FileOuterId)
        {

            List<Item> ItemList = new List<Item>();
            for (int i = 0; i < Folders.Length; i++)
            {
                byte[] ItemValue = File.ReadAllBytes(GeneralPath + Folders[i] + @"\" + FileOuterId + "_" + i + ".dsys");
                Item ItemToSave = new Item(ItemValue.Length, i, FileOuterId);
                ItemToSave.ItemValue = ItemValue;
                ItemList.Add(ItemToSave);
            }

            return ItemList;
        }


        public static byte[] FileRecreation(List<Item> ItemList)
        {
            int Counter1 = 0;
            int FileLength = 0;
            foreach (Item ItemForLength in ItemList)
            {

                FileLength = FileLength + ItemForLength.ItemValue.Length;

            }
            byte[] RestoredFile = new byte[FileLength];

            foreach (Item ItemToRestore in ItemList)
            {

                for (int i = 0; i < ItemToRestore.ItemValue.Length; i++)
                {
                    RestoredFile[Counter1] = ItemToRestore.ItemValue[i];
                    Counter1++;

                }

            }


            return RestoredFile;

        }*/
    }
}
