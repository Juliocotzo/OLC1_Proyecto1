﻿using System;
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

namespace Proyecto_1_201504381
{
    public partial class Form1 : Form
    {
        ParseTree arbol = null;
        Graficas GraficarAST = new Graficas();
        //Path para abrir todos los documentos de treeview
        String Path = @"C:\Users\julio Cotzojay\Documents\USAC\SEGUNDO SEMESTRE 2017\COMPI 1\Archivos De Entrada Proyecto 1 OLC1 - copia";
        String PathTree= @"C:\Users\julio Cotzojay\Documents\USAC\SEGUNDO SEMESTRE 2017\COMPI 1";
        
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
            int selectedTab = tabControl1.SelectedIndex;
            Control ctrl = tabControl1.Controls[selectedTab].Controls[0];
            TextBox richtext = ctrl as TextBox;

            if (richtext.Text != "")
            {

                Gramatica gramatica = new Gramatica();
                Parser parser = new Parser(gramatica);

                String entrada = richtext.Text;
                arbol = parser.Parse(entrada);

                if (arbol.Root != null)
                {
                    MessageBox.Show("Analisis completado");
                    GraficarAST.GraficarArbol(arbol.Root);

                }
                else
                {
                    MessageBox.Show("Existe error lexico o sintactico");
                    toolStripButton2_Reportes.PerformClick();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un archivo .java para analizar");
            }

           
        }

        private void toolStripButton1_UML_Click(object sender, EventArgs e)
        {
            MessageBox.Show("UML GENERADO CON EXITO");
        }

        private void toolStripButton2_Reportes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("REPORTE DE ERRORES");
        }
    }
}
