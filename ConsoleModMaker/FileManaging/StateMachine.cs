using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleModMaker.FileManaging
{
    class StateMachine
    {
        private States currState;
        public States CurrState { get { return currState; } }

        public StateMachine() { currState = States.SearchNState; }

        public void ChangeState(char c)
        {
        
            
            switch (c)
            {
                case ' ':
                case '\t':
                case '\n':
                    if (currState == States.NameState)
                        currState = States.SearchEState;
                    else if (currState == States.ExpressionState)
                        currState = States.SearchNState;
                    break;
                case '{':
                    if (currState == States.EqualsState)
                        currState = States.BracketState;
                    break;
                case '}':
                    if (currState != States.BracketState && currState != States.LeaveState)
                        currState = States.LeaveState;
                    else if (currState == States.BracketState)
                        currState = States.SearchNState;
                    break;
                case '=':
                    if (CurrState == States.SearchEState||CurrState==States.NameState)
                        currState = States.EqualsState;
                    break;
                case '"':
                    if (currState == States.SearchNState)
                        currState = States.QuoteNameState;
                    else if (currState == States.QuoteNameState)
                        currState = States.SearchEState;
                    else if (currState == States.EqualsState)
                        currState = States.QuoteExpressionState; 
                    else if (currState == States.SearchEState)
                        currState = States.QuoteNameState;
                    else if (currState == States.QuoteExpressionState) 
                        currState = States.SearchNState; 
                    break;
                default:
                    if (currState == States.SearchNState)
                        currState = States.NameState;
                    else if (currState == States.EqualsState)
                        currState = States.ExpressionState;
                    else if (currState == States.SearchEState)
                        currState = States.NameState;
                    break;

            }
         
        }
    }
}
