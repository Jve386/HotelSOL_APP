namespace Prueba1
{
    partial class FrGestionHabitaciones
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
            this.DtVListadoHabitaciones = new System.Windows.Forms.DataGridView();
            this.BtCancelar = new System.Windows.Forms.Button();
            this.BtGrabarHabitacion = new System.Windows.Forms.Button();
            this.BtDeshabilitarHabitacion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtVListadoHabitaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // DtVListadoHabitaciones
            // 
            this.DtVListadoHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtVListadoHabitaciones.Location = new System.Drawing.Point(30, 23);
            this.DtVListadoHabitaciones.Name = "DtVListadoHabitaciones";
            this.DtVListadoHabitaciones.Size = new System.Drawing.Size(1141, 790);
            this.DtVListadoHabitaciones.TabIndex = 0;
            // 
            // BtCancelar
            // 
            this.BtCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtCancelar.Location = new System.Drawing.Point(1272, 742);
            this.BtCancelar.Name = "BtCancelar";
            this.BtCancelar.Size = new System.Drawing.Size(231, 92);
            this.BtCancelar.TabIndex = 2;
            this.BtCancelar.Text = "Cancelar";
            this.BtCancelar.UseVisualStyleBackColor = true;
            // 
            // BtGrabarHabitacion
            // 
            this.BtGrabarHabitacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtGrabarHabitacion.Location = new System.Drawing.Point(1272, 582);
            this.BtGrabarHabitacion.Name = "BtGrabarHabitacion";
            this.BtGrabarHabitacion.Size = new System.Drawing.Size(231, 92);
            this.BtGrabarHabitacion.TabIndex = 3;
            this.BtGrabarHabitacion.Text = "Grabar Habitación";
            this.BtGrabarHabitacion.UseVisualStyleBackColor = false;
            // 
            // BtDeshabilitarHabitacion
            // 
            this.BtDeshabilitarHabitacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtDeshabilitarHabitacion.Location = new System.Drawing.Point(1272, 420);
            this.BtDeshabilitarHabitacion.Name = "BtDeshabilitarHabitacion";
            this.BtDeshabilitarHabitacion.Size = new System.Drawing.Size(231, 92);
            this.BtDeshabilitarHabitacion.TabIndex = 4;
            this.BtDeshabilitarHabitacion.Text = "Deshabilitar Habitación";
            this.BtDeshabilitarHabitacion.UseVisualStyleBackColor = false;
            // 
            // FrGestionHabitaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1572, 860);
            this.Controls.Add(this.BtDeshabilitarHabitacion);
            this.Controls.Add(this.BtGrabarHabitacion);
            this.Controls.Add(this.BtCancelar);
            this.Controls.Add(this.DtVListadoHabitaciones);
            this.Name = "FrGestionHabitaciones";
            this.Text = "FrGestionHabitaciones";
            ((System.ComponentModel.ISupportInitialize)(this.DtVListadoHabitaciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DtVListadoHabitaciones;
        private System.Windows.Forms.Button BtCancelar;
        private System.Windows.Forms.Button BtGrabarHabitacion;
        private System.Windows.Forms.Button BtDeshabilitarHabitacion;
    }
}