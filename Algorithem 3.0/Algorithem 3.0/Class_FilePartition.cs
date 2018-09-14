using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithem_3._0
{
    class Class_FilePartition
    {
        
        //--------------------------------------------------------------------------------

        // finds the number of the last bytes in the file that are not in any item

        public static int LastBitsPart(int InitialFileLength, int ItemLength)
        {
            int NumberOfRegularLengthItems = InitialFileLength / ItemLength;
            return InitialFileLength - NumberOfRegularLengthItems * ItemLength;
        }

        //--------------------------------------------------------------------------------

        // recives a file byte arr and returns a a list of items made out of the original file 

        public static List<Item> FileDivision(byte[] InitialFile, int ItemLength, int LastBytes, int OuterId)
        {
            int ByteCounter = 0;
            int NumberOfRegularLengthItems = InitialFile.Length / ItemLength;
            Item TemporarLastItem = new Item(LastBytes, NumberOfRegularLengthItems, OuterId);
            List<Item> ItemsList = new List<Item>();
            for (int i = 0; i < NumberOfRegularLengthItems; i++)
            {
                Item TemporarItem = new Item(ItemLength, i, OuterId);
                for (int g = 0; g < ItemLength; g++)
                {
                    TemporarItem.ItemValue[g] = InitialFile[ByteCounter];
                    ByteCounter++;
                }
                ItemsList.Add(TemporarItem);
            }
            for (int i = 0; i < LastBytes; i++)
            {
                TemporarLastItem.ItemValue[i] = InitialFile[ByteCounter];
                ByteCounter++;
            }
            ItemsList.Add(TemporarLastItem);
            return ItemsList;
        }

        //--------------------------------------------------------------------------------

        // find the length of every item acording to the size of the original file

        public static int ItemLength(int InitialFileLength)
        {

            if (InitialFileLength <= 1000)
            {
                return 10;
            }
            if ((InitialFileLength > 1000) && (InitialFileLength <= 100000))
            {
                return 50;
            }
            if ((InitialFileLength > 100000) && (InitialFileLength <= 1000000))
            {
                return 1000;
            }
            else
            {
                return 50000;
            }

        }




        //--------------------------------------------------------------------------------

        //---------- Chooses a random Outer Id that has not been chosen yet ---------

        public static int ChooseOuterID()
        {
            int OuterID = 0;

            Random rnd = new Random();
            int aaa = 0;
            while (aaa < 1)
            {
                aaa = 2;
                OuterID = rnd.Next(1, 999999999);
                foreach (Data DataItem in Class_Data.DataList)
                {
                    if (DataItem.OuterID == OuterID)
                    {

                        aaa = 0;
                    }

                }
            }
            return OuterID;
        }


        //------------------------------------------------------------------------------------------

        //-------- Make the name of the File Unique ----------

        public static void FileNameSpaciel(string OriginalName)
        {
            int Counter1 = 1;
            int a1 = OriginalName.LastIndexOf(".");
            string Name1 = OriginalName.Substring(0, a1);
            string Ending1 = "";
            for (int i = a1; i < OriginalName.LastIndexOf("") + 1; i++)
            {
                Ending1 = Ending1 + OriginalName[i];
            }
            Class_Data.FileName = Name1 + "(" + Counter1.ToString() + ")" + Ending1;
            for (int i = 0; i < Counter1; i++)
            {
                foreach (string NameFromCollectioin in Class_Data.FileNameToOuterID.Keys)
                {
                    if (Class_Data.FileName == NameFromCollectioin)
                    {
                        Counter1++;
                        int a = OriginalName.LastIndexOf(".");
                        string Name = OriginalName.Substring(0, a);
                        string Ending = "";
                        for (int g = a; g < OriginalName.LastIndexOf("") + 1; g++)
                        {
                            Ending = Ending + OriginalName[g];
                        }
                        Class_Data.FileName = Name + "(" + Counter1.ToString() + ")" + Ending;
                    }
                }
            }




        }
    }
}

