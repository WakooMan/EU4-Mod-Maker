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
            Tester tester = new Tester("D:\\Saját Projektek\\EU4ModMaker\\EU4-Mod-Maker\\Tests\\Input", "D:\\Saját Projektek\\EU4ModMaker\\EU4-Mod-Maker\\Tests\\Output", "D:\\Saját Projektek\\EU4ModMaker\\EU4-Mod-Maker\\Tests\\Results.txt");
            tester.TestFiles();
            Console.ReadLine();
        }
    }
}
