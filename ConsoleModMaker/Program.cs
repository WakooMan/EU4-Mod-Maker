using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleModMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            FileDataManager manager = new FileDataManager("C:\\Github Repos\\Egyéb\\EU! Mod Maker\\ConsoleModMaker\\Data\\AAC - Aachen.txt", "");
            FileManaging.File file = manager.GetFile(0);
            file.ReadFile();
            file.WriteExpressions();
            
            Console.ReadLine();
        }
    }
}
