using JavaCompiler.AnalisisLexico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaCompiler.Ast
{
    public class For : Statement
    {
        private VarDecl declaration;
        private Expresion expression;
        private Asignacion incExpression;
        private Statement stm;

        public For(VarDecl declaration, Expresion loopExpresion, Asignacion incExp, Statement stm)
        {
            this.declaration = declaration;
            this.expression = loopExpresion;
            this.incExpression = incExp;
            this.stm = stm;
            if (loopExpresion.tipo != Tipo.Bool) loopExpresion.error("se requiere booleano en for");
        }
    }
}
