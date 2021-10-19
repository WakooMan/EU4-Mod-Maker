using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReadingTest.FileManaging
{
    class StateMachine
    {
        private States currState;
        public States CurrState { get { return currState; } }

        public StateMachine() { currState = States.SearchNState; }

        private bool IsWS(char c)
        {
            return c.Equals('\n') || c.Equals(' ') || c.Equals('\t');
        }
        public void ChangeState(char c)
        {
            switch (currState)
            {
                case States.SearchNState:
                    if (c.Equals('"'))
                        currState = States.QuoteNameState;
                    else if (c.Equals('}'))
                        currState = States.LeaveState;
                    else if (!IsWS(c))
                        currState = States.NameState;
                    break;
                case States.NameState:
                    if (c.Equals('='))
                        currState = States.EqualsState;
                    else if (c.Equals('}'))
                        currState = States.LeaveState;
                    else if (IsWS(c))
                        currState = States.SearchEState;
                    break;
                case States.QuoteNameState:
                    if (c.Equals('"'))
                        currState = States.SearchEState;
                    break;
                case States.SearchEState:
                    if (c.Equals('"'))
                        currState = States.QuoteNameState;
                    else if (c.Equals('='))
                        currState = States.EqualsState;
                    else if (c.Equals('}'))
                        currState = States.LeaveState;
                    else if (!IsWS(c))
                        currState = States.NameState;
                    break;
                case States.EqualsState:
                    if (c.Equals('"'))
                        currState = States.QuoteExpressionState;
                    else if (c.Equals('{'))
                        currState = States.BracketState;
                    else if (!IsWS(c))
                        currState = States.ExpressionState;
                    break;
                case States.ExpressionState:
                    if (c.Equals('}'))
                        currState = States.LeaveState;
                    else if (IsWS(c))
                        currState = States.SearchNState;
                    break;
                case States.QuoteExpressionState:
                    if (c.Equals('"'))
                        currState = States.SearchNState;
                    break;
                case States.BracketState:
                    if (c.Equals('}'))
                        currState = States.SearchNState;
                    break;
                case States.LeaveState:
                    break;
            }
        }
    }
}
