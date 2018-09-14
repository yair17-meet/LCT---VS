using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithem_3._0
{
    class Class_Data
    {
        public static int[] FolderFirstCopy = new int[] { 1, 2, 3 };
        public static int[] FolderSecondCopy = new int[] { 1, 2, 3 };
        public static int OuterID = 0;
        public static int NumberOfUsers = 0;
        public static string FileName = "";
        public static string GeneralPathToSave = @"C:\Users\Yair\OneDrive\יאיר כללי\לימודים כללי\פרויקט מדעית\Windows Form App 2.0\FileSystem\User";
        public static string FinalLocation = @"C:\Users\Yair\OneDrive\יאיר כללי\לימודים כללי\פרויקט מדעית\Windows Form App 2.0\FinalLocation\";
        public static List<Data> DataList = new List<Data>();
        public static Dictionary<string, int> FileNameToOuterID = new Dictionary<string, int>();
        public static string GeneralPathToDisconnectedUsers = @"C:\Users\Yair\OneDrive\יאיר כללי\לימודים כללי\פרויקט מדעית\Windows Form App 2.0\UnconnectedUsers\User";
        public static int[] UnconnectedUsers = new int[1];

    }
}
