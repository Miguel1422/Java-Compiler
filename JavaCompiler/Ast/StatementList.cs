using System;
using System.Collections.Generic;

namespace JavaCompiler.Ast
{
    public class StatementList
    {
        private List<Statement> list;
        public StatementList()
        {
            list = new List<Statement>();
        }
        public void addElement(Statement statement)
        {
            list.Add(statement);
        }
    }
}