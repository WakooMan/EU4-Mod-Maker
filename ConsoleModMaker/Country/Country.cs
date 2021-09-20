using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleModMaker.Country
{
    class Country
    {
        private string tag, name, flag;
        private Idea []ideas = new Idea [9];
        private Common common;
        private History history;

        public string Tag { get { return tag; } }
        public string Name { get { return name; } }
        public string Flag { get { return flag; } }
        public Common Common { get { return common; } }
        public History History { get { return history; } }


        public Country(string t,string n,string f) 
        {
            tag = t;
            name = n;
            flag = f;
            common = new Common();
            history = new History();
        }
    }
}
