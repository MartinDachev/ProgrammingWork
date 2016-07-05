using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Problem2_TraverseAndSaveDirectory
{
    class TraverseAndSaveDirectory
    {

        static void ConstructTree(DirectoryInfo dirInfo, Folder folder)
        {
            FileInfo[] files = new FileInfo[0];
            DirectoryInfo[] childDirs = new DirectoryInfo[0];

            try
            {
                files = dirInfo.GetFiles();
            }
            catch (UnauthorizedAccessException)
            {
            }

            try
            {
                childDirs = dirInfo.GetDirectories();
            }
            catch (UnauthorizedAccessException)
            {
            }

            Folder childFolder;

            foreach (var file in files)
            {
                folder.Files.Add(new File(file.Name, file.Length));
            }

            foreach (var childDir in childDirs)
            {
                childFolder = new Folder(childDir.Name);
                folder.ChildFolders.Add(childFolder);
                ConstructTree(childDir, childFolder);
            }
        }

        static long FolderSize(Folder folder)
        {
            long fileSizesSum = 0; 

            foreach (var file in folder.Files)
            {
                fileSizesSum += file.Size;
            }

            foreach (var subFolder in folder.ChildFolders)
            {
                fileSizesSum += FolderSize(subFolder);
            }

            return fileSizesSum;
        }

        static void Main(string[] args)
        {
            // Visual Studio should be running as Administrator,
            // or else it won't be able to open all folders in C:\Windows

            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Windows");
            Folder folder = new Folder(directoryInfo.Name);

            DateTime dateTime = DateTime.Now;

            // It could take up to a couple of minutes...
            ConstructTree(directoryInfo, folder);
            long folderSize = FolderSize(folder);


            // Uncomment the next line if you want to see the C:\Windows tree printed - the screen will overflow short after the start,
            // so please change the Console buffer size width and height both to the maximum 9999 - note that it will still overflow in height,
            // but you will be able to see more lines ;)
            
            // folder.PrintTree();

            Console.WriteLine("{0} folder size in:\nKB = {1}\nMB = {2}\nGB = {3}", folder.Name,
                folderSize / 1024.0, folderSize / (1024 * 1024.0), folderSize / (1024 * 1204 * 1024.0));
            
            Console.WriteLine("Done!!!");
            Console.WriteLine(":)");
            Console.ReadLine();
        }
    }
}
