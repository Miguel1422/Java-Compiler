using JavaCompiler.AnalisisLexico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaCompiler.Ast
{
    public class If : Statement
    {
        Expresion expr; Statement instr;
        public If(Expresion x, Statement s)
        {
            expr = x; instr = s;
            if (expr.tipo != Tipo.Bool) expr.error("se requiere booleano en if");
        }

    }
}
