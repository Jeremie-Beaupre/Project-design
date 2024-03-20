namespace GUI_Arduino
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tareButton = new System.Windows.Forms.Button();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.calibreButton = new System.Windows.Forms.Button();
            this.mainTextBox = new System.Windows.Forms.TextBox();
            this.peseButton = new System.Windows.Forms.Button();
            this.comboBoxPort = new System.Windows.Forms.ComboBox();
            this.checkBoxMenuExpert = new System.Windows.Forms.CheckBox();
            this.groupBoxMenuExpert = new System.Windows.Forms.GroupBox();
            this.buttonApliquer = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxKd = new System.Windows.Forms.TextBox();
            this.textBoxKi = new System.Windows.Forms.TextBox();
            this.textBoxKp = new System.Windows.Forms.TextBox();
            this.buttonActualiser = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBoxMenuExpert.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tareButton
            // 
            this.tareButton.ForeColor = System.Drawing.Color.Black;
            this.tareButton.Location = new System.Drawing.Point(283, 225);
            this.tareButton.Name = "tareButton";
            this.tareButton.Size = new System.Drawing.Size(110, 32);
            this.tareButton.TabIndex = 0;
            this.tareButton.Text = "Tarage";
            this.tareButton.UseVisualStyleBackColor = true;
            this.tareButton.Click += new System.EventHandler(this.tareButton_Click);
            // 
            // serialPort
            // 
            this.serialPort.PortName = "COM3";
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // calibreButton
            // 
            this.calibreButton.ForeColor = System.Drawing.Color.Black;
            this.calibreButton.Location = new System.Drawing.Point(167, 225);
            this.calibreButton.Name = "calibreButton";
            this.calibreButton.Size = new System.Drawing.Size(110, 32);
            this.calibreButton.TabIndex = 1;
            this.calibreButton.Text = "Étalonner";
            this.calibreButton.UseVisualStyleBackColor = true;
            this.calibreButton.Click += new System.EventHandler(this.calibreButton_Click);
            // 
            // mainTextBox
            // 
            this.mainTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.mainTextBox.Enabled = false;
            this.mainTextBox.Font = new System.Drawing.Font("Digital-7 Mono", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainTextBox.Location = new System.Drawing.Point(167, 145);
            this.mainTextBox.MaximumSize = new System.Drawing.Size(400, 400);
            this.mainTextBox.Multiline = true;
            this.mainTextBox.Name = "mainTextBox";
            this.mainTextBox.ReadOnly = true;
            this.mainTextBox.Size = new System.Drawing.Size(226, 57);
            this.mainTextBox.TabIndex = 2;
            this.mainTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // peseButton
            // 
            this.peseButton.ForeColor = System.Drawing.Color.Black;
            this.peseButton.Location = new System.Drawing.Point(399, 225);
            this.peseButton.Name = "peseButton";
            this.peseButton.Size = new System.Drawing.Size(110, 32);
            this.peseButton.TabIndex = 3;
            this.peseButton.Text = "Pesée";
            this.peseButton.UseVisualStyleBackColor = true;
            // 
            // comboBoxPort
            // 
            this.comboBoxPort.ForeColor = System.Drawing.Color.Black;
            this.comboBoxPort.FormattingEnabled = true;
            this.comboBoxPort.Location = new System.Drawing.Point(8, 22);
            this.comboBoxPort.Name = "comboBoxPort";
            this.comboBoxPort.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPort.TabIndex = 4;
            this.comboBoxPort.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // checkBoxMenuExpert
            // 
            this.checkBoxMenuExpert.AutoSize = true;
            this.checkBoxMenuExpert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxMenuExpert.Location = new System.Drawing.Point(150, 17);
            this.checkBoxMenuExpert.Name = "checkBoxMenuExpert";
            this.checkBoxMenuExpert.Size = new System.Drawing.Size(96, 17);
            this.checkBoxMenuExpert.TabIndex = 5;
            this.checkBoxMenuExpert.Text = "Menu expert";
            this.checkBoxMenuExpert.UseVisualStyleBackColor = true;
            this.checkBoxMenuExpert.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBoxMenuExpert
            // 
            this.groupBoxMenuExpert.Controls.Add(this.buttonApliquer);
            this.groupBoxMenuExpert.Controls.Add(this.label3);
            this.groupBoxMenuExpert.Controls.Add(this.label2);
            this.groupBoxMenuExpert.Controls.Add(this.label1);
            this.groupBoxMenuExpert.Controls.Add(this.textBoxKd);
            this.groupBoxMenuExpert.Controls.Add(this.textBoxKi);
            this.groupBoxMenuExpert.Controls.Add(this.textBoxKp);
            this.groupBoxMenuExpert.Controls.Add(this.buttonActualiser);
            this.groupBoxMenuExpert.Location = new System.Drawing.Point(180, 450);
            this.groupBoxMenuExpert.Name = "groupBoxMenuExpert";
            this.groupBoxMenuExpert.Size = new System.Drawing.Size(325, 100);
            this.groupBoxMenuExpert.TabIndex = 6;
            this.groupBoxMenuExpert.TabStop = false;
            this.groupBoxMenuExpert.Text = "Configuration PID";
            this.groupBoxMenuExpert.Visible = false;
            // 
            // buttonApliquer
            // 
            this.buttonApliquer.ForeColor = System.Drawing.Color.Black;
            this.buttonApliquer.Location = new System.Drawing.Point(180, 71);
            this.buttonApliquer.Name = "buttonApliquer";
            this.buttonApliquer.Size = new System.Drawing.Size(100, 23);
            this.buttonApliquer.TabIndex = 8;
            this.buttonApliquer.Text = "Apliquer";
            this.buttonApliquer.UseVisualStyleBackColor = true;
            this.buttonApliquer.Click += new System.EventHandler(this.buttonApliquer_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(261, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "kd";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "ki";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "kp";
            // 
            // textBoxKd
            // 
            this.textBoxKd.Location = new System.Drawing.Point(218, 45);
            this.textBoxKd.Name = "textBoxKd";
            this.textBoxKd.Size = new System.Drawing.Size(100, 20);
            this.textBoxKd.TabIndex = 3;
            // 
            // textBoxKi
            // 
            this.textBoxKi.Location = new System.Drawing.Point(112, 45);
            this.textBoxKi.Name = "textBoxKi";
            this.textBoxKi.Size = new System.Drawing.Size(100, 20);
            this.textBoxKi.TabIndex = 2;
            // 
            // textBoxKp
            // 
            this.textBoxKp.Location = new System.Drawing.Point(6, 45);
            this.textBoxKp.MaxLength = 7;
            this.textBoxKp.Name = "textBoxKp";
            this.textBoxKp.Size = new System.Drawing.Size(100, 20);
            this.textBoxKp.TabIndex = 1;
            // 
            // buttonActualiser
            // 
            this.buttonActualiser.ForeColor = System.Drawing.Color.Black;
            this.buttonActualiser.Location = new System.Drawing.Point(50, 71);
            this.buttonActualiser.Name = "buttonActualiser";
            this.buttonActualiser.Size = new System.Drawing.Size(100, 23);
            this.buttonActualiser.TabIndex = 0;
            this.buttonActualiser.Text = "Actualiser";
            this.buttonActualiser.UseVisualStyleBackColor = true;
            this.buttonActualiser.Click += new System.EventHandler(this.buttonActualiser_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.comboBoxPort);
            this.panel1.Controls.Add(this.checkBoxMenuExpert);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(700, 50);
            this.panel1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Port Série";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Digital-7 Mono", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "g",
            "oz",
            "slug"});
            this.comboBox1.Location = new System.Drawing.Point(398, 145);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(111, 57);
            this.comboBox1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(700, 700);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBoxMenuExpert);
            this.Controls.Add(this.peseButton);
            this.Controls.Add(this.mainTextBox);
            this.Controls.Add(this.tareButton);
            this.Controls.Add(this.calibreButton);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxMenuExpert.ResumeLayout(false);
            this.groupBoxMenuExpert.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button tareButton;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Button calibreButton;
        private System.Windows.Forms.TextBox mainTextBox;
        private System.Windows.Forms.Button peseButton;
        private System.Windows.Forms.ComboBox comboBoxPort;
        private System.Windows.Forms.CheckBox checkBoxMenuExpert;
        private System.Windows.Forms.GroupBox groupBoxMenuExpert;
        private System.Windows.Forms.Button buttonActualiser;
        private System.Windows.Forms.TextBox textBoxKp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxKd;
        private System.Windows.Forms.TextBox textBoxKi;
        private System.Windows.Forms.Button buttonApliquer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

