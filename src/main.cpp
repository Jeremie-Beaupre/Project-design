#include <LiquidCrystal.h>
#include <Arduino.h>
#include "function.h"


LiquidCrystal lcd(8, 9, 4, 5, 6, 7);

//variable pour le menu
int menu = 0;
int lcd_key;
bool buttonPressed = false;

//PIN pour le PID
int PIN_in_position = A15;
int PIN_out_solenoide = 53;

//variable pour le PID 
float kp = 12;
float ki = 12;
float kd = 12;
float consigne = 0;
float position_lame;
float erreur;
float volt_solenoide;



void setup()
{
  Serial.begin(9600);
  analogWrite(PIN_out_solenoide, 0);
  lcd.begin(16, 2);             
  lcd.setCursor(0,0);
  lcd.print("Superbe Balance "); 
}


void loop()
{
  //Asservissement de la balance
  position_lame = map(analogRead(PIN_in_position), 0, 1024, 0, 255); //position de la lame
  erreur = consigne - position_lame; //erreur de la position de la lame 
  volt_solenoide = pid(erreur, kp, ki, kd); //tension a fournir au solenoide
  Serial.println(volt_solenoide);
  //Changer le menu affiché
  lcd_key = read_LCD_buttons();
  choose_menu(menu, lcd_key, buttonPressed);
  lcd.setCursor(0,1);
  switch (menu)
  {               
    case 0:
      {
      lcd.print("Initialisation   ");
      break;
      }
    case 1:
      {
      lcd.print("Poid (g):          ");
      break;
      }
    case 2:
      {
      lcd.print("Poid (oz):         ");
      break;
      }
    case 3:
      {
      lcd.print("Poid (slug):        ");
      break;
      }
    case 4:
      {
      lcd.print("Nbr. de piece:      ");
      break;
      }
      case 5:
      {
      lcd.print("Auto destruction     ");
      break;
      }
  }
}

