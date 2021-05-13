using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaCompiler.Tokens
{
    public enum TokenType
    {
        None,

        /*Identifier,
        Integer,
        Number,
        String,*/

        // Define literal tokens for all of the reserved words.
        CLASS, 	//  'class';
        PUBLIC, 	//  'public';
        PRIVATE,    // 'private'
        STATIC, 	//  'static';
        EXTENDS, 	//  'extends';
        VOID, 	//  'void';
        INT, 	//  'int';
        BOOLEAN, 	//  'boolean';
        CHAR,
        IF, 	//  'if';
        ELSE, 	//  'else';
        WHILE, 	//  'while';
        DO,     // 'do while';
        FOR,    // 'for';
        RETURN, 	//  'return';
        NULL, 	//  'null';
        TRUE, 	//  'true';
        FALSE, 	//  'false';
        THIS, 	//  'this';
        NEW, 	//  'new';
        STRING, // 'String';
        MAIN, 	//  'main';
        PRINT, 	//  'sout';
        FLOAT,  // 'float'

        // Operators
        OPMAS, 	//  '+';
        OPMASMAS, 	//  '++';
        OPMENOS, 	//  '-';
        OPMENOSMENOS, 	//  '--';
        OPMULTI, 	//  '*';
        OPDIV, 	//  '/';
        MENOR, 	//  '<';
        MENORIGUAL, //  '<=';
        MAYORIGUAL, //  '>=';
        MAYOR, 	//  '>';
        IGUAL, 	//  '==';
        DIFERENTE, 	//  '!=';
        LAND, 	//  '&&';
        LOR, 	//  '||';
        LNOT, 	//  '!';
        ANDBINARIO, // &
        ORBINARIO, // |
        MODULO, // %
        // Delimiters
        PUNTOYCOMA, 	//  ';';
        PUNTO, 	//  '.';
        COMA, 	//  ',';
        ASIGNACION, 	//  '=';
        IPAREN, 	//  '(';
        DPAREN, 	//  ')';
        LLAVEI, 	//  '{';
        LLAVED, 	//  '}';
        CORCHEI, 	//  '[';
        CORCHED, 	//  ']';
        COMILLASDOBLES, 	//  '"';
        COMILLAS, 	//  ''';
        CADENA, 	//  '"Hola"';

        // Constants
        ENTERO, // 1,2,3,4
        FLOTANTE, // 3.14, 0.0, 12.332

        // Whitespaces
        WHITESPACE, // ( )
        NEWLINE,    // (\n)
        TAB,        // (\t)
        CARRIAGERETURN,  // (\r)

        ID,
        LINE_COMMENT,
        BLOCK_COMMENT,
        TEMP,
        EOF,
        ABSTRACT,
        CONTINUE,
        SWITCH,
        ASSERT,
        DEFAULT,
        GOTO,
        PACKAGE,
        SYNCHRONIZED,
        BREAK,
        DOUBLE,
        IMPLEMENTS,
        PROTECTED,
        THROW,
        BYTE,
        IMPORT,
        THROWS,
        CASE,
        ENUM,
        INSTANCEOF,
        TRANSIENT,
        CATCH,
        SHORT,
        TRY,
        FINAL,
        INTERFACE,
        FINALLY,
        LONG,
        STRICTFP,
        VOLATILE,
        CONST,
        NATIVE,
        SUPER
    }

    public static class Methods
    {
        public static bool IsAuxiliary(this TokenType s1)
        {
            return s1 == TokenType.BLOCK_COMMENT || s1 == TokenType.LINE_COMMENT || s1 == TokenType.NEWLINE || s1 == TokenType.TAB
                    || s1 == TokenType.WHITESPACE;
        }
    }
}
