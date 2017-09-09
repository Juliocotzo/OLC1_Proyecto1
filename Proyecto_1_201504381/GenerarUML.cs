using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_1_201504381
{
    class GenerarUML
    {

        public void Generar_UML(string uml,int no_uml)
        {
            try
            {
                Analizador analiza = new Analizador();
                String grafica = "Digraph UML{\nsize=\"50,50\"\nnode[shape=record,style=filled,fillcolor=gray95]\nedge[dir=back, arrowtail=empty]\n\n" + uml  +"\n\n}";
                FileStream stream = new FileStream("UML"+no_uml+".dot", FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(stream);
                writer.WriteLine(grafica);
                writer.Close();
                //Ejecuta el codigo
                var command = string.Format("dot -Tjpg UML"+no_uml+ ".dot -o UML" + no_uml + ".jpg");
                var procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/C " + command);
                var proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                proc.WaitForExit();

                //Thread.Sleep(2000);
                //Process.Start(@"UML.jpg");
            }
            catch (Exception x)
            {
                MessageBox.Show("Error inesperado cuando se intento graficar: " + x.ToString(), "error");
            }
        }
    }
}
