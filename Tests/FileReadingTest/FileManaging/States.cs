using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReadingTest.FileManaging
{
    enum States
    {
        SearchNState=0,
        NameState=1,
        SearchEState=2,
        EqualsState=3,
        ExpressionState=4,
        LeaveState=5,
        BracketState=6,
        QuoteNameState=7,
        QuoteExpressionState = 8
    }
}
