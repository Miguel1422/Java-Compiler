using JavaCompiler.AnalisisLexico;
using JavaCompiler.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaCompiler.Ast
{
    public class Relacion : Logica
    {
        public Relacion(Token tok, Expresion x1, Expresion x2) : base(tok, x1, x2)
        {
        }
        public override Tipo comprobar(Tipo p1, Tipo p2)
        {
            if (p1.TokenType == p2.TokenType) return Tipo.Bool;
            if (Tipo.max(p1, p2) != null) return Tipo.Bool;
            else return null;
        }
      
    }
}
