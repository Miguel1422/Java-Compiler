using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaCompiler.Tokens
{
    public class Token
    {
        public TokenType TokenType { get; }
        public string Lexeme { get; }
        

        public Token(string lexeme) : this(lexeme, TokenType.None) { }
        public Token(string lexeme, TokenType type)
        {
            this.TokenType = type;
            this.Lexeme = lexeme;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Lexeme, TokenType.ToString());

        }

        public override int GetHashCode()
        {
            return Lexeme.GetHashCode();
        }
    }
}
