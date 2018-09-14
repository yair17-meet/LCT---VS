using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithem_3._0
{
    class Class_DisconnectedUser
    {
        public static int IdentifyUser(string GeneralPathToSave)
        {
            int UserToDisconnect = 0;
            int Count1 = 0;
            int a = 0;
            for (int i = 0; i < Class_Data.NumberOfUsers; i++)
            {
                if (Directory.Exists(GeneralPathToSave + (Count1 + 1)))
                {
                    Count1++;

                }
                else
                {
                    i = Class_Data.NumberOfUsers + 1;
                }
            }
            int[] ExistingUsersArrey = new int[Count1];
            while (a < 1)
            {
                Random rnd = new Random();
                UserToDisconnect = rnd.Next(1, Class_Data.NumberOfUsers);
                if (Directory.Exists(GeneralPathToSave + UserToDisconnect))
                {
                    a = 4;
                }
            }
            Console.WriteLine(UserToDisconnect);

            for (int i = 0; i < Class_Data.UnconnectedUsers.Length; i++)
            {
                if (Class_Data.UnconnectedUsers[i]==0)
                {
                    Class_Data.UnconnectedUsers[i] = UserToDisconnect;
                    i = Class_Data.UnconnectedUsers.Length + 3;
                }
            }

            return UserToDisconnect;
        }

        public static void MoveToDisconnected(int UserToDisconnect, string GeneralPathToSave)
        {
            try
            {
                string a = GeneralPathToSave + UserToDisconnect.ToString();
                string c = Class_Data.GeneralPathToDisconnectedUsers + UserToDisconnect.ToString();

                Directory.Move(a, c);
            }
            catch (Exception e)
            {
                int b = 1;
            }

        }
    }
}
