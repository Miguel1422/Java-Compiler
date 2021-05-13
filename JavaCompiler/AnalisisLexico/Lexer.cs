using JavaCompiler.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JavaCompiler.AnalisisLexico
{

    internal class InputHelper
    {
        public static char EOF = '\0';
        private char[] buffer;
        private int index;
        private int currentLine;
        private int currentIndexAtLine;

        public int TotalIndex { get { return index; } }
        public int CurrentLine { get { return currentLine; } }
        public int CurrentIndexAtLine { get { return currentIndexAtLine; } }

        public InputHelper(string source)
        {
            this.buffer = source.ToCharArray();
            currentLine = 1;
            index = 0;
            currentIndexAtLine = 1;
        }


        public char Peek()
        {
            if (index == buffer.Length) return EOF;
            return buffer[index];
        }

        public char Read()
        {
            if (index == buffer.Length) return EOF;
            if (buffer[index] == '\n')
            {
                currentLine++;
                currentIndexAtLine = 0;
            };
            currentIndexAtLine++;
            return buffer[index++];
        }

        public bool Consume()
        {
            if (index == buffer.Length) return false;
            Read();
            return true;
        }

    }
    public class Lexer
    {
        private Dictionary<TokenType, string> regEx; // Token y su expresion regular asignada
        private Dictionary<string, Palabra> palabras = new Dictionary<string, Palabra>();
        private string sourceCode;

        private List<Token> tokens;
        private List<TokenInfo> tokensInfo;
        private InputHelper reader;

        public Lexer(string sourceCode)
        {
            this.sourceCode = sourceCode;

            tokens = new List<Token>();
            tokensInfo = new List<TokenInfo>();
            regEx = new Dictionary<TokenType, string>();
            reader = new InputHelper(sourceCode);
            Initialize();
            Tokenize();
        }

        private void Tokenize()
        {
            while (reader.Peek() != InputHelper.EOF)
            {
                TokenInfo actual = Explorar();
                tokens.Add(actual.Token);
                tokensInfo.Add(actual);
            }
            Token EOF = new Token("EOF", TokenType.EOF);
            tokens.Add(EOF);
            tokensInfo.Add(new TokenInfo(EOF, reader.CurrentLine, reader.CurrentIndexAtLine));
        }

        private Token ProcessWhiteSpace(char preanalisis)
        {
            Token ret = null;
            switch (preanalisis)
            {
                case '\r':
                    reader.Consume(); // Consume '\n'
                    ret = new Token("\\n", TokenType.NEWLINE);
                    break;
                case '\n':
                    ret = new Token("\\n", TokenType.NEWLINE);
                    break;
                case '\t':
                    ret = new Token("\\t", TokenType.TAB);
                    break;
                case ' ':
                    ret = new Token(" ", TokenType.WHITESPACE);
                    break;
                default:
                    throw new Exception("Invalid character");
            }
            return ret;
        }
        private Token ProcessId(char preanalisis)
        {
            StringBuilder b = new StringBuilder(preanalisis.ToString());
            while (Char.IsLetterOrDigit(reader.Peek()))
            {
                preanalisis = reader.Read();
                b.Append(preanalisis);
            }

            String s = b.ToString();

            if (palabras.ContainsKey(s))
            {
                return palabras[s];
            }
            Palabra w = new Palabra(s, TokenType.ID);
            palabras.Add(s, w);
            return w;
        }

        private Token ProcessNumber(char preanalisis)
        {
            if (Char.IsDigit(preanalisis))
            {
                int v = preanalisis - '0';
                while (Char.IsDigit(reader.Peek()))
                {
                    preanalisis = reader.Read();
                    v = 10 * v + (preanalisis - '0');
                }

                if (reader.Peek() != '.') return new Num(v);
                else
                {
                    reader.Read();

                    float x = v; float d = 10;
                    while (Char.IsDigit(reader.Peek()))
                    {
                        preanalisis = reader.Read();
                        x = x + (preanalisis - '0') / d; d = d * 10;
                    }
                    return new Real(x);
                }
            }
            throw new Exception("Number needed");
        }

        
        private TokenInfo Explorar()
        {
            int line = reader.CurrentLine;
            int index = reader.CurrentIndexAtLine;
            char actual = reader.Read();


            TokenInfo token = new TokenInfo(ExplorarAux(actual), line, index);
            token.Line = line;
            token.Index = index;
            return token;
        }
        private Token ExplorarAux(char preanalisis)
        {
            if (preanalisis == InputHelper.EOF)
            {
                return new Token("EOF", TokenType.EOF);
                // throw new Exception("Invalid character");
            }

            if (Char.IsWhiteSpace(preanalisis))
                return ProcessWhiteSpace(preanalisis);

            switch (preanalisis)
            {
                case '&':
                    if (reader.Peek() == '&' && reader.Consume()) return Palabra.AND; else return new Token("&", TokenType.ANDBINARIO);
                case '|':
                    if (reader.Peek() == '|' && reader.Consume()) return Palabra.OR; else return new Token("|", TokenType.ORBINARIO);
                case '=':
                    if (reader.Peek() == '=' && reader.Consume()) return Palabra.EQUALS; else return new Token("=", TokenType.ASIGNACION);
                case '!':
                    if (reader.Peek() == '=' && reader.Consume()) return Palabra.NEQUALS; else return new Token("!", TokenType.LNOT);
                case '<':
                    if (reader.Peek() == '=' && reader.Consume()) return Palabra.LESSEQ; else return new Token("<", TokenType.MENOR);
                case '>':
                    if (reader.Peek() == '=' && reader.Consume()) return Palabra.GREATE; else return new Token(">", TokenType.MAYOR);
            }

            switch (preanalisis)
            {
                case '/':
                    if (reader.Peek() == '/' && reader.Consume())
                    {
                        string lexeme = "//";
                        char ac;
                        do { ac = reader.Read(); lexeme += ac; }
                        while (ac != InputHelper.EOF && ac != '\n'); // Ignore until new line
                        return new Token(lexeme, TokenType.LINE_COMMENT);
                    }
                    else if (reader.Peek() == '*' && reader.Consume())
                    {
                        string lexeme = "/*";
                        char ac;
                        do { ac = reader.Read(); lexeme += ac; }
                        while (ac != InputHelper.EOF && !(ac == '*' && reader.Peek() == '/')); // Ignore until end of commentary
                        if (reader.Consume()) lexeme = lexeme.Substring(0, lexeme.Length - 1) + "*/";
                        return new Token(lexeme, TokenType.BLOCK_COMMENT);
                    }
                    else return new Token("/", TokenType.OPDIV);

            }
            switch (preanalisis)
            {
                case '+':
                    if (reader.Peek() == '+' && reader.Consume()) return new Token("++", TokenType.OPMASMAS); else break;
                case '-':
                    if (reader.Peek() == '-' && reader.Consume()) return new Token("++", TokenType.OPMENOSMENOS); else break;
            }

            switch (preanalisis)
            {
                case '"':
                    char actual = reader.Read();
                    string cadena = string.Empty;
                    while (actual != '"')
                    {
                        cadena += actual;
                        if(reader.Peek() == InputHelper.EOF) return new Token(cadena, TokenType.CADENA);
                        actual = reader.Read();
                    }
                    return new Token(cadena, TokenType.CADENA);
                
            }

            if (Char.IsDigit(preanalisis))
            {
                return ProcessNumber(preanalisis);
            }

            if (Char.IsLetter(preanalisis))
            {
                return ProcessId(preanalisis);
            }

            if (palabras.ContainsKey(preanalisis.ToString()))
            {
                return palabras[preanalisis.ToString()];
            }
            Token tok = new Token(preanalisis.ToString());
            return tok;
        }



        public List<Token> Tokens
        {
            get { return new List<Token>(tokens); }
        }

        public List<Token> TokensFiltered
        {
            get { return Tokens.Where(t => !t.TokenType.IsAuxiliary())./*OrderBy(a => a.Line).ThenBy(a => a.Index).*/ToList(); }
        }

        public List<TokenInfo> TokensInfo
        {
            get { return new List<TokenInfo>(tokensInfo); }
        }

        public List<TokenInfo> TokensFilteredInfo
        {
            get { return TokensInfo.Where(t => !t.Token.TokenType.IsAuxiliary())./*OrderBy(a => a.Line).ThenBy(a => a.Index).*/ToList(); }
        }
        private void reservar(Palabra word)
        {
            palabras.Add(word.Lexeme, word);
        }
        private void Initialize()
        {



            reservar(new Palabra("if", TokenType.IF));
            reservar(new Palabra("else", TokenType.ELSE));
            reservar(new Palabra("while", TokenType.WHILE));
            reservar(new Palabra("do", TokenType.DO));
            reservar(new Palabra("for", TokenType.FOR));
            reservar(new Palabra("public", TokenType.PUBLIC));
            reservar(new Palabra("static", TokenType.STATIC));
            reservar(new Palabra("void", TokenType.VOID));
            reservar(new Palabra("extends", TokenType.EXTENDS));
            reservar(new Palabra("return", TokenType.RETURN));
            reservar(new Palabra("null", TokenType.NULL));
            reservar(new Palabra("this", TokenType.THIS));
            reservar(new Palabra("new", TokenType.NEW));
            reservar(new Palabra("main", TokenType.MAIN));
            reservar(new Palabra("String", TokenType.STRING));


            reservar(new Palabra("abstract", TokenType.ABSTRACT));
            reservar(new Palabra("continue", TokenType.CONTINUE));
            reservar(new Palabra("switch", TokenType.SWITCH));
            reservar(new Palabra("assert", TokenType.ASSERT));
            reservar(new Palabra("default", TokenType.DEFAULT));
            reservar(new Palabra("goto", TokenType.GOTO));
            reservar(new Palabra("package", TokenType.PACKAGE));
            reservar(new Palabra("synchronized", TokenType.SYNCHRONIZED));
            reservar(new Palabra("private", TokenType.PRIVATE));
            reservar(new Palabra("break", TokenType.BREAK));
            reservar(new Palabra("double", TokenType.DOUBLE));
            reservar(new Palabra("implements", TokenType.IMPLEMENTS));
            reservar(new Palabra("protected", TokenType.PROTECTED));
            reservar(new Palabra("throw", TokenType.THROW));
            reservar(new Palabra("byte", TokenType.BYTE));
            reservar(new Palabra("import", TokenType.IMPORT));
            reservar(new Palabra("throws", TokenType.THROWS));
            reservar(new Palabra("case", TokenType.CASE));
            reservar(new Palabra("enum", TokenType.ENUM));
            reservar(new Palabra("instanceof", TokenType.INSTANCEOF));
            reservar(new Palabra("transient", TokenType.TRANSIENT));
            reservar(new Palabra("catch", TokenType.CATCH));
            reservar(new Palabra("short", TokenType.SHORT));
            reservar(new Palabra("try", TokenType.TRY));
            reservar(new Palabra("final", TokenType.FINAL));
            reservar(new Palabra("interface", TokenType.INTERFACE));
            reservar(new Palabra("class", TokenType.CLASS));
            reservar(new Palabra("finally", TokenType.FINALLY));
            reservar(new Palabra("long", TokenType.LONG));
            reservar(new Palabra("strictfp", TokenType.STRICTFP));
            reservar(new Palabra("volatile", TokenType.VOLATILE));
            reservar(new Palabra("const", TokenType.CONST));
            reservar(new Palabra("native", TokenType.NATIVE));
            reservar(new Palabra("super", TokenType.SUPER));


            reservar(Palabra.TRUE);
            reservar(Palabra.FALSE);
            reservar(Tipo.Int);
            reservar(Tipo.Char);
            reservar(Tipo.Bool);
            reservar(Tipo.Float);


            reservar(new Palabra(";", TokenType.PUNTOYCOMA));
            reservar(new Palabra("(", TokenType.IPAREN));
            reservar(new Palabra(")", TokenType.DPAREN));
            reservar(new Palabra("{", TokenType.LLAVEI));
            reservar(new Palabra("}", TokenType.LLAVED));
            reservar(new Palabra("<", TokenType.MENOR));
            reservar(new Palabra(">", TokenType.MAYOR));
            reservar(new Palabra(",", TokenType.COMA));
            reservar(new Palabra(".", TokenType.PUNTO));
            reservar(new Palabra("%", TokenType.MODULO));
            reservar(new Palabra("-", TokenType.OPMENOS));
            reservar(new Palabra("+", TokenType.OPMAS));
            reservar(new Palabra("*", TokenType.OPMULTI));
            // reservar(new Palabra("/", TokenType.DIV));
            reservar(new Palabra("[", TokenType.CORCHEI));
            reservar(new Palabra("]", TokenType.CORCHED));
            reservar(new Palabra("\"", TokenType.COMILLASDOBLES));
            reservar(new Palabra("'", TokenType.COMILLAS));
        }

        
    }
}

