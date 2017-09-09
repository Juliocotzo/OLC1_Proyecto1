using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;
using System.Diagnostics;
using Irony.Parsing;
using System.Collections;

namespace Proyecto_1_201504381
{
    public partial class Form1 : Form
    {
        ParseTree arbol = null;
        Graficas GraficarAST = new Graficas();
        Analizador analizador_T = new Analizador();
        //Path para abrir todos los documentos de treeview
        String Path = @"C:\Users\julio Cotzojay\Documents\USAC\SEGUNDO SEMESTRE 2017\COMPI 1\Archivos De Entrada Proyecto 1 OLC1 - copia";
        String PathTree= @"C:\Users\julio Cotzojay\Documents\USAC\SEGUNDO SEMESTRE 2017\COMPI 1";

        String debug = "";
        String instruccionesNo = "";

        
        Sintactico tmp = new Sintactico();
        ArrayList errores = new ArrayList();
        List<Token> tokens = new List<Token>();
        int x = 1;


        public Form1()
        {
            InitializeComponent();
            ListDirectory(treeView1, Path);

            

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            TabPage tp = new TabPage(openFileDialog1.SafeFileName);
                            tabControl1.TabPages.Add(tp);

                            TextBox tb = new TextBox();
                            tb.Text = File.ReadAllText(openFileDialog1.FileName);
                            tb.Dock = DockStyle.Fill;
                            tb.Multiline = true;

                            tp.Controls.Add(tb);

                            DirectoryInfo parentDir = Directory.GetParent(openFileDialog1.FileName);
                            Path = parentDir.ToString();
                            ListDirectory(treeView1, parentDir.ToString());



                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }*/
            
        }
             
        private void ListDirectory(TreeView treeView, string path)
        {
            //treeView.Nodes.Clear();
            var rootDirectoryInfo = new DirectoryInfo(path);
            treeView.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));

        }

        private static TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);
            foreach (var directory in directoryInfo.GetDirectories())
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));

            foreach (var file in directoryInfo.GetFiles())
                directoryNode.Nodes.Add(new TreeNode(file.Name));

            return directoryNode;
        }
        
        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(treeView1.SelectedNode.FullPath);
            TreeNode node = treeView1.SelectedNode;
            // Set the tree view's PathSeparator property.
            //MessageBox.Show(string.Format(PathTree +"\\"+ treeView1.SelectedNode.FullPath));
            try
            {
                TabPage tp = new TabPage(node.Text);
                tabControl1.TabPages.Add(tp);
                TextBox tb = new TextBox();
                tb.Text = File.ReadAllText(PathTree + "\\" + treeView1.SelectedNode.FullPath);
                tb.Dock = DockStyle.Fill;
                tb.Multiline = true;
                tb.AcceptsTab=true;
                tb.ScrollBars = ScrollBars.Both;
                tp.Controls.Add(tb);
            }
            catch (Exception ea)
            {
                
            }
        }

        private void crearClaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            //MessageBox.Show(string.Format(PathTree + "\\" + treeView1.SelectedNode.FullPath));
            string textoCrear = Microsoft.VisualBasic.Interaction.InputBox("Nombre de la Clase", "Crear Clase", "");
            string path1 = PathTree + "\\" + treeView1.SelectedNode.FullPath+"\\"+textoCrear+".java";
            //MessageBox.Show(path1);
            try
            {
                node.Nodes.Add(textoCrear + ".java");
                StreamWriter File = new StreamWriter(path1);
                File.Write("");
                File.Close();
            }
            catch (Exception)
            {

            }
        }

        private void crearProyectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string texto = Microsoft.VisualBasic.Interaction.InputBox("Nombre del Proyecto", "Crear Proyecto", "");
                if (!Directory.Exists(Path + texto))
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(Path + "\\" + texto);
                    treeView1.Nodes[0].Nodes.Add(texto);
                }
                else
                {
                    MessageBox.Show("La direccion ya existe");
                }
            }
            catch (IOException ioex)
            {
                Console.WriteLine(ioex.Message);
            }    
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            string path = node.FullPath;
            MessageBox.Show(PathTree+"\\"+path);
            try
            {
                FileInfo finfo = new FileInfo(PathTree + "\\" + path);
                if (finfo.Attributes == FileAttributes.Directory)
                {
                    //recursively delete directory
                    Directory.Delete(PathTree + "\\" + path, true);
                    node.Remove();
                }
                else if (finfo.Attributes == FileAttributes.Archive)
                {
                    File.Delete(PathTree + "\\" + path);
                    node.Remove();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Right - 15, e.Bounds.Top + 4);
            e.Graphics.DrawString(this.tabControl1.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 12, e.Bounds.Top + 4);
            e.DrawFocusRectangle();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        
        private void toolStripButton1_Proyecto_Click(object sender, EventArgs e)
        {
            try
            {
                string texto = Microsoft.VisualBasic.Interaction.InputBox("Nombre del Proyecto", "Crear Proyecto", "");
                if (!Directory.Exists(Path + texto))
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(Path + "\\" + texto);
                    treeView1.Nodes[0].Nodes.Add(texto);
                }
                else
                {
                    MessageBox.Show("La direccion ya existe");
                }
            }
            catch (IOException ioex)
            {
                Console.WriteLine(ioex.Message);
            }
        }

        private void toolStripButton1_Clase_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            //MessageBox.Show(string.Format(PathTree + "\\" + treeView1.SelectedNode.FullPath));
            string textoCrear = Microsoft.VisualBasic.Interaction.InputBox("Nombre de la Clase", "Crear Clase", "");
            string path1 = PathTree + "\\" + treeView1.SelectedNode.FullPath + "\\" + textoCrear + ".java";
            //MessageBox.Show(path1);
            try
            {
                node.Nodes.Add(textoCrear + ".java");
                StreamWriter File = new StreamWriter(path1);
                File.Write("");
                File.Close();
            }
            catch (Exception)
            {

            }
        }

        private void toolStripButton1_Eliminar_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            string path = node.FullPath;
            MessageBox.Show(PathTree + "\\" + path);
            try
            {
                FileInfo finfo = new FileInfo(PathTree + "\\" + path);
                if (finfo.Attributes == FileAttributes.Directory)
                {
                    //recursively delete directory
                    Directory.Delete(PathTree + "\\" + path, true);
                    node.Remove();
                }
                else if (finfo.Attributes == FileAttributes.Archive)
                {
                    File.Delete(PathTree + "\\" + path);
                    node.Remove();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < this.tabControl1.TabPages.Count; i++)
            {
                Rectangle r = tabControl1.GetTabRect(i);
                //Getting the position of the "x" mark.
                Rectangle closeButton = new Rectangle(r.Right - 15, r.Top + 4, 9, 7);
                if (closeButton.Contains(e.Location))
                {
                    if (MessageBox.Show("¿Desea Cerrar esta pestaña?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.tabControl1.TabPages.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        private void button1_Analizar_Click(object sender, EventArgs e)
        {
            errores.Clear();
            tokens.Clear();
            tmp.Error.Clear();
            tmp.Tokens.Clear();



            /*int selectedTab = tabControl1.SelectedIndex;
            Control ctrl = tabControl1.Controls[selectedTab].Controls[0];
            TextBox richtext = ctrl as TextBox;

            if (richtext.Text != "")
            {

                Analizador analizarArchibo = new Analizador();

                Gramatica gramatica = new Gramatica();
                Parser parser = new Parser(gramatica);

                String entrada = richtext.Text;
                arbol = parser.Parse(entrada);
                //analizarArchibo.analizar(richtext.Text);

                ParseTreeNode raiz = Sintactico.analizar(tabControl1.SelectedTab.Controls[0].Text);

                if (arbol.Root != null && raiz != null )
                {
                    MessageBox.Show("Analisis completado");

                    //GraficarAST.GraficarArbol(arbol.Root);
                    debug += analizarArchibo.RecorrerAST(arbol.Root);
                    //textBox1.Text = debug+"\n";


                }
                else
                {
                    errores = tmp.Error;
                    MessageBox.Show("Existe error lexico o sintactico");
                    toolStripButton2_Reportes.PerformClick();
                    debug = "";
                    instruccionesNo = "";
                    Analizador.instrucciones.Clear();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un archivo .java para analizar");
            }*/
            try
            {
                for (int i = 0; i < treeView1.SelectedNode.GetNodeCount(true); i++)
                {
                    MessageBox.Show(PathTree + treeView1.SelectedNode.Nodes[i].FullPath);
                    //MessageBox.Show(treeView1.SelectedNode.FullPath);
                    TreeNode node = treeView1.SelectedNode;
                    // Set the tree view's PathSeparator property.
                    //MessageBox.Show(string.Format(PathTree +"\\"+ treeView1.SelectedNode.FullPath));
                    try
                    {
                        TabPage tp = new TabPage(treeView1.SelectedNode.Nodes[i].Text);
                        tabControl1.TabPages.Add(tp);
                        TextBox tb = new TextBox();
                        tb.Text = File.ReadAllText(PathTree + "\\" + treeView1.SelectedNode.Nodes[i].FullPath);
                        tb.Dock = DockStyle.Fill;
                        tb.Multiline = true;
                        tb.AcceptsTab = true;
                        tb.ScrollBars = ScrollBars.Both;
                        tp.Controls.Add(tb);
                    }
                    catch (Exception ea)
                    {

                    }

                }
                for (int i = 0; i < treeView1.SelectedNode.GetNodeCount(true); i++)
                {
                    int selectedTab = i;
                    Control ctrl = tabControl1.Controls[selectedTab].Controls[0];
                    TextBox richtext = ctrl as TextBox;

                    if (richtext.Text != "")
                    {
                        Analizador analizarArchibo = new Analizador();

                        Gramatica gramatica = new Gramatica();
                        Parser parser = new Parser(gramatica);

                        String entrada = richtext.Text;
                        arbol = parser.Parse(entrada);
                        //analizarArchibo.analizar(richtext.Text);

                        ParseTreeNode raiz = Sintactico.analizar(tabControl1.SelectedTab.Controls[0].Text);
                       
                        arbol = parser.Parse(entrada);

                        if (arbol.Root != null && raiz != null)
                        {
                            MessageBox.Show("Analisis completado");
                            debug += analizarArchibo.RecorrerAST(arbol.Root);
                            //GraficarAST.GraficarArbol(arbol.Root);

                        }
                        else
                        {
                            errores = tmp.Error;
                            MessageBox.Show("Existe error lexico o sintactico");
                            toolStripButton2_Reportes.PerformClick();
                            debug = "";
                            instruccionesNo = "";
                            Analizador.instrucciones.Clear();
                            toolStripButton2_Reportes.PerformClick();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Seleccione un archivo .java para analizar");
                    }
                }


            }
            catch
            {

            }


        }

        int no_uml = 0;

        private void toolStripButton1_UML_Click(object sender, EventArgs e)
        {
            GenerarUML G_UML = new GenerarUML();
            ArrayList list2 = new ArrayList();
            list2 = RemoveDuplicate(Analizador.instrucciones);
            foreach (String item in list2)
            {
                instruccionesNo += item + " ";
            }
            debug += instruccionesNo;
            G_UML.Generar_UML(debug,no_uml);
            MessageBox.Show("UML GENERADO CON EXITO");
            try
            {
                TabPage tp = new TabPage("UML"+ no_uml);
                tabControl1.TabPages.Add(tp);
                PictureBox ilabel = new PictureBox(); // create a label
                //ilabel.Image = new System.Drawing.Bitmap("UML.jpg");
                Image i = Image.FromFile("UML"+ no_uml+".jpg"); // read in image
                ilabel.SizeMode = PictureBoxSizeMode.StretchImage;
                ilabel.Size = new Size(970,455); //set label to correct size
                ilabel.Image = i; // put image on label
                this.Controls.Add(ilabel); // add label to container (a form, for instance)

                tp.Controls.Add(ilabel);
                debug = "";
                no_uml++;
                MessageBox.Show(debug);
            }
            
            
            catch (Exception ea)
            {

            }


        }

        private void toolStripButton2_Reportes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("REPORTE DE ERRORES");
            HTML.Errores(errores);
            Process.Start(@"Errores.html");
        }
        

        private static ArrayList RemoveDuplicate(ArrayList sourceList)
        {
            ArrayList list = new ArrayList();
            foreach (string item in sourceList)
            {
                if (!list.Contains(item))
                {
                    list.Add(item);
                }
            }
            return list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < this.tabControl1.TabCount; i++)
                    if (i == tabControl1.SelectedIndex)
                        tabControl1.TabPages.RemoveAt(i--);
                debug = "";
            }
            catch
            {

            }
        }
    }
}
