using JavaCompiler.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaCompiler.Ast
{
    public class Not : Logica
    {
        public Not(Token tok, Expresion x2) : base(tok, x2, x2)
        { }
        
        public override string ToString()
        {
            return op.ToString() + " " + expr2.ToString();
        }
    }
}
