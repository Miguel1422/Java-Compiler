using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JavaCompiler.AnalisisLexico;

namespace JavaCompiler.Ast
{
    public class VarDeclAndAsig : VarDecl
    {
        private Asignacion asignacion;
        public VarDeclAndAsig(Tipo type, Identifier id, Asignacion asignacion) : base(type, id)
        {
            this.asignacion = asignacion;
        }
    }
}
