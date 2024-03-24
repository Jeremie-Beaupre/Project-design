using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private int uniteMesure = 0;
        private int modeComptage = 0;
        private float masseMain = 0;
        public delegate void d1(string indata);

        // Définition des masses moyennes pour chaque type de pièces en grammes
        private Dictionary<string, double> masseMoyParPieces = new Dictionary<string, double>
        {
            {"1¢", 2.35},
            {"5¢", 3.95},
            {"10¢", 1.75},
            {"25¢", 4.4},
            {"1$", 6.27},
            {"2$", 7.3},
        };
        
        // Valeur de chaque type de pièce
        private Dictionary<string, double> valeurParPieces = new  Dictionary<string, double>
        {
            {"1¢", 0.01},
            {"5¢", 0.05},
            {"10¢", 0.10},
            {"25¢", 0.25},
            {"1$", 1.00},
            {"2$", 2.00},
        };

        public Form1()
        {
            InitializeComponent();
            massecomboBox.SelectedIndex = 0; //Met en gramme par defaut
        }

        private double CalculerValeurMonetaireEstime(double totalMass)
        {
            double totalValue = 0.0;
            foreach (KeyValuePair<string, double> pair in masseMoyParPieces)
            {
                // Calculer le nombre approximatif de chaque type de pièce
                int numberOfCoins = (int)(totalMass / pair.Value);
                // Ajouter la valeur de chaque type de pièce au total
                totalValue += numberOfCoins * valeurParPieces[pair.Key];
                // Mettre à jour la masse totale en retirant la masse des pièces utilisées
                totalMass -= numberOfCoins * pair.Value;
            }
            return totalValue;
        }

        private void affichermasse(float masse)
        {
            if (uniteMesure == 0) // on est en gramme
            {
                mainTextBox.Text = masse.ToString("0.0");
            }
            else if (uniteMesure == 1) // on est en oz
            {
                masse = masse * (float)0.035274;
                mainTextBox.Text = masse.ToString("0.0");
            }
            else if (uniteMesure == 2) // on est en slug
            {
                masse = masse * (float)6.85218;
                mainTextBox.Text = masse.ToString("0.0") + "e-5";
            }
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
            try
            {
                string indata = serialPort.ReadLine();
                d1 writeit = new d1(Write2Form);
                Invoke(writeit, indata);
                // Process the received data
            }
            catch (IOException ex)
            {
                // Handle the IOException gracefully
                indicationlabel.Text = "L'arduino a été déconnecté" + ex.Message;
                // Optionally, you can close and reopen the serial port, or perform other cleanup tasks
            }
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
                        try
                        {
                            masseMain = float.Parse(dataSubstring);
                        }
                        catch(Exception e)
                        {
                            mainTextBox.Text = "Redémarrer!";
                        }
                        affichermasse(masseMain);
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
                    default:
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

        private void fermerbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void massecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string unitemasse;
            switch (massecomboBox.SelectedItem.ToString())
            {
                case "g":
                    uniteMesure = 0;
                    unitemasse = "gramme\0";
                    break;
                case "oz":
                    uniteMesure = 1;
                    unitemasse = "oz\0";
                    break;
                case "slug":
                    uniteMesure = 2;
                    unitemasse = "slug\0";
                    break;
                default:
                    uniteMesure = 0;
                    unitemasse = "gramme\0";
                    break;
            }
        }

        private void comptagebutton_Click(object sender, EventArgs e)
        {
            //Mettre un condition seulement si on est stable et selected mode
            string key = comptagecomboBox.SelectedItem.ToString();
            switch (key)
            {
                case "Estimer":
                    double val = CalculerValeurMonetaireEstime((double)masseMain);
                    comptagetextBox.Text = val.ToString("0.00") + "$";
                    break;
                case "1¢":
                    int res = (int) (masseMain / masseMoyParPieces[key]);
                    float val1 = res * (float)valeurParPieces[key];
                    comptagetextBox.Text = $"{val1.ToString("0.00")}$ ({res} pièces de 1¢)";
                    break;
                case "5¢":
                    int res2 = (int)(masseMain / masseMoyParPieces[key]);
                    float val2 = res2 * (float)valeurParPieces[key];
                    comptagetextBox.Text = $"{val2.ToString("0.00")}$ ({res2} pièces de {key})";
                    break;
                case "10¢":
                    int res3 = (int)(masseMain / masseMoyParPieces[key]);
                    float val3 = res3 * (float)valeurParPieces[key];
                    comptagetextBox.Text = $"{val3.ToString("0.00")}$ ({res3} pièces de {key})";
                    break;
                case "25¢":
                    int res4 = (int)(masseMain / masseMoyParPieces[key]);
                    float val4 = res4 * (float)valeurParPieces[key];
                    comptagetextBox.Text = $"{val4.ToString("0.00")}$ ({res4} pièces de {key})";
                    break;
                case "1$":
                    int res5 = (int)(masseMain / masseMoyParPieces[key]);
                    float val5 = res5 * (float)valeurParPieces[key];
                    comptagetextBox.Text = $"{val5.ToString("0.00")}$ ({res5} pièces de {key})";
                    break;
                case "2$":
                    int res6 = (int)(masseMain / masseMoyParPieces[key]);
                    float val6 = res6 * (float)valeurParPieces[key];
                    comptagetextBox.Text = $"{val6.ToString("0.00")}$ ({res6} pièces de {key})";
                    break;
            }
        }

        private void comptagecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comptagecomboBox.SelectedItem.ToString())
            {
                case "Estimer":
                    modeComptage = 0;
                    break;
                case "1¢":
                    modeComptage = 1;
                    break;
                case "5¢":
                    modeComptage = 2;
                    break;
                case "10¢":
                    modeComptage = 3;
                    break;
                case "25¢":
                    modeComptage = 4;
                    break;
                case "1$":
                    modeComptage = 5;
                    break;
                case "2$":
                    modeComptage = 6;
                    break;
                default:
                    modeComptage = 0;
                    break;
            }
        }
    }
}
