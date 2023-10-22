namespace Prueba1
{
    partial class FrServiciosAdicionales
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
            this.BtModificarServicio = new System.Windows.Forms.Button();
            this.BtGrabarOperacion = new System.Windows.Forms.Button();
            this.DtGServicios = new System.Windows.Forms.DataGridView();
            this.BtContratarServicio = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtGServicios)).BeginInit();
            this.SuspendLayout();
            // 
            // BtModificarServicio
            // 
            this.BtModificarServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtModificarServicio.Location = new System.Drawing.Point(849, 212);
            this.BtModificarServicio.Name = "BtModificarServicio";
            this.BtModificarServicio.Size = new System.Drawing.Size(180, 92);
            this.BtModificarServicio.TabIndex = 31;
            this.BtModificarServicio.Text = "Modificar Servicio";
            this.BtModificarServicio.UseVisualStyleBackColor = true;
            // 
            // BtGrabarOperacion
            // 
            this.BtGrabarOperacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtGrabarOperacion.Location = new System.Drawing.Point(849, 348);
            this.BtGrabarOperacion.Name = "BtGrabarOperacion";
            this.BtGrabarOperacion.Size = new System.Drawing.Size(180, 92);
            this.BtGrabarOperacion.TabIndex = 32;
            this.BtGrabarOperacion.Text = "Grabar Operacion";
            this.BtGrabarOperacion.UseVisualStyleBackColor = true;
            // 
            // DtGServicios
            // 
            this.DtGServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtGServicios.Location = new System.Drawing.Point(38, 43);
            this.DtGServicios.Name = "DtGServicios";
            this.DtGServicios.Size = new System.Drawing.Size(746, 332);
            this.DtGServicios.TabIndex = 33;
            // 
            // BtContratarServicio
            // 
            this.BtContratarServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtContratarServicio.Location = new System.Drawing.Point(849, 79);
            this.BtContratarServicio.Name = "BtContratarServicio";
            this.BtContratarServicio.Size = new System.Drawing.Size(180, 92);
            this.BtContratarServicio.TabIndex = 34;
            this.BtContratarServicio.Text = "Contratar Servicio";
            this.BtContratarServicio.UseVisualStyleBackColor = true;
            // 
            // FrServiciosAdicionales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 656);
            this.Controls.Add(this.BtContratarServicio);
            this.Controls.Add(this.DtGServicios);
            this.Controls.Add(this.BtGrabarOperacion);
            this.Controls.Add(this.BtModificarServicio);
            this.Name = "FrServiciosAdicionales";
            this.Text = "FrServiciosAdicionales";
            ((System.ComponentModel.ISupportInitialize)(this.DtGServicios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtModificarServicio;
        private System.Windows.Forms.Button BtGrabarOperacion;
        private System.Windows.Forms.DataGridView DtGServicios;
        private System.Windows.Forms.Button BtContratarServicio;
    }
}