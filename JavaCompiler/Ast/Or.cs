using JavaCompiler.AnalisisLexico;
using JavaCompiler.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaCompiler.Ast
{
    public class Or : Logica
    {
        public Or(Expresion x1, Expresion x2) : base(Palabra.OR, x1, x2)
        {
        }
        
    }
}
