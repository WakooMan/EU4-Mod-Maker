using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ConsoleModMaker.Country;
using ConsoleModMaker.FileManaging;

namespace ConsoleModMaker
{
    class FileDataManager
    {
        private List<FileManaging.File> files = new List<FileManaging.File> ();

        public FileDataManager(string pdxfolder, string modfolder) 
        { files.Add(new FileManaging.File(pdxfolder)); }
        public FileManaging.File GetFile (int idx)
        {
            return files[idx];
        }

        public FileManaging.File GetFile(string fname)
        {
            int i = 0;
            while (!files[i].Filename.Equals(fname)&& i<files.Count)
            {
                i++;
            }

            if (i != files.Count)
                return files[i];
            else
                return null;
        }
    }
}
