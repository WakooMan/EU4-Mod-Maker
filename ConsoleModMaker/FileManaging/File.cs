using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReadingTest.FileManaging
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

        public List<string> Columns { get { return columns; } }
        public void ReadFile()
        {
            #region FileReading without reading comments
            using (freader = new StreamReader(filename))
            {
                while (!freader.EndOfStream)
                {
                    string line = freader.ReadLine();
                    if (!line.Trim().Equals("") && !line.Trim().StartsWith("#"))
                    {
                        if (line.Contains('#'))
                        {
                            bool inquote = false;
                            string newline = "";
                            for (int k = 0; k < line.Length; k++)
                            {
                                if (line[k].Equals('"'))
                                {
                                    if (inquote)
                                        inquote = false;
                                    else
                                        inquote = true;
                                }
                                if (!inquote && line[k].Equals('#'))
                                {
                                    k = line.Length - 1;
                                }
                                else
                                {
                                    newline += line[k];
                                }
                            }
                            columns.Add(newline + "\n");
                        }
                        else
                            columns.Add(line + "\n");
                    }
                }
            }
            #endregion

            #region Initial Values
            Expression currentExpression = null;
            int count = 0;
            int i = 0;  int j = 0;
            #endregion
            RecursiveRead(ref i,ref j,ref currentExpression,ref count);

        }
        #region Reading Data (Script format)
        //State Machine drawing is in the diagrams folder
        private void RecursiveRead(ref int i,ref int j,ref Expression ParentExpression, ref int level)
        {
            StateMachine sm = new StateMachine();
            string name = "", ertek = "";
            for (; i < columns.Count; i++)
            {
                for (; j < columns[i].Length; j++)
                {
                    Expression newExp = null;
                    States previousState = sm.CurrState;
                    sm.ChangeState(columns[i][j]);
                    if (sm.CurrState == States.NameState || sm.CurrState == States.QuoteNameState)
                    {
                        if (previousState == States.SearchEState)
                        {
                            ertek = name; name = "";
                            AddNewExpression(ref newExp, ref level, ref name, ref ertek, ref ParentExpression);
                        }
                        name += columns[i][j];

                    }
                    else if (sm.CurrState == States.ExpressionState||sm.CurrState==States.QuoteExpressionState)
                    {
                        ertek += columns[i][j];

                    }
                    else if (sm.CurrState == States.BracketState)
                    {

                        ertek = "{";
                        AddNewExpression(ref newExp, ref level, ref name, ref ertek, ref ParentExpression);
                        level++;
                        if (j == columns[i].Length - 1)
                        {
                            i++; j = 0;
                        }
                        else
                            j++;
                        RecursiveRead(ref i, ref j, ref newExp, ref level);
                        sm.ChangeState(columns[i][j]);
                    }
                    else if (sm.CurrState == States.LeaveState)
                    {
                        if (previousState == States.SearchEState || previousState == States.NameState)
                        {
                            ertek = name; name = "";
                            AddNewExpression(ref newExp, ref level, ref name, ref ertek, ref ParentExpression);
                        }
                        else if (previousState == States.ExpressionState)
                        {
                            AddNewExpression(ref newExp, ref level, ref name, ref ertek, ref ParentExpression);
                        }

                        level--;
                        return;
                    }
                    else if (sm.CurrState == States.SearchNState && previousState == States.ExpressionState)
                    {

                        AddNewExpression(ref newExp, ref level, ref name, ref ertek, ref ParentExpression);
                    }
                    else if (sm.CurrState == States.SearchEState && previousState == States.QuoteNameState)
                    {
                        name += '"';
                    }
                    else if (sm.CurrState == States.SearchNState && previousState == States.QuoteExpressionState) 
                    { 
                        ertek += '"'; 
                        AddNewExpression(ref newExp, ref level, ref name, ref ertek, ref ParentExpression);
                    } 
                    else if (i == columns.Count - 1 && j == columns[i].Length - 1)
                    {
                        ertek = name; name = "";
                        AddNewExpression(ref newExp, ref level, ref name, ref ertek, ref ParentExpression);
                    }
                }
                j = 0;
            }
        }

        private void AddNewExpression(ref Expression newExp,ref int level,ref string name,ref string ertek,ref Expression ParentExpression)
        {
            newExp = new Expression(level, name, ertek, ParentExpression);
            if (ParentExpression != null)
                ParentExpression.AddExpression(newExp);
            else
                expressions.Add(newExp);
            name = ""; ertek = "";
        }
        #endregion
        #region Reading Data (YAML format)
        #endregion

        public void WriteExpressions(string path)
        {
            using (StreamWriter wr = new StreamWriter(path + "/" + Path.GetFileName(filename)))
            {
                for (int i = 0; i < expressions.Count; i++)
                {
                    expressions[i].Write(wr);
                }
            }
        }
    }
}
