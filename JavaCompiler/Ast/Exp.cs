using JavaCompiler.AnalisisLexico;
using JavaCompiler.AnalisisSintactico;
using JavaCompiler.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaCompiler.Ast
{
    public class Expresion : Nodo
    {
        public Token op;
        public Tipo tipo;
        public Expresion(Token tok, Tipo p)
        {
            op = tok; tipo = p;
        }

        public void error(string v)
        {
            Parser.error(v);
        }

        public virtual Expresion gen()
        {
            return this;
        }
        public virtual Expresion reducir()
        {
            return this;
        }
    }
}
