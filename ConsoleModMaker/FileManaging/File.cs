using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleModMaker.FileManaging
{
    class File
    {
        private string filename;
        private StreamReader freader;
        private List<Expression> expressions;
        List<string> columns = new List<string>();

        public File(string fname)
        { filename = fname; expressions = new List<Expression>(); }
        public string Filename { get { return filename; } }
        public void ReadFile()
        {
            freader = new StreamReader(filename);
            while (!freader.EndOfStream)
            {
                string line = freader.ReadLine();
                if (!line.Trim().Equals("") && !line.Trim().StartsWith("#"))
                    columns.Add(line);
            }
            
            #region Kezdeti Értékek
            Expression currentExpression = null;
            int count = 0;
            Expression newExp = null;
            string name = "", ertek = "";
            #endregion
            #region AdatBeolvasás (Script)
            for (int i = 0; i < columns.Count; i++)
            {
                name = ""; ertek = "";
                if (columns[i].Contains("="))
                {
                    string[] tomb = columns[i].Split('=');
                    name = tomb[0];
                    ertek = tomb[1].Trim();
                    newExp = new Expression(count, name, ertek, currentExpression);
                    if (ertek.Equals("{"))
                    {
                        if (currentExpression == null)
                            expressions.Add(newExp);
                        else
                            currentExpression.AddExpression(newExp);
                        currentExpression = newExp;
                        count++;
                    }
                    else
                    {
                        if(currentExpression == null)
                            expressions.Add(newExp);
                        else
                            currentExpression.AddExpression(newExp);
                    }
                }
                else
                {
                    if (columns[i].Trim().Equals("}"))
                    {
                        if(currentExpression!=null)
                            currentExpression = currentExpression.ParentExpression();
                        count--;
                    }
                    else
                    {
                        newExp = new Expression(count, "", columns[i].Trim(), currentExpression);
                        if (currentExpression == null)
                            expressions.Add(newExp);
                        else
                            currentExpression.AddExpression(newExp);
                    }
                }
            }
            #endregion
            #region AdatBeolvasás (YAML)
            #endregion

        }

      
        public void WriteFile()
        {

        }

        public void WriteExpressions()
        {
            for (int i = 0; i < expressions.Count; i++)
            {
                expressions[i].Write();
            }
        }
    }
}
