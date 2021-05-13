using JavaCompiler.AnalisisLexico;
using JavaCompiler.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaCompiler.Ast
{
    public class Arit : Op
    {
        public Expresion expr1, expr2;
        public Arit(Token tok, Expresion x1, Expresion x2) : base(tok, null)
        {
            expr1 = x1; expr2 = x2;
            tipo = Tipo.max(expr1.tipo, expr2.tipo);
            if (tipo == null) error("error de tipo " + x1.tipo.Lexeme + " no es compatible con " + x2.tipo.Lexeme);
        }
        public override Expresion gen()
        {
            return new Arit(op, expr1.reducir(), expr2.reducir());
        }
        public override string ToString()
        {
            return expr1.ToString() + " " + op.ToString() + " " + expr2.ToString();
        }
    }
}
