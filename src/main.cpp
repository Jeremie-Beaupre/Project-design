#include <LiquidCrystal.h>
#include <Arduino.h>
#include "function.h"
#include "PID.h"
#include "gui.h"

//LCD
LiquidCrystal lcd(8, 9, 4, 5, 6, 7);

//GUI
String data, formattedData;
char dl;

//variable pour le menu
int menu = 0;
int lcd_key;
bool buttonPressed = false;

//Lecture poid
float tension_poid = 0;
int PIN_in_poid = A14;

//PIN pour le PID
int PIN_in_position = A15;
int PIN_out_solenoide = 7;

//Variable pour le PID
float consigne = 300;
float position_lame;
float erreur;
float erreur_mean;
float volt_solenoide;
float volt_solenoide_mean;

//Old Version
int position_lame_moyenne;
int moy[10];
int i;
int mean = 0;


void setup()
{
  i=0;
  Serial.begin(9600);
  analogWrite(PIN_out_solenoide, 0);
  lcd.begin(16, 2);             
  lcd.setCursor(0,0);
  lcd.print("Superbe Balance ");
  consigne = analogRead(PIN_in_position);
}


void loop()
{
  //Asservissement de la balance
  position_lame = analogRead(PIN_in_position);  //position de la lame
  erreur = position_lame - consigne;            //erreur de la position de la lame 
  erreur_mean = mean_erreur(erreur);
  volt_solenoide = pid(erreur);                 //tension a fournir au solenoide

  //Calcule de la moyenne au 10 mesure
  moy[i] = volt_solenoide;
  if(i%10){
    mean = calculateMean(moy, 10);
    i=0;
  }
  i++;
  
  if (volt_solenoide >= 255){
    volt_solenoide = 255;
  }
  else if (volt_solenoide <= 0){
    volt_solenoide = 0;
  }

  analogWrite(PIN_out_solenoide, volt_solenoide);
  tension_poid = analogRead(PIN_in_poid);
  volt_solenoide_mean = mean_volt(tension_poid);

  //Logique pour ecrire sur le LCD
  lcd_key = read_LCD_buttons();
  choose_menu(menu, lcd_key, buttonPressed);
  lcd.setCursor(0,1);
  if(buttonPressed)
  {
    switch (menu)
    {               
    case MENU_INIT:
      lcd.print("Initialisation   ");
      break;

    case MENU_POIDgr:
      lcd.print("Poid (g):          ");
      break;

    case MENU_POIDoz:
      lcd.print("Poid (oz):         ");
      break;

    case MENU_POIDsl:
      lcd.print("Poid (slug):        ");
      break;

    case MENU_NBRpc:
      lcd.print("Nbr. de piece:      ");
      break;

    case MENU_TEST:
      int test = 1691;
      writeGUI(String(test), "MAIN", Serial);
      break;
    }
  }


  //GUI Reception
  if(Serial.available())
  {
    data = Serial.readString();       
    lcd.setCursor(0,0);
    lcd.print("                ");    //Clear le LCD
    lcd.setCursor(0,0);
    dl = data.charAt(0);
    readGUI(data);
  }
}