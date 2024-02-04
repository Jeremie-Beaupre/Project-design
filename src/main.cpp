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
float dt, temps_0, temps_1;
float integral, erreur_precedente, output = 0;
float kp, ki, kd;
float consigne = 75.00;
float erreur = 0;
float volt_solenoide;



void setup()
{
  kp = 12;
  ki = 12;
  kd = 12;
  temps_0 = 0;
  Serial.begin(9600);
  analogWrite(PIN_out_solenoide, 0);
  lcd.begin(16, 2);             
  lcd.setCursor(0,0);
  lcd.print("Superbe Balance "); 
}


void loop()
{
  //Asservissement de la balance
  erreur = analogRead(PIN_in_position); //erreur de la position de la lame 
  volt_solenoide = pid(erreur); //Tension a fournir au solenoide
  Serial.println(output);
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

