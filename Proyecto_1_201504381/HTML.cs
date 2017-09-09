
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1_201504381
{
    class HTML
    {
        public static void Errores(ArrayList errores)//Parametro ArrayList errores
        {
            string archivo = "Errores.html";
            int num = 1;
            StreamWriter file = new StreamWriter(archivo);
            file.WriteLine("<!DOCTYPE html>");
            file.WriteLine("<html lang=\"en\" class=\"no-js\">");
            file.WriteLine("<head>");
            file.WriteLine("    <meta charset=\"UTF-8\" />");
            file.WriteLine("    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge,chrome=1\">");
            file.WriteLine("    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
            file.WriteLine("    <title>ERRORES</title>");
            file.WriteLine("    <meta name=\"description\" content=\"Sticky Table Headers Revisited: Creating functional and flexible sticky table headers\" />");
            file.WriteLine("    <meta name=\"keywords\" content=\"Sticky Table Headers Revisited\" />");
            file.WriteLine("    <meta name=\"author\" content=\"Codrops\" />");
            file.WriteLine("    <link rel=\"shortcut icon\" href=\"../favicon.ico\">");
            file.WriteLine("    <link rel=\"stylesheet\" type=\"text/css\" href=\"css/normalize.css\" />");
            file.WriteLine("    <link rel=\"stylesheet\" type=\"text/css\" href=\"css/demo.css\" />");
            file.WriteLine("    <link rel=\"stylesheet\" type=\"text/css\" href=\"css/component.css\" />");
            file.WriteLine("    <!--[if IE]> ");
            file.WriteLine("    <script src=\"http://html5shiv.googlecode.com/svn/trunk/html5.js\"></script>");
            file.WriteLine("    <![endif]--> ");
            file.WriteLine("</head>");
            file.WriteLine("<body>");
            file.WriteLine("    <div class=\"container\">");
            file.WriteLine("        <!-- Top Navigation -->");
            file.WriteLine("");
            file.WriteLine("        <header>");
            file.WriteLine("            <h1>ERRORES</h1>");
            file.WriteLine("");
            file.WriteLine("        </header>");
            file.WriteLine("        <div class=\"component\">");
            file.WriteLine("            <table>");
            file.WriteLine("                <thead>");
            file.WriteLine("                    <tr>");
            file.WriteLine("                        <th>No.</th>");
            file.WriteLine("                        <th>Fila</th>");
            file.WriteLine("                        <th>Columna</th>");
            file.WriteLine("                        <th>Tipo</th>");
            file.WriteLine("                        <th>Descripcion</th>");
            file.WriteLine("                    </tr>");
            file.WriteLine("                </thead>");
            file.WriteLine("                <tbody>");

            
            foreach (Errores e in errores)
            {
                file.WriteLine("<tr>");
                file.WriteLine(("<td class=\"text-left\">" + num + "</td>"));
                num++;

                file.WriteLine(("<td class=\"text-left\">" + e._line.ToString() + "</td>"));
                file.WriteLine(("<td class=\"text-left\">" + e._col.ToString() + "</td>"));
                file.WriteLine(("<td class=\"text-left\">" + e._type.ToString() + "</td>"));
                file.WriteLine(("<td class=\"text-left\">" + e._desc.ToString() + "</td>"));
                file.WriteLine("</tr>");
            }


            file.WriteLine("                </tbody> ");
            file.WriteLine("            </table> ");
            file.WriteLine("        </div> ");
            file.WriteLine("    </div><!-- /container --> ");
            file.WriteLine("    <script src=\"http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js\"></script> ");
            file.WriteLine("    <script src=\"http://cdnjs.cloudflare.com/ajax/libs/jquery-throttle-debounce/1.1/jquery.ba-throttle-debounce.min.js\"></script> ");
            file.WriteLine("    <script src=\"js/jquery.stickyheader.js\"></script> ");
            file.WriteLine("</body> ");
            file.WriteLine("</html> ");

            file.Close();
        }
    }
}
