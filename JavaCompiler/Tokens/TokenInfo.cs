using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaCompiler.Tokens
{
    public class TokenInfo
    {
        public Token Token { get; }
        public int Index { get; set; }
        public int EndIndex { get { return Index + Token.Lexeme.Length; } }
        public int Line { get; set; }
        private static string[] keywords = {
                "abstract", "continue", "for", "new", "switch",
                "assert", "default", "goto", "package", "synchronized",
                "boolean", "do", "if", "private", "this",
                "break", "double", "implements", "protected", "throw",
                "byte", "else", "import", "public", "throws",
                "case", "enum", "instanceof", "return", "transient",
                "catch", "extends", "int", "short", "try",
                "char", "final", "interface", "static", "void",
                "class", "finally", "long", "strictfp", "volatile",
                "const", "float", "native", "super", "while"};

        private static string[] types =
        {
            "byte", "short", "int", "long", "float", "double", "char", "boolean"
        };

        private static string[] ciclos =
        {
            "for", "while", "do"
        };

        public TokenInfo(Token token, int line, int index)
        {
            this.Line = line;
            this.Index = index;
            this.Token = token;
        }
        public bool IsKeyword
        {
            get
            {
                return keywords.Contains(Token.Lexeme);
            }
        }

        public bool IsType
        {
            get
            {
                return types.Contains(Token.Lexeme);
            }
        }

        public bool IsLoop
        {
            get
            {
                return ciclos.Contains(Token.Lexeme);
            }
        }

        public override string ToString()
        {
            if (IsType)
            {
                return "Tipo de dato " + Token.Lexeme + " linea: " + string.Format("[{0,2}:{1,2}]", Line, Index);
            } else if (IsLoop)
            {
                return "Ciclo " + Token.Lexeme + " linea: " + string.Format("[{0,2}:{1,2}]", Line, Index);
            }
            else if (IsKeyword)
            {
                return "Palabra reservada " + Token.Lexeme + " linea: " + string.Format("[{0,2}:{1,2}]", Line, Index);
            }
            return Token.ToString() + "linea: " + string.Format("[{0,2}:{1,2}]", Line, Index);
        }
    }
}
