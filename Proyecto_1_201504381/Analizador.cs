using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Proyecto_1_201504381
{
    class Analizador
    {
        public static ParseTree padre;
        public bool esCadenaValida(string cadenaEntrada, Grammar gramatica)
        {
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser p = new Parser(lenguaje);
            Array[] errores = new Array[10];
            
            try
            {
                ParseTree arbol = p.Parse(cadenaEntrada);
                padre = arbol;

                for (int i = 0; i < arbol.ParserMessages.Count(); i++)
                {
                    MessageBox.Show(arbol.ParserMessages.ElementAt(i).Level.ToString()+"  Linea: "+arbol.ParserMessages.ElementAt(i).Location.Line+" columna: "+ arbol.ParserMessages.ElementAt(i).Location.Column/**+" "+ arbol.ParserMessages.ElementAt(i).Message.ToString()**/);
                }


                return arbol.Root != null;
            }
            catch (Exception e) {
                MessageBox.Show(e.ToString()); //por errores de programacion en Gramatica.cs
                return false;
            }
           
        }

    }
}
