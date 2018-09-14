using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithem_3._0
{
    class Class_ReconnectUser
    {
        public static int[] DisconnectedList()
        {
            int NumberOfDisconnected = 0;
            for (int i = 0; i < Class_Data.NumberOfUsers; i++)
            {
                if (Directory.Exists(@"C:\Users\Yair\OneDrive\יאיר כללי\לימודים כללי\פרויקט מדעית\Windows Form App 2.0\UnconnectedUsers\User" + (i + 1)))
                {
                    NumberOfDisconnected++;

                }
            }
            int[] DisconnectedUsers = new int[NumberOfDisconnected];
            int Counter1 = 0;
            for (int i = 0; i < Class_Data.NumberOfUsers; i++)
            {
                if (Directory.Exists(Class_Data.GeneralPathToDisconnectedUsers + (i + 1)))
                {
                    DisconnectedUsers[Counter1] = i + 1;
                    Counter1++;
                }
            }

            return DisconnectedUsers;


        }

        public static void DataUpdate(int UserToDataUpdate)
        {
            string[] Names = Directory.GetFileSystemEntries(Class_Data.GeneralPathToSave + UserToDataUpdate);
            foreach (string NameP in Names)
            {
                int NameBegin = NameP.LastIndexOf(@"\");
                string Name = "";
                for (int g = NameBegin + 1; g < NameP.LastIndexOf("") + 1; g++)
                {
                    Name = Name + NameP[g];
                }

                int OuterIdIntLocation = Name.LastIndexOf("_");
                string OuterIDString = Name.Substring(0, OuterIdIntLocation);
                int OuterID = int.Parse(OuterIDString);
                //int InnerIDIntLocation = Name.LastIndexOf(".");
                Name = "";
                for (int g = NameP.LastIndexOf("_") + 1; g < NameP.LastIndexOf("."); g++)
                {
                    Name = Name + NameP[g];
                }

                int InnerID = int.Parse(Name.Substring(0, Name.Length));
                int Location = UserToDataUpdate;
                Data TempDataToSave = new Data(OuterID, InnerID, Location);
                Class_Data.DataList.Add(TempDataToSave);



            }

        }
    }
}
