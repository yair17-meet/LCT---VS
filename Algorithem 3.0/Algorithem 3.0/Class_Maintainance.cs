using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithem_3._0
{
    class Class_Maintainance
    {

        public static List<Data> MissingItems()
        {
            List<Data> MissisngData = new List<Data>();
            foreach (Data DataItem in Class_Data.DataList)
            {
                string path = Class_Data.GeneralPathToSave + DataItem.Location + @"\" + DataItem.OuterID + "_" + DataItem.InnerID + ".dsys";
                if (File.Exists(path) == false)
                {
                    MissisngData.Add(DataItem);
                }
            }
            return MissisngData;
        }

        public static int[] FindingNewUserToSave(List<Data> MissingItemsList)
        {
            int[] NewUser = new int[MissingItemsList.Count];
            int Count2 = 0;
            foreach (Data MissingItem in MissingItemsList)
            {
                Random rnd = new Random();
                int Count1 = 0;
                int NewItemLocation = -1;
                while (Count1 < 1)
                {
                    NewItemLocation = rnd.Next(1, (Class_Data.NumberOfUsers + 1));
                    if (Directory.Exists(Class_Data.GeneralPathToSave + NewItemLocation) == true)
                    {
                        var queryAllCustomers = from data in Class_Data.DataList
                                                where (data.OuterID == MissingItem.OuterID) && (data.InnerID == MissingItem.InnerID) && (data.Location == NewItemLocation)
                                                select data;
                        List<Data> IsThereTheSameItem = queryAllCustomers.ToList();
                        if (IsThereTheSameItem.Count == 0)
                        {
                            Count1 = 3;
                            NewUser[Count2] = NewItemLocation;
                            Count2++;
                        }
                    }
                }
            }
            return NewUser;

        }

        public static void Replace(int[] NewLocations, List<Data> MissingItems)
        {
            int Counter1 = 0;
            foreach (Data DataToDelete in MissingItems)
            {

                Class_Data.DataList.Remove(DataToDelete);

            }
            foreach (Data MissingItem in MissingItems)
            {
                var queryAllCustomers = from data in Class_Data.DataList
                                        where (data.OuterID == MissingItem.OuterID) && (data.InnerID == MissingItem.InnerID)
                                        select data;
                List<Data> ListOfDuplicationOptions = queryAllCustomers.ToList();
                Data ItemToDuplicate = ListOfDuplicationOptions.First();
                string NewPath = Class_Data.GeneralPathToSave + NewLocations[Counter1] + @"\" + MissingItem.OuterID + "_" + MissingItem.InnerID + ".dsys";
                byte[] NewValue = File.ReadAllBytes(Class_Data.GeneralPathToSave + ItemToDuplicate.Location + @"\" + ItemToDuplicate.OuterID + "_" + ItemToDuplicate.InnerID + ".dsys");
                File.WriteAllBytes(NewPath, NewValue);
                Data DataToSave = new Data(MissingItem.OuterID, MissingItem.InnerID, NewLocations[Counter1]);
                Class_Data.DataList.Add(DataToSave);

                Counter1++;
            }

        }
































        /*public static int[] IdentifyMissingItems(int[] Folders, string GeneralPath, long OuterId)
        {



            for (int i = 0; i < Folders.Length; i++)
            {

                if (File.Exists(GeneralPath + Folders[i] + @"\" + OuterId + "_" + i + ".dsys") == false)
                {
                    Folders[i] = -1;
                }




            }
            return Folders;

        }

        public static bool ChecksIfAnythingIsMissing(int[] FirstFoldersCopy, int[] SecondFoldersCopy)
        {
            bool IsMissing = false;
            for (int i = 0; i < FirstFoldersCopy.Length; i++)
            {
                if ((FirstFoldersCopy[i] == -1) || (SecondFoldersCopy[i] == -1))
                {
                    IsMissing = true;
                    i = FirstFoldersCopy.Length + 3;
                }

            }
            return IsMissing;

        }

        public static int WhichUserWasLost(int NumberOfUsers, string GeneralPath)
        {
            int MissingUser = NumberOfUsers + 12;
            for (int i = 0; i < NumberOfUsers; i++)
            {
                if (File.Exists(GeneralPath + i.ToString()) != true)
                {
                    MissingUser = i;
                }
            }
            return MissingUser;

        }


        public static int[] ItemReplacemant(int[] FirstFolderCopy, int[] SecondFolderCopy, int MissingUser, int NumberOfUsers, string GeneralPath, long OuterId)
        {
            int NewFolder = 0;

            for (int i = 0; i < FirstFolderCopy.Length; i++)
            {
                if (FirstFolderCopy[i] == -1)
                {
                    int a = 2;
                    while (a > 1)
                    {
                        Random rnd = new Random();
                        int b = 2;
                        while (b > 1)
                        {
                            NewFolder = rnd.Next(1, (NumberOfUsers + 1));
                            if (NewFolder != MissingUser)
                            {
                                b = 0;
                            }

                        }

                        if (File.Exists(GeneralPath + NewFolder + @"\" + OuterId + "_" + i + ".dsys"))
                        {
                            a = 2;
                        }
                        else
                        {
                            byte[] Value = File.ReadAllBytes(GeneralPath + SecondFolderCopy[i] + @"\" + OuterId + "_" + i + ".dsys");
                            File.WriteAllBytes(GeneralPath + NewFolder + @"\" + OuterId + "_" + i + ".dsys", Value);
                            a = 0;
                            FirstFolderCopy[i] = NewFolder;
                        }
                    }

                }
            }

            return FirstFolderCopy;

        }*/
    }
}
