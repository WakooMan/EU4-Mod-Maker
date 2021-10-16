using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleModMaker.FileManaging
{
    class Expression
    {
        private int level;
        private string name;
        private string ertek;
        private List<Expression> childexpressions;
        private Expression parentexpression;

        public Expression(int lvl,string n,string ert,Expression parent) 
        { 
            level = lvl; name = n; ertek = ert;
            childexpressions =  new List<Expression>();
            parentexpression = parent;
        }
        public int Level { get { return level; } }
        public string Name { get { return name; } }
        public string Ertek { get { return ertek; }  }

        public List<Expression> ChildExpression()
        {
            return childexpressions;
        }

        public Expression ParentExpression() { return parentexpression; }

        public void AddExpression(Expression expression)
        {
            if(childexpressions!=null)
                childexpressions.Add(expression);
        }

        public void Write(StreamWriter wr)
        {
            for(int i=0;i<level;i++)
                wr.Write("\t");
            if(!name.Equals(""))
                wr.WriteLine(name + " = " + (ertek.Equals("{") ? "{" : ertek));
            else
                wr.WriteLine(ertek);
            for (int i = 0; i < childexpressions.Count; i++)
                childexpressions[i].Write(wr);
            if (ertek.Equals("{"))
            {
                for (int i = 0; i < level; i++)
                    wr.Write("\t");
                wr.WriteLine("}");
            }
        }
    }
}
