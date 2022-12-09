using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class MyFolder
    {
        public string FolderName { get; private set; }
        public int FolderSize { get; set; } = 0;
        public MyFolder ParentFolder { get; set; }

        public MyFolder(string folderName, MyFolder parentFolder)
        {
            FolderName = folderName;
            ParentFolder = parentFolder;
        }

        //public int GetSizeFromSubFolders(List<MyFolder> folders)
        //{
        //    int size = 0;
        //    foreach (var item in folders)
        //    {
        //        if(item.ParentFolder == this) size += item.parent
        //    }
        //}
    }
}
