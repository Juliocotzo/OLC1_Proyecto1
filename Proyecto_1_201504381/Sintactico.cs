using Irony.Parsing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;

namespace Proyecto_1_201504381
{

    class Sintactico : Grammar
    {
        static ArrayList errores = new ArrayList();
        static List<Token> token = new List<Token>();

        public static ParseTreeNode analizar(String cadena)
        {

            

            Gramatica gramatica = new Gramatica();
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parse = new Parser(lenguaje);
            ParseTree arbol = parse.Parse(cadena);
            ParseTreeNode raiz = arbol.Root;

            if (gramatica.Error.Count > 0 || raiz == null)
            {
                errores = gramatica.Error;
                return null;
            }
            else
            {
                token = arbol.Tokens;
                return raiz;
            }

        }





        public ArrayList Error
        {
            get { return errores; }
        }

        public List<Token> Tokens
        {
            get { return token; }
        }
    }   
}
