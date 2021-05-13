using JavaCompiler.Tokens;

namespace JavaCompiler.AnalisisLexico
{
    public class Tipo : Palabra
    {
        public int anchura = 0; // anchura se usa para asignacion de almacenamiento
        private Tipo(string s, TokenType type) : base(s, type)
        {
        }
        public static Tipo
            Int = new Tipo("int", TokenType.INT),
            Float = new Tipo("float", TokenType.FLOAT),
            Char = new Tipo("char", TokenType.CHAR),
            Bool = new Tipo("boolean", TokenType.BOOLEAN),
            Class = new Tipo("class", TokenType.CLASS),
            String = new Tipo("String", TokenType.STRING);

        
        public static bool numerico(Tipo p)
        {
            if (p == Tipo.Char || p == Tipo.Int || p == Tipo.Float) return true;
            else return false;
        }
        public static Tipo max(Tipo p1, Tipo p2)
        {
            if (!numerico(p1) || !numerico(p2)) return null;
            else if (p1 == Tipo.Float || p2 == Tipo.Float) return Tipo.Float;
            else if (p1 == Tipo.Int || p2 == Tipo.Int) return Tipo.Int;
            else return Tipo.Char;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}