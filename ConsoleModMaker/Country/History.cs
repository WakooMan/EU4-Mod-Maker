using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleModMaker.Country
{
    class History
    {
        private int mercantilism;
        private Culture primary;
        private List<Culture> accepted;
        private Techgroup techgroup;
        private Religion religion;
        private Government government;
        private Province capital, fixed_capital;
        private List<Ruler> rulers;

        public History() { }

        public int Mercantilism { get { return mercantilism; } }
    }
}
