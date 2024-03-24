#include "gui.h"
#include "function.h"

//GUI envoie
void writeGUI(String outdata, String messageType, HardwareSerial& Serial)
{
    Serial.print(messageType);
    Serial.println(outdata);
}

int readGUI(String& indata)
{
    char dl;
    String formattedData;
    dl = indata.charAt(0);
    switch(dl)
    {
        case 'A':
            // On recoit la commande de tarage
            return 1;
        case 'B':
            //lcd.print("CALI");    //Mettre une variable qui va determiner l'etat du lcd
            return 2;
        case 'C':
        {
            float kp, ki ,kd; 
            getPIDValues(kp, ki, kd);
            formattedData = String(kp, 5) + "," + String(ki, 5) + "," + String(kd, 5);
            writeGUI(formattedData, "VPID", Serial);
            break;
        }
        case 'D':
        {
            indata.remove(0, 1); // Remove the "D" from the beginning of the message
            int commaIndex1 = indata.indexOf(','); // Find the index of the first comma
            int commaIndex2 = indata.indexOf(',', commaIndex1 + 1); // Find the index of the second comma
            int commaIndex3 = indata.indexOf(',', commaIndex2 + 1); // Find the index of the third comma
            // Extract the substrings between the commas and convert them to floats
            float newkp = indata.substring(0, commaIndex1).toFloat();
            float newki = indata.substring(commaIndex1 + 1, commaIndex2).toFloat();
            float newkd = indata.substring(commaIndex2 + 1, commaIndex3).toFloat();
            setPIDValues(newkp, newki, newkd);
            break;
        }
        case 'E':
            //Étalonnage d'une masse de 10g
            return 3;
        case 'F':
            //Étalonnage d'une masse de 20g
            return 4;
        case 'G':
            //Étalonnage d'une masse de 50g
            return 5;
        case 'H':
            //Calibration de la balance
            return 6;
    }
    return 0;
}