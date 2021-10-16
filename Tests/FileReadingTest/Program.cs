using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReadingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Tester tester = new Tester("C:\\Github Repos\\Egyéb\\EU! Mod Maker\\Tests\\Input", "C:\\Github Repos\\Egyéb\\EU! Mod Maker\\Tests\\Output", "C:\\Github Repos\\Egyéb\\EU! Mod Maker\\Tests\\Results.txt");
            tester.TestFiles();
            Console.ReadLine();
        }
    }
}
