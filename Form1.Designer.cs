namespace UOC_Conexion_ERP_XML;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        InsertDataButton = new Button();
        TxbNombre = new TextBox();
        label1 = new Label();
        label2 = new Label();
        TxbApellido = new TextBox();
        label3 = new Label();
        TxbApellido2 = new TextBox();
        label4 = new Label();
        TxbPermisos = new TextBox();
        BtnCreateXML = new Button();
        BtnSeleccionarXML = new Button();
        DGridUsuarios = new DataGridView();
        conexionBindingSource = new BindingSource(components);
        BtnCargarUsuarios = new Button();
        ((System.ComponentModel.ISupportInitialize)DGridUsuarios).BeginInit();
        ((System.ComponentModel.ISupportInitialize)conexionBindingSource).BeginInit();
        SuspendLayout();
        // 
        // InsertDataButton
        // 
        InsertDataButton.Location = new Point(217, 33);
        InsertDataButton.Name = "InsertDataButton";
        InsertDataButton.Size = new Size(120, 39);
        InsertDataButton.TabIndex = 0;
        InsertDataButton.Text = "Insert data";
        InsertDataButton.UseVisualStyleBackColor = true;
        InsertDataButton.Click += InsertDataButton_Click;
        // 
        // TxbNombre
        // 
        TxbNombre.Location = new Point(133, 196);
        TxbNombre.Name = "TxbNombre";
        TxbNombre.Size = new Size(263, 23);
        TxbNombre.TabIndex = 1;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
        label1.Location = new Point(12, 187);
        label1.Name = "label1";
        label1.Size = new Size(102, 32);
        label1.TabIndex = 2;
        label1.Text = "Nombre";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
        label2.Location = new Point(12, 232);
        label2.Name = "label2";
        label2.Size = new Size(102, 32);
        label2.TabIndex = 4;
        label2.Text = "Apellido";
        // 
        // TxbApellido
        // 
        TxbApellido.Location = new Point(133, 241);
        TxbApellido.Name = "TxbApellido";
        TxbApellido.Size = new Size(263, 23);
        TxbApellido.TabIndex = 3;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
        label3.Location = new Point(12, 288);
        label3.Name = "label3";
        label3.Size = new Size(115, 32);
        label3.TabIndex = 6;
        label3.Text = "Apellido2";
        // 
        // TxbApellido2
        // 
        TxbApellido2.Location = new Point(133, 297);
        TxbApellido2.Name = "TxbApellido2";
        TxbApellido2.Size = new Size(263, 23);
        TxbApellido2.TabIndex = 5;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
        label4.Location = new Point(12, 342);
        label4.Name = "label4";
        label4.Size = new Size(108, 32);
        label4.TabIndex = 8;
        label4.Text = "Permisos";
        // 
        // TxbPermisos
        // 
        TxbPermisos.Location = new Point(133, 351);
        TxbPermisos.Name = "TxbPermisos";
        TxbPermisos.Size = new Size(263, 23);
        TxbPermisos.TabIndex = 7;
        // 
        // BtnCreateXML
        // 
        BtnCreateXML.Location = new Point(357, 33);
        BtnCreateXML.Name = "BtnCreateXML";
        BtnCreateXML.Size = new Size(109, 39);
        BtnCreateXML.TabIndex = 9;
        BtnCreateXML.Text = "Crear XML";
        BtnCreateXML.UseVisualStyleBackColor = true;
        BtnCreateXML.Click += BtnCreateXML_Click;
        // 
        // BtnSeleccionarXML
        // 
        BtnSeleccionarXML.Location = new Point(51, 33);
        BtnSeleccionarXML.Name = "BtnSeleccionarXML";
        BtnSeleccionarXML.Size = new Size(133, 39);
        BtnSeleccionarXML.TabIndex = 10;
        BtnSeleccionarXML.Text = "Seleccionar XML";
        BtnSeleccionarXML.UseVisualStyleBackColor = true;
        BtnSeleccionarXML.Click += BtnSeleccionarXML_Click;
        // 
        // DGridUsuarios
        // 
        DGridUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        DGridUsuarios.Location = new Point(455, 180);
        DGridUsuarios.Name = "DGridUsuarios";
        DGridUsuarios.RowTemplate.Height = 25;
        DGridUsuarios.Size = new Size(541, 440);
        DGridUsuarios.TabIndex = 11;
        // 
        // conexionBindingSource
        // 
        conexionBindingSource.DataSource = typeof(Conexion);
        // 
        // BtnCargarUsuarios
        // 
        BtnCargarUsuarios.Location = new Point(887, 119);
        BtnCargarUsuarios.Name = "BtnCargarUsuarios";
        BtnCargarUsuarios.Size = new Size(109, 39);
        BtnCargarUsuarios.TabIndex = 12;
        BtnCargarUsuarios.Text = "Cargar Usuarios";
        BtnCargarUsuarios.UseVisualStyleBackColor = true;
        BtnCargarUsuarios.Click += BtnCargarUsuarios_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1019, 639);
        Controls.Add(BtnCargarUsuarios);
        Controls.Add(DGridUsuarios);
        Controls.Add(BtnSeleccionarXML);
        Controls.Add(BtnCreateXML);
        Controls.Add(label4);
        Controls.Add(TxbPermisos);
        Controls.Add(label3);
        Controls.Add(TxbApellido2);
        Controls.Add(label2);
        Controls.Add(TxbApellido);
        Controls.Add(label1);
        Controls.Add(TxbNombre);
        Controls.Add(InsertDataButton);
        Name = "Form1";
        Text = "Form1";
        Load += Form1_Load;
        ((System.ComponentModel.ISupportInitialize)DGridUsuarios).EndInit();
        ((System.ComponentModel.ISupportInitialize)conexionBindingSource).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button InsertDataButton;
    private TextBox TxbNombre;
    private Label label1;
    private Label label2;
    private TextBox TxbApellido;
    private Label label3;
    private TextBox TxbApellido2;
    private Label label4;
    private TextBox TxbPermisos;
    private Button BtnCreateXML;
    private Button BtnSeleccionarXML;
    private DataGridView DGridUsuarios;
    private BindingSource conexionBindingSource;
    private Button BtnCargarUsuarios;
}
