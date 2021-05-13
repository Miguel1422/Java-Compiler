namespace JavaCompiler.Ast
{
    public class MainClass
    {
        private Identifier className;
        private MethodDecl mainMethod;

        public MainClass(Identifier className, MethodDecl mainMethod)
        {
            this.className = className;
            this.mainMethod = mainMethod;
        }
    }
}