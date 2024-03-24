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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.fermerbutton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comptagecomboBox = new System.Windows.Forms.ComboBox();
            this.massecomboBox = new System.Windows.Forms.ComboBox();
            this.comptagebutton = new System.Windows.Forms.Button();
            this.comptagetextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.modecomptagelabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.indicationlabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.indicatorpanel = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timerStable = new System.Windows.Forms.Timer(this.components);
            this.tmesure = new System.Windows.Forms.Label();
            this.calibragebutton = new System.Windows.Forms.Button();
            this.groupBoxMenuExpert.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tareButton
            // 
            this.tareButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tareButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.tareButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            resources.ApplyResources(this.tareButton, "tareButton");
            this.tareButton.ForeColor = System.Drawing.Color.White;
            this.tareButton.Name = "tareButton";
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
            this.calibreButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.calibreButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.calibreButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            resources.ApplyResources(this.calibreButton, "calibreButton");
            this.calibreButton.ForeColor = System.Drawing.Color.White;
            this.calibreButton.Name = "calibreButton";
            this.calibreButton.UseVisualStyleBackColor = true;
            this.calibreButton.Click += new System.EventHandler(this.calibreButton_Click);
            // 
            // mainTextBox
            // 
            this.mainTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            resources.ApplyResources(this.mainTextBox, "mainTextBox");
            this.mainTextBox.ForeColor = System.Drawing.Color.White;
            this.mainTextBox.Name = "mainTextBox";
            this.mainTextBox.ReadOnly = true;
            this.mainTextBox.Enter += new System.EventHandler(this.mainTextBox_Enter);
            // 
            // peseButton
            // 
            this.peseButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.peseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.peseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            resources.ApplyResources(this.peseButton, "peseButton");
            this.peseButton.ForeColor = System.Drawing.Color.White;
            this.peseButton.Name = "peseButton";
            this.peseButton.UseVisualStyleBackColor = true;
            this.peseButton.Click += new System.EventHandler(this.peseButton_Click);
            // 
            // comboBoxPort
            // 
            this.comboBoxPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPort.ForeColor = System.Drawing.Color.Black;
            this.comboBoxPort.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxPort, "comboBoxPort");
            this.comboBoxPort.Name = "comboBoxPort";
            this.comboBoxPort.DropDown += new System.EventHandler(this.comboBoxPort_DropDown);
            this.comboBoxPort.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // checkBoxMenuExpert
            // 
            resources.ApplyResources(this.checkBoxMenuExpert, "checkBoxMenuExpert");
            this.checkBoxMenuExpert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkBoxMenuExpert.Name = "checkBoxMenuExpert";
            this.checkBoxMenuExpert.UseVisualStyleBackColor = false;
            this.checkBoxMenuExpert.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBoxMenuExpert
            // 
            this.groupBoxMenuExpert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            this.groupBoxMenuExpert.Controls.Add(this.buttonApliquer);
            this.groupBoxMenuExpert.Controls.Add(this.label3);
            this.groupBoxMenuExpert.Controls.Add(this.label2);
            this.groupBoxMenuExpert.Controls.Add(this.label1);
            this.groupBoxMenuExpert.Controls.Add(this.textBoxKd);
            this.groupBoxMenuExpert.Controls.Add(this.textBoxKi);
            this.groupBoxMenuExpert.Controls.Add(this.textBoxKp);
            this.groupBoxMenuExpert.Controls.Add(this.buttonActualiser);
            this.groupBoxMenuExpert.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBoxMenuExpert.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.groupBoxMenuExpert, "groupBoxMenuExpert");
            this.groupBoxMenuExpert.Name = "groupBoxMenuExpert";
            this.groupBoxMenuExpert.TabStop = false;
            // 
            // buttonApliquer
            // 
            this.buttonApliquer.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.buttonApliquer, "buttonApliquer");
            this.buttonApliquer.Name = "buttonApliquer";
            this.buttonApliquer.UseVisualStyleBackColor = true;
            this.buttonApliquer.Click += new System.EventHandler(this.buttonApliquer_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // textBoxKd
            // 
            resources.ApplyResources(this.textBoxKd, "textBoxKd");
            this.textBoxKd.Name = "textBoxKd";
            // 
            // textBoxKi
            // 
            resources.ApplyResources(this.textBoxKi, "textBoxKi");
            this.textBoxKi.Name = "textBoxKi";
            // 
            // textBoxKp
            // 
            resources.ApplyResources(this.textBoxKp, "textBoxKp");
            this.textBoxKp.Name = "textBoxKp";
            // 
            // buttonActualiser
            // 
            this.buttonActualiser.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.buttonActualiser, "buttonActualiser");
            this.buttonActualiser.Name = "buttonActualiser";
            this.buttonActualiser.UseVisualStyleBackColor = true;
            this.buttonActualiser.Click += new System.EventHandler(this.buttonActualiser_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            this.panel1.Controls.Add(this.fermerbutton);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // fermerbutton
            // 
            resources.ApplyResources(this.fermerbutton, "fermerbutton");
            this.fermerbutton.FlatAppearance.BorderSize = 0;
            this.fermerbutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.fermerbutton.ForeColor = System.Drawing.Color.White;
            this.fermerbutton.Name = "fermerbutton";
            this.fermerbutton.UseVisualStyleBackColor = true;
            this.fermerbutton.Click += new System.EventHandler(this.fermerbutton_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Name = "label4";
            // 
            // comptagecomboBox
            // 
            this.comptagecomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.comptagecomboBox, "comptagecomboBox");
            this.comptagecomboBox.FormattingEnabled = true;
            this.comptagecomboBox.Items.AddRange(new object[] {
            resources.GetString("comptagecomboBox.Items"),
            resources.GetString("comptagecomboBox.Items1"),
            resources.GetString("comptagecomboBox.Items2"),
            resources.GetString("comptagecomboBox.Items3"),
            resources.GetString("comptagecomboBox.Items4"),
            resources.GetString("comptagecomboBox.Items5"),
            resources.GetString("comptagecomboBox.Items6")});
            this.comptagecomboBox.Name = "comptagecomboBox";
            this.comptagecomboBox.SelectedIndexChanged += new System.EventHandler(this.comptagecomboBox_SelectedIndexChanged);
            // 
            // massecomboBox
            // 
            this.massecomboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            this.massecomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.massecomboBox, "massecomboBox");
            this.massecomboBox.ForeColor = System.Drawing.Color.White;
            this.massecomboBox.FormattingEnabled = true;
            this.massecomboBox.Items.AddRange(new object[] {
            resources.GetString("massecomboBox.Items"),
            resources.GetString("massecomboBox.Items1"),
            resources.GetString("massecomboBox.Items2")});
            this.massecomboBox.Name = "massecomboBox";
            this.massecomboBox.SelectedIndexChanged += new System.EventHandler(this.massecomboBox_SelectedIndexChanged);
            // 
            // comptagebutton
            // 
            this.comptagebutton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.comptagebutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.comptagebutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            resources.ApplyResources(this.comptagebutton, "comptagebutton");
            this.comptagebutton.ForeColor = System.Drawing.Color.White;
            this.comptagebutton.Name = "comptagebutton";
            this.comptagebutton.UseVisualStyleBackColor = true;
            this.comptagebutton.Click += new System.EventHandler(this.comptagebutton_Click);
            // 
            // comptagetextBox
            // 
            this.comptagetextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            resources.ApplyResources(this.comptagetextBox, "comptagetextBox");
            this.comptagetextBox.ForeColor = System.Drawing.Color.White;
            this.comptagetextBox.Name = "comptagetextBox";
            this.comptagetextBox.ReadOnly = true;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // modecomptagelabel
            // 
            resources.ApplyResources(this.modecomptagelabel, "modecomptagelabel");
            this.modecomptagelabel.Name = "modecomptagelabel";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.comboBoxPort);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.checkBoxMenuExpert);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // indicationlabel
            // 
            this.indicationlabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            resources.ApplyResources(this.indicationlabel, "indicationlabel");
            this.indicationlabel.ForeColor = System.Drawing.Color.Red;
            this.indicationlabel.Name = "indicationlabel";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // indicatorpanel
            // 
            this.indicatorpanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            resources.ApplyResources(this.indicatorpanel, "indicatorpanel");
            this.indicatorpanel.Name = "indicatorpanel";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerStable
            // 
            this.timerStable.Tick += new System.EventHandler(this.timerStable_Tick);
            // 
            // tmesure
            // 
            this.tmesure.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.tmesure, "tmesure");
            this.tmesure.Name = "tmesure";
            // 
            // calibragebutton
            // 
            this.calibragebutton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.calibragebutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.calibragebutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            resources.ApplyResources(this.calibragebutton, "calibragebutton");
            this.calibragebutton.ForeColor = System.Drawing.Color.White;
            this.calibragebutton.Name = "calibragebutton";
            this.calibragebutton.UseVisualStyleBackColor = true;
            this.calibragebutton.Click += new System.EventHandler(this.calibragebutton_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.calibragebutton);
            this.Controls.Add(this.tmesure);
            this.Controls.Add(this.indicationlabel);
            this.Controls.Add(this.modecomptagelabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comptagetextBox);
            this.Controls.Add(this.comptagebutton);
            this.Controls.Add(this.massecomboBox);
            this.Controls.Add(this.comptagecomboBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBoxMenuExpert);
            this.Controls.Add(this.peseButton);
            this.Controls.Add(this.mainTextBox);
            this.Controls.Add(this.tareButton);
            this.Controls.Add(this.calibreButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.indicatorpanel);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxMenuExpert.ResumeLayout(false);
            this.groupBoxMenuExpert.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.ComboBox massecomboBox;
        private System.Windows.Forms.ComboBox comptagecomboBox;
        private System.Windows.Forms.Button fermerbutton;
        private System.Windows.Forms.Button comptagebutton;
        private System.Windows.Forms.TextBox comptagetextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label modecomptagelabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label indicationlabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel indicatorpanel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timerStable;
        private System.Windows.Forms.Label tmesure;
        private System.Windows.Forms.Button calibragebutton;
    }
}

