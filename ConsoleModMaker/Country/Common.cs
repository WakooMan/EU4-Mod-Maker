using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleModMaker.Country
{
    class Common
    {
        private List<string> leader_names,ship_names;
        private List<Ideagroup> historical_ideas;
        private Color color, revolutionary_color;
        private Graphcult graphical_culture;
        private List<Unit> units;
        private List<Monarch> monarch_names;

        public Common() 
        {
            historical_ideas = new List<Ideagroup>();
            units = new List<Unit>();
            graphical_culture = new Graphcult();
            color = new Color(0,0,0);
            revolutionary_color = new Color(0, 0, 0);
            monarch_names = new List<Monarch>();
        }

        public Common(string leaders,string ships,List<Ideagroup> list1, List<Unit> list2, Color col,Color revcol,Graphcult gracult,List<Monarch> list3)
        {
            historical_ideas = list1;
            units = list2;
            graphical_culture = gracult;
            color = col;
            revolutionary_color = revcol;
            monarch_names = list3;
        }

        public List<string> Leader_names { get { return leader_names; } }
        public List<string> Ship_names { get { return ship_names; } }

        public Color Color { get { return color; } }

        public Color Revolutionary_color { get { return revolutionary_color; } }

        public List<string> Unitnames() 
        {
            List<string> list = new List<string>();
            for (int i = 0; i < units.Count; i++)
                list.Add(units[i].Name);
            return list;
        }

        public void SetColor(int r, int g, int b)
        {
            color.R = r; color.G = g; color.B = b;
        }

        public void SetRevColor(int r, int g, int b)
        {
            revolutionary_color.R = r; revolutionary_color.G = g; revolutionary_color.B = b;
        }

        public List<string> AIideanames() 
        {
            List<string> list = new List<string>();
            for (int i = 0; i < historical_ideas.Count; i++)
                list.Add(historical_ideas[i].Name);
            return list;
        }

        public List<string> MonarchNames()
        {
            List<string> list = new List<string>();
            for (int i = 0; i < monarch_names.Count; i++)
                list.Add(monarch_names[i].Name);
            return list;
        }

        public Graphcult Graphical_culture { get { return graphical_culture; }}

        public void SetGraphCult(string Name) { graphical_culture = new Graphcult(Name); }
    }
}
