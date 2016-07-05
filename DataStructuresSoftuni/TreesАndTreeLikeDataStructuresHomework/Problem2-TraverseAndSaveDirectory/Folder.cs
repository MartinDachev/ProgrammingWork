using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem2_TraverseAndSaveDirectory
{
    class Folder
    {
        public string Name { get; set; }

        public IList<File> Files { get; set; }

        public IList<Folder> ChildFolders { get; set; }

        public Folder(string name)
        {
            this.Name = name;
            this.Files = new List<File>();
            this.ChildFolders = new List<Folder>();
        }

        public void PrintTree(int depth = 0)
        {
            Console.WriteLine("{0}{1}", new string(' ', depth), this.Name);

            foreach (var child in this.ChildFolders)
            {
                child.PrintTree(depth + 1);
            }
        }
    }
}
