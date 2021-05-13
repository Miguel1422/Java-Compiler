using JavaCompiler.AnalisisSintactico;
using System;

namespace JavaCompiler.Ast
{
    public class Nodo
    {
        public void error(string s)
        {
            Parser.error(s);
        }
    }
}