using JavaCompiler.AnalisisLexico;
using JavaCompiler.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaCompiler.Ast
{
    public class Identifier : Expresion
    {
        private string name;

        public Identifier(Token token, Tipo type) : base(token, type)
        {
            this.name = token.Lexeme;
        }

        public String getName()
        {
            return name;
        }
        
    }

}
