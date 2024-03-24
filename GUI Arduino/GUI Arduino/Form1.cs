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
        private bool etalonnage = false;
        private bool tarageDone = false;
        private int pesebtn = 0;
        private DateTime startTime;
        private Color lastcall;
        private bool etalonnageDone = false;
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
        private void RefreshComPorts()
        {
            // Clear existing items in the ComboBox
            comboBoxPort.Items.Clear();

            // Get the current list of available COM ports
            string[] ports = SerialPort.GetPortNames();

            // Add each port to the ComboBox
            foreach (string port in ports)
            {
                comboBoxPort.Items.Add(port);
            }
        }

        private void tareButton_Click(object sender, EventArgs e)
        {
            //Envoie de la commande tarage à l'arduino
            if(indicatorpanel.BackColor == Color.Green)
            {
                if (etalonnage)
                {
                    tarageDone = true;
                    etalonnage = false;
                    serialPort.Write("A");
                    indicationlabel.ForeColor = Color.White;
                    indicationlabel.Text = "Mettez une masse de 10g et appuyer sur peser";
                }
                else
                {
                    serialPort.Write("A");
                    timer1.Interval = 5000;
                    timer1.Start();
                    indicationlabel.ForeColor = Color.LimeGreen;
                    indicationlabel.Text = "Tarage effectué avec succès!"; // on clear les indications dans le cas d'un succes
                }
            }
            else
            {
                timer1.Interval = 5000;
                if (!etalonnage)
                {
                    timer1.Start();
                    indicationlabel.ForeColor = Color.Red;
                }
                indicationlabel.Text = "Veuillez attendre que la mesure soit stable.";
            }
        }

        private void calibreButton_Click(object sender, EventArgs e)
        {
            //Envoie de la commande à l'arduino
            serialPort.Write("B");
            indicationlabel.ForeColor = Color.White;
            indicationlabel.Text = "Mettez la balance à zéro en appuyant sur Tarage.";
            etalonnage = true;
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
                            textBoxKp.Text = kp.ToString("F5");
                            textBoxKi.Text = ki.ToString("F5");
                            textBoxKd.Text = kd.ToString("F5");
                        }
                        break;
                    case "STAB":
                        string dataStab = indata.Substring(4);
                        lastcall = indicatorpanel.BackColor;
                        if (dataStab.Contains("instable"))
                        {
                            indicatorpanel.BackColor = Color.Red;
                            ChangeState();
                        }
                        else if (dataStab.Contains("stable"))
                        {
                            indicatorpanel.BackColor = Color.Green;
                            ChangeState();
                        }
                        break;
                    case "PREC":
                        string dataPrec = indata.Substring(4);
                        indicationlabel.ForeColor = Color.LimeGreen;
                        indicationlabel.Text = "La précision de la balance est de" + dataPrec + "%";
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
            serialPort.Close();
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
            if (comptagecomboBox.SelectedIndex != -1)
            {
                if (indicatorpanel.BackColor == Color.Green)
                {
                    indicationlabel.Text = ""; // On clear le label d'information
                    string key = comptagecomboBox.SelectedItem.ToString();
                    switch (key)
                    {
                        case "Estimer":
                            double val = CalculerValeurMonetaireEstime((double)masseMain);
                            comptagetextBox.Text = val.ToString("0.00") + "$";
                            break;
                        case "1¢":
                            int res = (int)(masseMain / masseMoyParPieces[key]);
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
                else
                {
                    timer1.Interval = 5000;
                    timer1.Start();
                    indicationlabel.ForeColor = Color.Red;
                    indicationlabel.Text = "Veuillez attendre que la mesure soit stable!";
                }
            }
            else
            {
                timer1.Interval = 5000;
                timer1.Start();
                indicationlabel.ForeColor = Color.Red;
                indicationlabel.Text = "Veuillez sélectionnez un mode de comptage!";
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

        private void comboBoxPort_DropDown(object sender, EventArgs e)
        {
            RefreshComPorts();
        }

        private void mainTextBox_Enter(object sender, EventArgs e)
        {
            indicationlabel.Focus();
        }

        private void peseButton_Click(object sender, EventArgs e)
        {
            if(indicatorpanel.BackColor == Color.Green)
            {
                if (tarageDone)
                {
                    switch (pesebtn)
                    {
                        case 0:
                            serialPort.Write("E");
                            indicationlabel.ForeColor = Color.White;
                            indicationlabel.Text = "Mettez une masse de 20g et appuyer sur peser";
                            pesebtn++;
                            break;
                        case 1:
                            serialPort.Write("F");
                            indicationlabel.ForeColor = Color.White;
                            indicationlabel.Text = "Mettez une masse de 50g et appuyer sur peser";
                            pesebtn++;
                            break;
                        case 2:
                            serialPort.Write("G");
                            //indicationlabel.ForeColor = Color.LimeGreen;
                            //indicationlabel.Text = "Félicitations vous avez terminé l'étalonnage!";
                            timer1.Interval = 5000;
                            timer1.Start();
                            tarageDone = false;
                            etalonnageDone = true;
                            pesebtn = 0;
                            break;
                    }
                }
            }
            else
            {
                indicationlabel.ForeColor = Color.Red;
                indicationlabel.Text = "Attendez que la valeur soit stable avant de continuer!";
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            indicationlabel.ForeColor = Color.White;
            indicationlabel.Text = "";
            timer1.Stop();
        }
        private void ChangeState()
        {
            // Change the state here
            // Start the timer when the state changes
            if(lastcall != indicatorpanel.BackColor)
            {
                startTime = DateTime.Now;
                timerStable.Start();
            }
        }

        private void timerStable_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = DateTime.Now - startTime;
            //tmesure.Text = elapsed.ToString(@"hh\:mm\:ss");
            if (indicatorpanel.BackColor == Color.Green && elapsed.TotalSeconds >= 4)
            {
                // Calculate tenths of a second
                int tenths = (int)((elapsed.TotalMilliseconds % 1000) / 100);

                // Format the elapsed time to include seconds and tenths of a second
                string formattedTime = $"{elapsed.Seconds}.{tenths:0}s";

                tmesure.Text = formattedTime;
            }
        }

        private void calibragebutton_Click(object sender, EventArgs e)
        {
            if (etalonnageDone)
            {
                serialPort.Write("C");
            }
            else
            {
                indicationlabel.ForeColor = Color.Red;
                indicationlabel.Text = "Veuillez étalonner avant de calibrer";
                timer1.Interval = 5000;
                timer1.Start();
            }
        }
    }
}
