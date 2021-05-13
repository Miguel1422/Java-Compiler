using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaCompiler.Ast
{
    public class Print : Statement
    {

        private Expresion exp;

        public Print(Expresion exp)
        {
            this.exp = exp;
        }
        
    }

}
