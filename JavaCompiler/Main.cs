using JavaCompiler.AnalisisLexico;
using JavaCompiler.AnalisisSintactico;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaCompiler
{
    class MainPrrogram
    {
        static void Main(string[] args)
        {

            var f = File.OpenText("program.java");
            string text = f.ReadToEnd();
            
            Lexer lex = new Lexer(text);
            Parser p = new Parser(lex);
            p.parseProgram();

            Console.WriteLine("Exito programa validado");
            Console.ReadKey();
        }
    }
}
