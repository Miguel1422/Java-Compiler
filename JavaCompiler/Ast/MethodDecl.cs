using JavaCompiler.AnalisisLexico;

namespace JavaCompiler.Ast
{
    public class MethodDecl
    {
        private Tipo returnType;
        private Identifier id;
        private Statement stm;

       
        public MethodDecl(Tipo returnType, Identifier id, Statement stm)
        {
            this.returnType = returnType;
            this.id = id;
            this.stm = stm;
        }

        public Tipo getReturnType()
        {
            return returnType;
        }

        

        public Identifier getId()
        {
            return id;
        }

        

        public Statement getStm()
        {
            return stm;
        }
        
        

    }
}