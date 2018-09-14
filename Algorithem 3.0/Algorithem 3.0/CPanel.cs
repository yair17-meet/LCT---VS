using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithem_3._0
{
    public partial class CPanel : MetroFramework.Forms.MetroForm
    {
        public static int NumberOfUsers;
        public static int OuterID;
        public static byte[] InitialFile;
        public static string FileName;
        public CPanel()
        {
            InitializeComponent();
        }

        private void CPanel_Load(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroTile7_Click(object sender, EventArgs e)
        {

        }

        private void metroPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel4_Click(object sender, EventArgs e)
        {

        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            metroPanel3.Visible = false;
            metroPanel4.Visible = false;
            metroPanel2.Visible = true;
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            foreach (string InitialFileName in Class_Data.FileNameToOuterID.Keys)
            {
                metroComboBox1.Items.Add(InitialFileName);
            }

            metroPanel2.Visible = false;
            metroPanel4.Visible = false;
            metroPanel3.Visible = true;
            
        }

        private void metroTabPage2_Click(object sender, EventArgs e)
        {

        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            int UserToDisconnect = Class_DisconnectedUser.IdentifyUser(Class_Data.GeneralPathToSave);
            // Console.WriteLine(UserToDisconnect);

            Class_DisconnectedUser.MoveToDisconnected(UserToDisconnect, Class_Data.GeneralPathToSave);
            System.Windows.Forms.MessageBox.Show("User" + UserToDisconnect + " has been disconnected!");
            
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            foreach (int UnconnectedUser in Class_Data.UnconnectedUsers)
            {
                if (UnconnectedUser!=0)
                {
                    metroComboBox2.Items.Add(UnconnectedUser.ToString());
                }
            }

            metroPanel2.Visible = false;
            metroPanel3.Visible = false;
            metroPanel4.Visible = true;
        }

        private void metroTile6_Click(object sender, EventArgs e)
        {
            List<Data> MissingDataList = Class_Maintainance.MissingItems();
            int[] NewLocations = Class_Maintainance.FindingNewUserToSave(MissingDataList);
            Class_Maintainance.Replace(NewLocations, MissingDataList);
            System.Windows.Forms.MessageBox.Show("Maintainance is complete!");






















            //Class_Data.FolderFirstCopy = Class_Maintainance.IdentifyMissingItems(Class_Data.FolderFirstCopy, GeneralPathToSave, Class_Data.OuterID);
            //Class_Data.FolderSecondCopy = Class_Maintainance.IdentifyMissingItems(Class_Data.FolderSecondCopy, GeneralPathToSave, Class_Data.OuterID);
            //bool MissingItemsBool = Class_Maintainance.ChecksIfAnythingIsMissing(Class_Data.FolderFirstCopy, Class_Data.FolderSecondCopy);
            //if (MissingItemsBool == true)
            //{
            //    int LostUser = Class_Maintainance.WhichUserWasLost(Class_Data.NumberOfUsers, GeneralPathToSave);
            //    Class_Data.FolderFirstCopy = Class_Maintainance.ItemReplacemant(Class_Data.FolderFirstCopy, Class_Data.FolderSecondCopy, LostUser, Class_Data.NumberOfUsers, GeneralPathToSave, Class_Data.OuterID);
            //    Class_Data.FolderSecondCopy = Class_Maintainance.ItemReplacemant(Class_Data.FolderSecondCopy, Class_Data.FolderFirstCopy, LostUser, Class_Data.NumberOfUsers, GeneralPathToSave, Class_Data.OuterID);
            //}

            // Class_Data.DataList;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            //DialogResult result = openFileDialog1.ShowDialog();
            var result = openFileDialog1.ShowDialog();
            InitialFile = File.ReadAllBytes(openFileDialog1.FileName);
            FileName = openFileDialog1.SafeFileName;
            Class_Data.FileName = FileName;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Security_AES256 aes = new Security_AES256("hthr7799");
            byte[] encFile = aes.EncryptByte(InitialFile);

            int NumberOfCopies = int.Parse(metroTextBox2.Text);
            OuterID = Class_FilePartition.ChooseOuterID();
            Class_FilePartition.FileNameSpaciel(FileName);
            Class_Data.FileNameToOuterID.Add(Class_Data.FileName, OuterID);
            Class_Data.OuterID = OuterID;
            int encFileLength = encFile.Length;
            int ItemLength = Class_FilePartition.ItemLength(encFileLength);
            int LastBytesLength = Class_FilePartition.LastBitsPart(encFileLength, ItemLength);
            List<Item> ItemList = Class_FilePartition.FileDivision(encFile, ItemLength, LastBytesLength, OuterID);


            for (int i = 0; i < NumberOfCopies; i++)
            {
                int[] FoldersFirstCopy = Class_ItemStorage.PathDetermination(ItemList, NumberOfUsers, Class_Data.GeneralPathToSave);
                for (int g = 0; g < FoldersFirstCopy.Length; g++)
                {
                    Data DataToList = new Data(OuterID, g, FoldersFirstCopy[g]);
                    Class_Data.DataList.Add(DataToList);
                }
                Class_ItemStorage.ItemSaving(ItemList, FoldersFirstCopy, Class_Data.GeneralPathToSave);

            }

            System.Windows.Forms.MessageBox.Show(Class_Data.FileName + " was successfully saved!");
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void metroTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            string SNumberOfUsers = metroTextBox1.Text;
            int INumberOfUsers = int.Parse(SNumberOfUsers);
            NumberOfUsers = INumberOfUsers;
            Class_Data.NumberOfUsers = NumberOfUsers;

            for (int i = 0; i < NumberOfUsers; i++)
            {
                Directory.CreateDirectory(Class_Data.GeneralPathToSave + (i + 1));
            }
            Class_Data.UnconnectedUsers = new int[Class_Data.NumberOfUsers];
            for (int i = 0; i < Class_Data.UnconnectedUsers.Length; i++)
            {
                Class_Data.UnconnectedUsers[i] = 0;
            }
            MessageBox.Show(Class_Data.NumberOfUsers + " new users have been created!");
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(@"C:\Users\Yair\OneDrive\יאיר כללי\לימודים כללי\פרויקט מדעית\Windows Form App 2.0\FileSystem");

            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                EmptyFolder(dir);
            }
            

            System.IO.DirectoryInfo dii = new DirectoryInfo(@"C:\Users\Yair\OneDrive\יאיר כללי\לימודים כללי\פרויקט מדעית\Windows Form App 2.0\FinalLocation");

            foreach (FileInfo file in dii.GetFiles())
            {
                file.Delete();
            }
           

            System.IO.DirectoryInfo diii = new DirectoryInfo(@"C:\Users\Yair\OneDrive\יאיר כללי\לימודים כללי\פרויקט מדעית\Windows Form App 2.0\UnconnectedUsers");

            foreach (FileInfo file in diii.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in diii.GetDirectories())
            {
                EmptyFolder(dir);
            }
            System.Windows.Forms.MessageBox.Show("System is ready!");
        }

        private void EmptyFolder(DirectoryInfo directoryInfo)
        {
            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                file.Delete();
            }

            foreach (DirectoryInfo subfolder in directoryInfo.GetDirectories())
            {
                EmptyFolder(subfolder);
            }
            directoryInfo.Delete(true);
        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            string SelectedFile = metroComboBox1.Text;
            int OuterIDToRecover = Class_Data.FileNameToOuterID[SelectedFile];



            List<Data> FinalDataList = Class_FileRecovery.FinalRestoredFileDataList(OuterIDToRecover);
            byte[] FinalFile = Class_FileRecovery.FileRecreation(FinalDataList);

            Security_AES256 aes = new Security_AES256("hthr7799");
            byte[] decFile = aes.DecryptByte(FinalFile);

            File.WriteAllBytes(Class_Data.FinalLocation + SelectedFile, decFile);

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = Class_Data.FinalLocation + SelectedFile;
            process.Start();


            System.Windows.Forms.MessageBox.Show(SelectedFile + " has been successfully restored!");
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroButton6_Click(object sender, EventArgs e)
        {

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            string SSelectedUser = metroComboBox2.Text;
            int SelectedUser = int.Parse(SSelectedUser);
            Directory.Move(Class_Data.GeneralPathToDisconnectedUsers + SelectedUser, Class_Data.GeneralPathToSave + SelectedUser);
            Class_ReconnectUser.DataUpdate(SelectedUser);
            System.Windows.Forms.MessageBox.Show("User"+SelectedUser.ToString()+" is reconnected!");

        }
    }
}
