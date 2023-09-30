namespace P222310546TM
{
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
            btnColor = new Button();
            btnSalir = new Button();
            cbDireccion = new ComboBox();
            label1 = new Label();
            numNivel = new NumericUpDown();
            btnDibujar = new Button();
            lblTitulo = new Label();
            pbFractal = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            btnSkip = new Button();
            trackVelocidad = new TrackBar();
            lblVelocidad = new Label();
            ((System.ComponentModel.ISupportInitialize)numNivel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFractal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackVelocidad).BeginInit();
            SuspendLayout();
            // 
            // btnColor
            // 
            btnColor.BackColor = Color.LightGray;
            btnColor.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnColor.Location = new Point(12, 12);
            btnColor.Name = "btnColor";
            btnColor.Size = new Size(130, 47);
            btnColor.TabIndex = 0;
            btnColor.Text = "Color";
            btnColor.UseVisualStyleBackColor = false;
            btnColor.Click += btnColor_Click;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.None;
            btnSalir.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnSalir.Location = new Point(427, 605);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(130, 47);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // cbDireccion
            // 
            cbDireccion.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDireccion.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            cbDireccion.FormattingEnabled = true;
            cbDireccion.Items.AddRange(new object[] { "Triángulo Arriba", "Triángulo Abajo" });
            cbDireccion.Location = new Point(148, 20);
            cbDireccion.Name = "cbDireccion";
            cbDireccion.Size = new Size(226, 34);
            cbDireccion.TabIndex = 2;
            cbDireccion.SelectedIndexChanged += cbDireccion_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(380, 23);
            label1.Name = "label1";
            label1.Size = new Size(65, 26);
            label1.TabIndex = 3;
            label1.Text = "Nivel";
            // 
            // numNivel
            // 
            numNivel.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            numNivel.Location = new Point(451, 19);
            numNivel.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numNivel.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numNivel.Name = "numNivel";
            numNivel.ReadOnly = true;
            numNivel.Size = new Size(60, 35);
            numNivel.TabIndex = 4;
            numNivel.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnDibujar
            // 
            btnDibujar.Enabled = false;
            btnDibujar.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnDibujar.Location = new Point(914, 12);
            btnDibujar.Name = "btnDibujar";
            btnDibujar.Size = new Size(127, 47);
            btnDibujar.TabIndex = 5;
            btnDibujar.Text = "Dibujar";
            btnDibujar.UseVisualStyleBackColor = true;
            btnDibujar.Click += btnDibujar_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Times New Roman", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.Location = new Point(517, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(425, 36);
            lblTitulo.TabIndex = 7;
            lblTitulo.Text = "FRACTALES TRIÁNGULOS";
            // 
            // pbFractal
            // 
            pbFractal.Enabled = false;
            pbFractal.Location = new Point(12, 65);
            pbFractal.Name = "pbFractal";
            pbFractal.Size = new Size(1029, 534);
            pbFractal.TabIndex = 8;
            pbFractal.TabStop = false;
            // 
            // btnSkip
            // 
            btnSkip.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnSkip.Location = new Point(12, 605);
            btnSkip.Name = "btnSkip";
            btnSkip.Size = new Size(246, 47);
            btnSkip.TabIndex = 9;
            btnSkip.Text = "Acelerar Animacion";
            btnSkip.UseVisualStyleBackColor = true;
            btnSkip.Click += btnSkip_Click;
            // 
            // trackVelocidad
            // 
            trackVelocidad.Location = new Point(819, 605);
            trackVelocidad.Minimum = 1;
            trackVelocidad.Name = "trackVelocidad";
            trackVelocidad.Size = new Size(156, 69);
            trackVelocidad.TabIndex = 10;
            trackVelocidad.Value = 1;
            trackVelocidad.Scroll += trackVelocidad_Scroll;
            // 
            // lblVelocidad
            // 
            lblVelocidad.AutoSize = true;
            lblVelocidad.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblVelocidad.Location = new Point(657, 615);
            lblVelocidad.Name = "lblVelocidad";
            lblVelocidad.Size = new Size(139, 26);
            lblVelocidad.TabIndex = 11;
            lblVelocidad.Text = "Velocidad: 1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1053, 664);
            ControlBox = false;
            Controls.Add(lblVelocidad);
            Controls.Add(trackVelocidad);
            Controls.Add(btnSkip);
            Controls.Add(pbFractal);
            Controls.Add(lblTitulo);
            Controls.Add(btnDibujar);
            Controls.Add(numNivel);
            Controls.Add(label1);
            Controls.Add(cbDireccion);
            Controls.Add(btnSalir);
            Controls.Add(btnColor);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Fractal Triángulo";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numNivel).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFractal).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackVelocidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnColor;
        private Button btnSalir;
        private ComboBox cbDireccion;
        private Label label1;
        private NumericUpDown numNivel;
        private Button btnDibujar;
        private Label lblTitulo;
        private PictureBox pbFractal;
        private System.Windows.Forms.Timer timer1;
        private Button btnSkip;
        private TrackBar trackVelocidad;
        private Label lblVelocidad;
    }
}