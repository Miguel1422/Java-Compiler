using JavaCompiler.Tokens;

namespace JavaCompiler.AnalisisLexico
{
    public class Num : Token
    {
        private int valorField;
        public int valor { get { return valorField; } }
        public Num(int v) : base(v.ToString(), TokenType.ENTERO)
        {
            valorField = v;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}