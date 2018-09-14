using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithem_3._0
{
    class Class_ItemStorage
    {
        public static int[] PathDetermination(List<Item> ItemList, int NumberOfUsers, string GeneralPath)
        {
            int Counter2 = 0;
            int a = 2;
            int Folder = 0;
            Random rnd = new Random();
            int[] Folders = new int[ItemList.Count];

            foreach (Item ItemToSave in ItemList)
            {
                while (a > 1)
                {
                    Folder = rnd.Next(1, (Class_Data.NumberOfUsers + 1));
                    if ((File.Exists(GeneralPath + Folder + @"\" + ItemToSave.FileOuterId + "_" + ItemToSave.ItemInnerId + ".dsys")))
                    {
                        a = 2;
                    }
                    else
                    {
                        a = 0;
                    }
                }

                Folders[Counter2] = Folder;
                Counter2++;

                a = 2;

            }

            return Folders;
        }


        public static void ItemSaving(List<Item> ItemList, int[] folders, string GeneralPath)
        {

            int Counter1 = 0;
            foreach (Item ItemToSave in ItemList)
            {
                string Name = @"\" + ItemToSave.FileOuterId + "_" + ItemToSave.ItemInnerId + ".dsys";
                File.WriteAllBytes(GeneralPath + folders[Counter1] + Name, ItemToSave.ItemValue);
                Counter1++;


            }

        }
    }
}
