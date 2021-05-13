using JavaCompiler.Tokens;

namespace JavaCompiler.AnalisisLexico
{
    public class Real : Token
    {

        private float valorField;
        public float Valor { get { return valorField; } }
        public Real(float v) : base(((double)v).ToString("0.0######"), TokenType.FLOTANTE)
        {
            valorField = v;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }

}