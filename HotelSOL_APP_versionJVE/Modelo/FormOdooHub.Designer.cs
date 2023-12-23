namespace Modelo
{
    partial class FormOdooHub
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnExportarOdoo = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.btnXML = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExportarOdoo
            // 
            this.btnExportarOdoo.Location = new System.Drawing.Point(345, 110);
            this.btnExportarOdoo.Name = "btnExportarOdoo";
            this.btnExportarOdoo.Size = new System.Drawing.Size(125, 23);
            this.btnExportarOdoo.TabIndex = 1;
            this.btnExportarOdoo.Text = "Exportar a Odoo";
            this.btnExportarOdoo.UseVisualStyleBackColor = true;
            this.btnExportarOdoo.Click += new System.EventHandler(this.btnExportarOdoo_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Clientes",
            "Habitaciones",
            "Reservas ",
            "Usuarios"});
            this.checkedListBox1.Location = new System.Drawing.Point(66, 65);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(233, 154);
            this.checkedListBox1.TabIndex = 2;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // btnXML
            // 
            this.btnXML.Location = new System.Drawing.Point(345, 65);
            this.btnXML.Name = "btnXML";
            this.btnXML.Size = new System.Drawing.Size(125, 23);
            this.btnXML.TabIndex = 3;
            this.btnXML.Text = "Generar XML";
            this.btnXML.UseVisualStyleBackColor = true;
            this.btnXML.Click += new System.EventHandler(this.btnXML_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(66, 266);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(493, 257);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // FormOdooHub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 547);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnXML);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.btnExportarOdoo);
            this.Name = "FormOdooHub";
            this.Text = "FormOdooHub";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnExportarOdoo;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button btnXML;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}