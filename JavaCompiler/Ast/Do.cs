using JavaCompiler.AnalisisLexico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaCompiler.Ast
{
    class Do : Statement
    {
        private Expresion expr;
        Statement instr;
        public Do(Statement s, Expresion x)
        {
            expr = x; instr = s;
            if (expr.tipo != Tipo.Bool) expr.error("se requiere booleano en do");
        }
    }
}
