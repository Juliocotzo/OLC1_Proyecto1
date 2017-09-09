using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace Proyecto_1_201504381
{
    class Graficas
    {
        public void GraficarArbol(ParseTreeNode root)
        {
            try
            {
                String grafica = "Digraph Arbol_Sintactico{\n\n" + GraficaNodos(root, "0") + "\n\n}";
                FileStream stream = new FileStream("Arbol.dot", FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(stream);
                writer.WriteLine(grafica);
                writer.Close();
                //Ejecuta el codigo
                var command = string.Format("dot -Tjpg Arbol.dot -o Arbol.jpg");
                var procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/C " + command);
                var proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                proc.WaitForExit();

                Thread.Sleep(2000);
                Process.Start(@"Arbol.jpg");
            }
            catch (Exception x)
            {
                MessageBox.Show("Error inesperado cuando se intento graficar: " + x.ToString(), "error");
            }
        }

        private String GraficaNodos(ParseTreeNode nodo, String i)
        {
            int k = 0;
            String r = "";
            String nodoTerm = nodo.Term.ToString();
            nodoTerm = nodoTerm.Replace("\"", "");
            nodoTerm = nodoTerm.Replace("\\", "\\\\");
            r = "node" + i + "[label = \"" + nodoTerm + "\"];\n";

            for (int j = 0; j <= nodo.ChildNodes.Count() - 1; j++)
            {  // Nodos padres
                r = r + "node" + i + " -> node" + i + k + "\n";
                r = r + GraficaNodos(nodo.ChildNodes[j], "" + i + k);
                k++;
            }

            if (nodo.Token != null)
            {
                String nodoToken = nodo.Token.Text;
                nodoToken = nodoToken.Replace("\"", "");
                nodoToken = nodoToken.Replace("\\", "\\\\");
                if (nodo.ChildNodes.Count() == 0 && nodoTerm != nodoToken)
                {  // Nodos Hojas
                    r += "node" + i + "c[label = \"" + nodoToken + "\"];\n";
                    r += "node" + i + " -> node" + i + "c\n";
                }
            }

            return r;
        }

    }
}
