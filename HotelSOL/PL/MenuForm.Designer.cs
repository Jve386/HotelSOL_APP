namespace HotelSOL.PL
{
    partial class MenuForm
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
            this.txt_accesoOK = new System.Windows.Forms.Label();
            this.XML = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_accesoOK
            // 
            this.txt_accesoOK.AutoSize = true;
            this.txt_accesoOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_accesoOK.Location = new System.Drawing.Point(151, 85);
            this.txt_accesoOK.Name = "txt_accesoOK";
            this.txt_accesoOK.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_accesoOK.Size = new System.Drawing.Size(529, 69);
            this.txt_accesoOK.TabIndex = 0;
            this.txt_accesoOK.Text = "Acceso concedido";
            this.txt_accesoOK.Click += new System.EventHandler(this.label1_Click);
            // 
            // XML
            // 
            this.XML.Location = new System.Drawing.Point(163, 183);
            this.XML.Name = "XML";
            this.XML.Size = new System.Drawing.Size(166, 42);
            this.XML.TabIndex = 1;
            this.XML.Text = "XML";
            this.XML.UseVisualStyleBackColor = true;
            this.XML.Click += new System.EventHandler(this.button1_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.XML);
            this.Controls.Add(this.txt_accesoOK);
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txt_accesoOK;
        private System.Windows.Forms.Button XML;
    }
}