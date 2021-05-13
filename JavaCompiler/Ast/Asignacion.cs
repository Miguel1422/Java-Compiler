using JavaCompiler.AnalisisLexico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaCompiler.Ast
{
    public class Asignacion : Statement
    {

        private Identifier id;
        private Expresion expr;

        public Asignacion(Identifier id, Expresion value)
        {
            this.id = id;
            this.expr = value;
            if (comprobar(id.tipo, expr.tipo) == null) error("error de tipo " + id.tipo.Lexeme + " no es compatible con " + expr.tipo.Lexeme);
        }
        public Tipo comprobar(Tipo p1, Tipo p2)
        {
            if (Tipo.numerico(p1) && Tipo.numerico(p2)) return p2;
            else if (p1 == Tipo.Bool && p2 == Tipo.Bool) return p2;
            else if (p1 == Tipo.String && p2 == Tipo.String) return p2;
            else return null;
        }

        public Identifier getId()
        {
            return id;
        }
        

    }
}
