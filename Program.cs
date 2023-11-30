using System;
using System.Diagnostics;
using System.IO;
using System.Runtime;
using Cl1;

class Provodnic
{
    static string userName = Environment.UserName;      //определение имени устройства
    static void Main()
    {

        //ShowPapka("C:\\");
        Diski();
    }
    static void Diski()
    {
        while (true)
        {
            Console.Clear();
            //Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in allDrives)
            {
                Console.Write($"  {drive.Name} {drive.AvailableFreeSpace / (1024 * 1024 * 1024):N2} ГБ свободно из {drive.TotalSize / (1024 * 1024 * 1024):N2} ГБ");
                Console.WriteLine();
            }

            int pos = Menu.Show(0, allDrives.Length - 1);
            if (pos == -1)
            {
                return;
            }
            ShowPapka($"{allDrives[pos]}");
        }
    }
    static void ShowPapka(string p)
    {
        while (true)
        {
                                                                                   //var directory = new DirectoryInfo(p);
            Console.Clear();
            string[] paths = Directory.GetDirectories(p);                          //DirectoryInfo[] paths = directory.GetDirectories(p);
            string[] pathFiles = Directory.GetFiles(p);                                 //FileInfo[] pathFiles = directory.GetFiles(p);

            foreach (string path in paths)                                         //foreach (DirectoryInfo path in paths)
            {
                Console.WriteLine("  " + path);           //Console.WriteLine($"  {path.FullName} {path.CreationTime}");
            }
            
            foreach (string path1 in pathFiles)                                  //foreach (FileInfo path1 in pathFiles)
            {
                Console.WriteLine("  " + path1);                         //Console.WriteLine("  " + path1.FullName);
            }

            int poz = paths.Length + pathFiles.Length;

            int pos = Menu.Show(0, poz - 1);
            if (pos == -1 )
            {
                return;
            }
            if (pos < paths.Length)
            {
                ShowPapka(paths[pos]);
            }
            else
            {
                Process.Start(pathFiles[pos - paths.Length]);
                //ShowPapka(pathFiles[pos]);
            }
            //ShowPapka(paths[pos]);
        }
    }
}