namespace Prueba1
{
    partial class FrInicial
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
            this.BtNuevoCliente = new System.Windows.Forms.Button();
            this.BtGestionarReserva = new System.Windows.Forms.Button();
            this.BtCalendario = new System.Windows.Forms.Button();
            this.BtServicioAdicional = new System.Windows.Forms.Button();
            this.BtSalir = new System.Windows.Forms.Button();
            this.BtGenerarFactura = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtNuevoCliente
            // 
            this.BtNuevoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtNuevoCliente.Location = new System.Drawing.Point(267, 112);
            this.BtNuevoCliente.Name = "BtNuevoCliente";
            this.BtNuevoCliente.Size = new System.Drawing.Size(231, 92);
            this.BtNuevoCliente.TabIndex = 1;
            this.BtNuevoCliente.Text = "Nuevo Cliente";
            this.BtNuevoCliente.UseVisualStyleBackColor = true;
            this.BtNuevoCliente.Click += new System.EventHandler(this.BtNuevoCliente_Click);
            // 
            // BtGestionarReserva
            // 
            this.BtGestionarReserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtGestionarReserva.Location = new System.Drawing.Point(267, 267);
            this.BtGestionarReserva.Name = "BtGestionarReserva";
            this.BtGestionarReserva.Size = new System.Drawing.Size(231, 92);
            this.BtGestionarReserva.TabIndex = 4;
            this.BtGestionarReserva.Text = "Gestionar Reserva";
            this.BtGestionarReserva.UseVisualStyleBackColor = true;
            this.BtGestionarReserva.Click += new System.EventHandler(this.BtGestionarReserva_Click);
            // 
            // BtCalendario
            // 
            this.BtCalendario.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtCalendario.Location = new System.Drawing.Point(677, 267);
            this.BtCalendario.Name = "BtCalendario";
            this.BtCalendario.Size = new System.Drawing.Size(231, 92);
            this.BtCalendario.TabIndex = 5;
            this.BtCalendario.Text = "Consultar Calendario";
            this.BtCalendario.UseVisualStyleBackColor = true;
            this.BtCalendario.Click += new System.EventHandler(this.BtCalendario_Click);
            // 
            // BtServicioAdicional
            // 
            this.BtServicioAdicional.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtServicioAdicional.Location = new System.Drawing.Point(267, 420);
            this.BtServicioAdicional.Name = "BtServicioAdicional";
            this.BtServicioAdicional.Size = new System.Drawing.Size(231, 92);
            this.BtServicioAdicional.TabIndex = 6;
            this.BtServicioAdicional.Text = "Servicios Adicionales";
            this.BtServicioAdicional.UseVisualStyleBackColor = true;
            this.BtServicioAdicional.Click += new System.EventHandler(this.BtServicioAdicional_Click);
            // 
            // BtSalir
            // 
            this.BtSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtSalir.Location = new System.Drawing.Point(677, 420);
            this.BtSalir.Name = "BtSalir";
            this.BtSalir.Size = new System.Drawing.Size(231, 92);
            this.BtSalir.TabIndex = 7;
            this.BtSalir.Text = "Salir";
            this.BtSalir.UseVisualStyleBackColor = true;
            this.BtSalir.Click += new System.EventHandler(this.BtSalir_Click);
            // 
            // BtGenerarFactura
            // 
            this.BtGenerarFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtGenerarFactura.Location = new System.Drawing.Point(677, 112);
            this.BtGenerarFactura.Name = "BtGenerarFactura";
            this.BtGenerarFactura.Size = new System.Drawing.Size(231, 92);
            this.BtGenerarFactura.TabIndex = 8;
            this.BtGenerarFactura.Text = "Generar Factura";
            this.BtGenerarFactura.UseVisualStyleBackColor = true;
            // 
            // FrInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 700);
            this.Controls.Add(this.BtGenerarFactura);
            this.Controls.Add(this.BtSalir);
            this.Controls.Add(this.BtServicioAdicional);
            this.Controls.Add(this.BtCalendario);
            this.Controls.Add(this.BtGestionarReserva);
            this.Controls.Add(this.BtNuevoCliente);
            this.Name = "FrInicial";
            this.Text = "FrInicial";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtNuevoCliente;
        private System.Windows.Forms.Button BtGestionarReserva;
        private System.Windows.Forms.Button BtCalendario;
        private System.Windows.Forms.Button BtServicioAdicional;
        private System.Windows.Forms.Button BtSalir;
        private System.Windows.Forms.Button BtGenerarFactura;
    }
}

