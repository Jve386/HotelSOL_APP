namespace Prueba1
{
    partial class FrGenerarFactura
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
            this.BtGenerarFactura = new System.Windows.Forms.Button();
            this.LbReserva = new System.Windows.Forms.Label();
            this.TxNumReserva = new System.Windows.Forms.TextBox();
            this.DTGVisualizarFactura = new System.Windows.Forms.DataGridView();
            this.BtModificarDatos = new System.Windows.Forms.Button();
            this.BtEnviarFactura = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DTGVisualizarFactura)).BeginInit();
            this.SuspendLayout();
            // 
            // BtGenerarFactura
            // 
            this.BtGenerarFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtGenerarFactura.Location = new System.Drawing.Point(885, 140);
            this.BtGenerarFactura.Name = "BtGenerarFactura";
            this.BtGenerarFactura.Size = new System.Drawing.Size(200, 100);
            this.BtGenerarFactura.TabIndex = 15;
            this.BtGenerarFactura.Text = "Generar Factura";
            this.BtGenerarFactura.UseVisualStyleBackColor = true;
            // 
            // LbReserva
            // 
            this.LbReserva.AutoSize = true;
            this.LbReserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbReserva.Location = new System.Drawing.Point(330, 140);
            this.LbReserva.Name = "LbReserva";
            this.LbReserva.Size = new System.Drawing.Size(257, 37);
            this.LbReserva.TabIndex = 14;
            this.LbReserva.Text = "Numero Reserva";
            // 
            // TxNumReserva
            // 
            this.TxNumReserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxNumReserva.Location = new System.Drawing.Point(606, 140);
            this.TxNumReserva.Name = "TxNumReserva";
            this.TxNumReserva.Size = new System.Drawing.Size(189, 44);
            this.TxNumReserva.TabIndex = 13;
            // 
            // DTGVisualizarFactura
            // 
            this.DTGVisualizarFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGVisualizarFactura.Location = new System.Drawing.Point(316, 304);
            this.DTGVisualizarFactura.Name = "DTGVisualizarFactura";
            this.DTGVisualizarFactura.Size = new System.Drawing.Size(748, 445);
            this.DTGVisualizarFactura.TabIndex = 16;
            this.DTGVisualizarFactura.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DTGVisualizarFactura_CellContentClick);
            // 
            // BtModificarDatos
            // 
            this.BtModificarDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtModificarDatos.Location = new System.Drawing.Point(1120, 140);
            this.BtModificarDatos.Name = "BtModificarDatos";
            this.BtModificarDatos.Size = new System.Drawing.Size(252, 100);
            this.BtModificarDatos.TabIndex = 17;
            this.BtModificarDatos.Text = "Modificar Datos";
            this.BtModificarDatos.UseVisualStyleBackColor = true;
            // 
            // BtEnviarFactura
            // 
            this.BtEnviarFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtEnviarFactura.Location = new System.Drawing.Point(1120, 304);
            this.BtEnviarFactura.Name = "BtEnviarFactura";
            this.BtEnviarFactura.Size = new System.Drawing.Size(252, 100);
            this.BtEnviarFactura.TabIndex = 18;
            this.BtEnviarFactura.Text = "Enviar Factura";
            this.BtEnviarFactura.UseVisualStyleBackColor = true;
            // 
            // FrGenerarFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1494, 870);
            this.Controls.Add(this.BtEnviarFactura);
            this.Controls.Add(this.BtModificarDatos);
            this.Controls.Add(this.DTGVisualizarFactura);
            this.Controls.Add(this.BtGenerarFactura);
            this.Controls.Add(this.LbReserva);
            this.Controls.Add(this.TxNumReserva);
            this.Name = "FrGenerarFactura";
            this.Text = "FrGenerarFactura";
            ((System.ComponentModel.ISupportInitialize)(this.DTGVisualizarFactura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtGenerarFactura;
        private System.Windows.Forms.Label LbReserva;
        private System.Windows.Forms.TextBox TxNumReserva;
        private System.Windows.Forms.DataGridView DTGVisualizarFactura;
        private System.Windows.Forms.Button BtModificarDatos;
        private System.Windows.Forms.Button BtEnviarFactura;
    }
}