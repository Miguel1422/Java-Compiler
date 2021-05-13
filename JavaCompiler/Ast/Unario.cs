using JavaCompiler.AnalisisLexico;
using JavaCompiler.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaCompiler.Ast
{
    public class Unario : Op
    {
        public Expresion expr;
        public Unario(Token tok, Expresion x) : base(tok, null)
        {
            // maneja el menos, para ! vea Not
            expr = x;
            tipo = Tipo.max(Tipo.Int, expr.tipo);
            if (tipo == null) error("error de tipo " + Tipo.Int.Lexeme + " no es compatible con " + expr.tipo.Lexeme);
        }
        public override Expresion gen()
        {
            return new Unario(op, expr.reducir());
        }
        public override string ToString()
        {
            return op.ToString() + " " + expr.ToString();
        }
    }
}
