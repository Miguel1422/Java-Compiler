using JavaCompiler.AnalisisLexico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaCompiler.Ast
{
    public class While : Statement
    {

        private Expresion expr;
        private Statement stm;

        public While(Expresion condExp, Statement stm)
        {
            this.expr = condExp;
            this.stm = stm;
            if (expr.tipo != Tipo.Bool) expr.error("se requiere booleano en while");
        }
    }

}
