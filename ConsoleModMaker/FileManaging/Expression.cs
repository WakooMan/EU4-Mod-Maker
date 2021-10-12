using System;
using System.Collections.Generic;
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

        public void Write()
        {
            for(int i=0;i<level;i++)
                Console.Write("\t");
            if(!name.Equals(""))
                Console.WriteLine(name + " = " + (ertek.Equals("{}") ? "{" : ertek));
            else
                Console.WriteLine(ertek);
            for (int i = 0; i < childexpressions.Count; i++)
                childexpressions[i].Write();
            if (ertek.Equals("{"))
            {
                for (int i = 0; i < level; i++)
                    Console.Write("\t");
                Console.WriteLine("}");
            }
        }
    }
}
