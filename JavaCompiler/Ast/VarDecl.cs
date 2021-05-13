using JavaCompiler.AnalisisLexico;

namespace JavaCompiler.Ast
{
    public class VarDecl : Statement
    {
        private Tipo type;
        private Identifier id;

        public VarDecl(Tipo type, Identifier id)
        {
            this.type = type;
            this.id = id;
        }
    }
}