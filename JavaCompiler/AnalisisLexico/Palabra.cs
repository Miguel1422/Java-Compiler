using JavaCompiler.Tokens;

namespace JavaCompiler.AnalisisLexico
{
    public class Palabra : Token
    {
        public Palabra(string lexema, TokenType tipo) : base(lexema, tipo)
        {
        }
        public override string ToString()
        {
            return base.ToString();
        }

        public static Palabra AND { get { return new Palabra("&&", TokenType.LAND); } }
        public static Palabra OR { get { return new Palabra("||", TokenType.LOR); } }
        public static Palabra EQUALS { get { return new Palabra("==", TokenType.IGUAL); } }
        public static Palabra NEQUALS { get { return new Palabra("!=", TokenType.DIFERENTE); } }
        public static Palabra LESSEQ { get { return new Palabra("<=", TokenType.MENORIGUAL); } }
        public static Palabra GREATE { get { return new Palabra(">=", TokenType.MAYORIGUAL); } }
        public static Palabra MINUS { get { return new Palabra("minus", TokenType.OPMENOS); } }
        public static Palabra TRUE { get { return new Palabra("true", TokenType.TRUE); } }
        public static Palabra FALSE { get { return new Palabra("false", TokenType.FALSE); } }
        public static Palabra TEMP { get { return new Palabra("t", TokenType.TEMP); } }
        
    }
}