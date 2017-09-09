namespace Proyecto_1_201504381
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearProyectoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearClaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1_Proyecto = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1_Clase = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1_Eliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1_UML = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2_Reportes = new System.Windows.Forms.ToolStripButton();
            this.button1_Analizar = new System.Windows.Forms.Button();
            this.osSkin1 = new SkinSoft.OSSkin.OSSkin(this.components);
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.osSkin1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(3323, 49);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.crearProyectoToolStripMenuItem,
            this.crearClaseToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(129, 45);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(328, 46);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // crearProyectoToolStripMenuItem
            // 
            this.crearProyectoToolStripMenuItem.Image = global::Proyecto_1_201504381.Properties.Resources._033_folder;
            this.crearProyectoToolStripMenuItem.Name = "crearProyectoToolStripMenuItem";
            this.crearProyectoToolStripMenuItem.Size = new System.Drawing.Size(328, 46);
            this.crearProyectoToolStripMenuItem.Text = "Crear Proyecto";
            this.crearProyectoToolStripMenuItem.Click += new System.EventHandler(this.crearProyectoToolStripMenuItem_Click);
            // 
            // crearClaseToolStripMenuItem
            // 
            this.crearClaseToolStripMenuItem.Image = global::Proyecto_1_201504381.Properties.Resources._020_file_4;
            this.crearClaseToolStripMenuItem.Name = "crearClaseToolStripMenuItem";
            this.crearClaseToolStripMenuItem.Size = new System.Drawing.Size(328, 46);
            this.crearClaseToolStripMenuItem.Text = "Crear Clase";
            this.crearClaseToolStripMenuItem.Click += new System.EventHandler(this.crearClaseToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::Proyecto_1_201504381.Properties.Resources._039_delete;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(328, 46);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(37, 13);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(643, 1144);
            this.treeView1.TabIndex = 1;
            this.treeView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDoubleClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(700, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(2599, 1144);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            this.tabControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Location = new System.Drawing.Point(5, 161);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(3302, 1160);
            this.panel1.TabIndex = 9;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1_Proyecto,
            this.toolStripButton1_Clase,
            this.toolStripButton1_Eliminar,
            this.toolStripSeparator1,
            this.toolStripButton1_UML,
            this.toolStripSeparator2,
            this.toolStripButton2_Reportes,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 49);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(3323, 47);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1_Proyecto
            // 
            this.toolStripButton1_Proyecto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1_Proyecto.Image = global::Proyecto_1_201504381.Properties.Resources._033_folder;
            this.toolStripButton1_Proyecto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1_Proyecto.Name = "toolStripButton1_Proyecto";
            this.toolStripButton1_Proyecto.Size = new System.Drawing.Size(44, 45);
            this.toolStripButton1_Proyecto.Text = "Crear Proyecto";
            this.toolStripButton1_Proyecto.Click += new System.EventHandler(this.toolStripButton1_Proyecto_Click);
            // 
            // toolStripButton1_Clase
            // 
            this.toolStripButton1_Clase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1_Clase.Image = global::Proyecto_1_201504381.Properties.Resources._020_file_4;
            this.toolStripButton1_Clase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1_Clase.Name = "toolStripButton1_Clase";
            this.toolStripButton1_Clase.Size = new System.Drawing.Size(44, 45);
            this.toolStripButton1_Clase.Text = "Crear Clase";
            this.toolStripButton1_Clase.Click += new System.EventHandler(this.toolStripButton1_Clase_Click);
            // 
            // toolStripButton1_Eliminar
            // 
            this.toolStripButton1_Eliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1_Eliminar.Image = global::Proyecto_1_201504381.Properties.Resources._039_delete;
            this.toolStripButton1_Eliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1_Eliminar.Name = "toolStripButton1_Eliminar";
            this.toolStripButton1_Eliminar.Size = new System.Drawing.Size(44, 45);
            this.toolStripButton1_Eliminar.Text = "Eliminar";
            this.toolStripButton1_Eliminar.Click += new System.EventHandler(this.toolStripButton1_Eliminar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 48);
            // 
            // toolStripButton1_UML
            // 
            this.toolStripButton1_UML.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1_UML.Image = global::Proyecto_1_201504381.Properties.Resources.Class_Models_512;
            this.toolStripButton1_UML.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1_UML.Name = "toolStripButton1_UML";
            this.toolStripButton1_UML.Size = new System.Drawing.Size(44, 45);
            this.toolStripButton1_UML.Text = "Generar UML";
            this.toolStripButton1_UML.Click += new System.EventHandler(this.toolStripButton1_UML_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 48);
            // 
            // toolStripButton2_Reportes
            // 
            this.toolStripButton2_Reportes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2_Reportes.Image = global::Proyecto_1_201504381.Properties.Resources._013_file_5;
            this.toolStripButton2_Reportes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2_Reportes.Name = "toolStripButton2_Reportes";
            this.toolStripButton2_Reportes.Size = new System.Drawing.Size(44, 45);
            this.toolStripButton2_Reportes.Text = "Reporte de Errores";
            this.toolStripButton2_Reportes.Click += new System.EventHandler(this.toolStripButton2_Reportes_Click);
            // 
            // button1_Analizar
            // 
            this.button1_Analizar.Location = new System.Drawing.Point(3089, 1327);
            this.button1_Analizar.Name = "button1_Analizar";
            this.button1_Analizar.Size = new System.Drawing.Size(215, 57);
            this.button1_Analizar.TabIndex = 11;
            this.button1_Analizar.Text = "Analizar";
            this.button1_Analizar.UseVisualStyleBackColor = true;
            this.button1_Analizar.Click += new System.EventHandler(this.button1_Analizar_Click);
            // 
            // osSkin1
            // 
            this.osSkin1.HostForm = null;
            this.osSkin1.License = ((SkinSoft.OSSkin.Licensing.OSSkinLicense)(resources.GetObject("osSkin1.License")));
            this.osSkin1.Style = SkinSoft.OSSkin.SkinStyle.MacOSXAqua;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::Proyecto_1_201504381.Properties.Resources._038_delete_1;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(44, 45);
            this.toolStripButton1.Text = "Cerrar Tabs";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(3323, 1396);
            this.Controls.Add(this.button1_Analizar);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "UML - Proyecto 1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.osSkin1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem crearProyectoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearClaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1_Proyecto;
        private System.Windows.Forms.ToolStripButton toolStripButton1_Clase;
        private System.Windows.Forms.ToolStripButton toolStripButton1_Eliminar;
        private System.Windows.Forms.Button button1_Analizar;
        private SkinSoft.OSSkin.OSSkin osSkin1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1_UML;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton2_Reportes;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

