using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReadingTest
{
    class Tester
    {
        private string inputfolder;
        private string outputfolder;
        private string [] filenames;
        private string[] directories;
        private string[][] dirfilenames;
        private StreamWriter wr;
        public Tester(string input, string output,string resultfile)
        {
            inputfolder = input;
            outputfolder = output;
            filenames = Directory.GetFiles(inputfolder);
            directories = Directory.GetDirectories(inputfolder);
            dirfilenames = new string[directories.Length][];
            wr = new StreamWriter(resultfile);
            for (int i = 0; i < directories.Length; i++)
                dirfilenames[i] = Directory.GetFiles(directories[i]);
        }

        public void TestFiles()
        {
            int count = 0, max=0;
            for (int i = 0; i < filenames.Length; i++)
            {
                FileManaging.File file = new FileManaging.File(filenames[i]);
                file.ReadFile();
                file.WriteExpressions(outputfolder);

                bool equals = CheckEqualFile(inputfolder+"\\"+Path.GetFileName(file.Filename),outputfolder+"\\"+Path.GetFileName(file.Filename));
                if (equals)
                {
                    wr.WriteLine(file.Filename + ": Test is successful.");
                    Console.WriteLine(file.Filename + ": Test is successful.");
                    count++;
                }
                else
                {
                    wr.WriteLine(file.Filename + ": Test failed.");
                    Console.WriteLine(file.Filename + ": Test failed.");
                }
                max++;
            }
            for (int i = 0; i < directories.Length; i++)
            {
                for (int j = 0; j < dirfilenames[i].Length; j++)
                {
                    FileManaging.File file = new FileManaging.File(dirfilenames[i][j]);
                    file.ReadFile();
                    Directory.CreateDirectory(outputfolder + "\\" + Path.GetFileName(directories[i]));
                    file.WriteExpressions(outputfolder+"\\"+Path.GetFileName(directories[i]));

                    bool equals = CheckEqualFile(directories[i] + "\\" + Path.GetFileName(file.Filename), outputfolder + "\\" + Path.GetFileName(directories[i])+"\\"+Path.GetFileName(file.Filename));
                    if (equals)
                    {
                        wr.WriteLine(file.Filename + ": Test is successful.");
                        Console.WriteLine(file.Filename + ": Test is successful.");
                        count++;
                    }
                    else
                    {
                        wr.WriteLine(file.Filename + ": Test failed.");
                        Console.WriteLine(file.Filename + ": Test failed.");
                    }
                    max++;
                }
            }
            wr.WriteLine("Successful Tests/Tests: " + count + "/" + max);
            Console.WriteLine("Successful Tests/Tests: " + count + "/" + max);
        }

        private bool CheckEqualFile(string inputfile, string outputfile)
        {
            FileManaging.File inputf = new FileManaging.File(inputfile);
            FileManaging.File outputf = new FileManaging.File(outputfile);
            inputf.ReadFile();
            outputf.ReadFile();
            for (int s = 0; s < inputf.Columns.Count; s++)
            {
                inputf.Columns[s] = inputf.Columns[s].Trim().Replace(" ","").Replace("\n","").Replace("\t","");
            }
            for (int s = 0; s < outputf.Columns.Count; s++)
            {
                outputf.Columns[s] = outputf.Columns[s].Trim().Replace(" ", "").Replace("\n", "").Replace("\t", "");
            }
            int i = 0, j = 0, x = 0, y = 0;
            while (i < inputf.Columns.Count && x < outputf.Columns.Count && inputf.Columns[i][j].Equals(outputf.Columns[x][y]))
            {
                if (j < inputf.Columns[i].Length-1)
                {
                    j++;
                }
                else
                {
                    j = 0;
                    i++;
                }

                if (y < outputf.Columns[x].Length-1)
                {
                    y++;
                }
                else
                {
                    y = 0;
                    x++;
                }
            }
            if (i != inputf.Columns.Count || x != outputf.Columns.Count)
            {
                if (i != inputf.Columns.Count)
                {
                    wr.WriteLine(inputf.Columns[i]);
                    wr.WriteLine(i + "-" + inputf.Columns.Count + " " + j + "-" + inputf.Columns[i][j] + " : " + x + "-" + outputf.Columns.Count);
                    Console.WriteLine(inputf.Columns[i]);
                    Console.WriteLine(i + "-" + inputf.Columns.Count + " " + j + "-" + inputf.Columns[i][j] + " : " + x + "-" + outputf.Columns.Count);
                }
                else
                {
                    wr.WriteLine(outputf.Columns[x]);
                    wr.WriteLine(i + "-" + inputf.Columns.Count + " : " + x + "-" + outputf.Columns.Count + " " + y + "-" + outputf.Columns[x][y]);
                    Console.WriteLine(outputf.Columns[x]);
                    Console.WriteLine(i + "-" + inputf.Columns.Count + " : " + x + "-" + outputf.Columns.Count + " " + y + "-" + outputf.Columns[x][y]);
                }
            }
            if (i == inputf.Columns.Count && x == outputf.Columns.Count)
                return true;
            else
                return false;
         }


    }
}
