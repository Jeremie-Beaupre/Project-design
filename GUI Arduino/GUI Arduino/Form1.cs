using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Arduino
{
    public partial class Form1 : Form
    {
        private string calibreinfo;
        public delegate void d1(string indata);
        public Form1()
        {
            InitializeComponent();
            serialPort.Open();
        }

        private void tareButton_Click(object sender, EventArgs e)
        {
            //Envoie de la commande à l'arduino
            serialPort.Write("A");
        }

        private void calibreButton_Click(object sender, EventArgs e)
        {
            //Envoie de la commande à l'arduino
            serialPort.Write("B");
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string indata = serialPort.ReadLine();
            d1 writeit = new d1(Write2Form);
            Invoke(writeit, indata);
        }

        public void Write2Form(string indata)
        {
            //La fonction contrôle les données recu de l'arduino
            string firstchar;
            Single numdata;

            if (indata.Length >= 4)
            {
                firstchar = indata.Substring(0, 4);
                switch (firstchar)
                {
                    case "MAIN":
                        string dataSubstring = indata.Substring(4);
                        mainTextBox.Text = dataSubstring;
                        //mainTextBox.Text = Convert.ToString(indata[1]);
                        break;

                    case "VPID":
                        string[] values = indata.Substring(5).Split(',');
                        if (values.Length == 3)
                        {
                            float kp = float.Parse(values[0]);
                            float ki = float.Parse(values[1]);
                            float kd = float.Parse(values[2]);
                            //textBoxKp.Text = values[0];
                            //textBoxKi.Text = values[1];
                            //textBoxKd.Text = values[2];
                            textBoxKp.Text = kp.ToString("F5");
                            textBoxKi.Text = ki.ToString("F5");
                            textBoxKd.Text = kd.ToString("F5");
                        }
                        break;

                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Verifie si le port est ouvert (fait par defaut)
            if(serialPort.IsOpen)
            {
                serialPort.Close();
            }
            string selectedPort = comboBoxPort.SelectedItem.ToString();
            serialPort.PortName = selectedPort;

            serialPort.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            comboBoxPort.Items.AddRange(ports);

            // Select the first port by default if available
            if (ports.Length > 0)
                comboBoxPort.SelectedIndex = 0;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxMenuExpert.Visible = checkBoxMenuExpert.Checked;
        }

        private void buttonActualiser_Click(object sender, EventArgs e)
        {
            serialPort.Write("C");
        }

        private void buttonApliquer_Click(object sender, EventArgs e)
        {
            float kp, ki, kd;
            if (float.TryParse(textBoxKp.Text, out kp) &&
                float.TryParse(textBoxKi.Text, out ki) &&
                float.TryParse(textBoxKd.Text, out kd))
            {
                // Conversion successful, kp, ki, and kd contain the float values
                string message = string.Format("D{0:F5},{1:F5},{2:F5}", kp, ki, kd);
                serialPort.Write(message);
            }
            else
            {
                // Handle conversion failure
            }
        }
    }
}
