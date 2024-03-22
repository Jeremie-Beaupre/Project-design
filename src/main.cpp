#include <LiquidCrystal.h>
#include <Arduino.h>
#include "function.h"


LiquidCrystal lcd(8, 9, 4, 5, 6, 7);

//variable pour le menu
int menu = 0;
int menu_2 = 1;
int lcd_key;
bool buttonPressed = false;

//Lecture poid
float tension_poid = 0;
int PIN_in_poid = A14;


//Calibration
unsigned long startTime = 0;
float K_poid = 0.32;

//PIN pour le PID
int PIN_in_position = A15;
int PIN_out_solenoide = 45;
//int PIN_3V = 31;

//tarage
float tar = 26.2;

//variable pour le PID 
float kp = 0.00007;
float ki = 0.00007;
float kd = 0;
float consigne = 300;
float position_lame;
float erreur;
float erreur_mean;
float volt_solenoide;
float volt_solenoide_mean;
int i;




void setup()
{
  i=0;
  Serial.begin(9600);
  analogWrite(PIN_out_solenoide, 20);
  delay(5000);
  lcd.begin(16, 2);             
  lcd.setCursor(0,0);
  lcd.print("Superbe Balance ");
  consigne = analogRead(PIN_in_position);
  //digitalWrite(PIN_3V, HIGH);
}


void loop()
{
  //Asservissement de la balance
  position_lame = analogRead(PIN_in_position); //position de la lame
  erreur = position_lame - consigne; //erreur de la position de la lame 
  erreur_mean = mean_erreur(erreur);
  volt_solenoide = pid(erreur_mean, kp, ki, kd); //tension a fournir au solenoide
  if (volt_solenoide >= 255){
    volt_solenoide =255;
  }
  // else if (volt_solenoide <= 0){
  //   volt_solenoide = 0;
  // }


  

  // analogWrite(PIN_out_solenoide, 20);
  analogWrite(PIN_out_solenoide, volt_solenoide);
  // Serial.print("position lame: ");
  // Serial.println(position_lame);
  Serial.print("erreur: ");
  Serial.println(erreur);
  // Serial.print(": erreur moyenne: ");
  // Serial.println(K_poid);
  // Serial.print("solenoide: ");
  // Serial.println(volt_solenoide);
  
  tension_poid = analogRead(PIN_in_poid);
  volt_solenoide_mean = mean_volt(tension_poid);



  //Serial.print("Poids: ");
  //Serial.println(volt_solenoide_mean*0.37);
  // Serial.print("Poids: ");
  // Serial.println(volt_solenoide_mean*0.59);
  // Serial.println(K_poid);


  //Changer le menu affiché
  lcd_key = read_LCD_buttons();
  choose_menu(menu, lcd_key, buttonPressed);
  
  switch (menu)
  {               
    case 0:
      {
      lcd.setCursor(0,1);
      lcd.print("Initialisation   ");
      break;
      }
    case 1:
      {
      lcd.setCursor(0,0);
      lcd.print("Poids (g):          ");
      lcd.setCursor(0,1);
      lcd.print((volt_solenoide_mean-tar)*K_poid, 1);
      lcd.print("             ");
      break;
      }
    case 2:
      {
      lcd.setCursor(0,0);
      lcd.print("Poids (oz):         ");
      lcd.setCursor(0,1);
      lcd.print((volt_solenoide_mean-tar)*0.37*0.03527, 1);
      lcd.print("                  ");
      break;
      }
    case 3:
      {
      lcd.setCursor(0,0);
      lcd.print("Comptage piece        ");
      lcd_key = read_LCD_buttons();
      choose_menu_2(menu_2, lcd_key, buttonPressed);
      switch (menu_2)
      {
        case 1:
        {
          lcd.setCursor(0,1);
          lcd.print("5 cents :");
          lcd.print(int((volt_solenoide_mean-tar)*0.37/3.95));
          lcd.print("                ");
          break;
        }
        case 2:
        {
          lcd.setCursor(0,1);
          lcd.print("10 cents :");
          lcd.print(int((volt_solenoide_mean-tar)*0.37/1.75));
          lcd.print("                ");
          break;
        }
        case 3:
        {
          lcd.setCursor(0,1);
          lcd.print("25 cents :");
          lcd.print(int((volt_solenoide_mean-tar)*0.37/4.4));
          lcd.print("                ");
          break;
        }
        case 4:
        {
          lcd.setCursor(0,1);
          lcd.print("1 dollars :");
          lcd.print(int((volt_solenoide_mean-tar)*0.37/7));
          lcd.print("                ");
          break;
        }
        case 5:
        {
          lcd.setCursor(0,1);
          lcd.print("2 dollars :");
          lcd.print(int((volt_solenoide_mean-tar)*0.37/7.3));
          lcd.print("                ");
          break;
        }
      }
      break;
      }
    case 4:
      {
      lcd.setCursor(0,0);
      lcd.print("Calibration:      ");
      lcd.setCursor(0,1);
      lcd.print("Mettre 20g         ");
      if (lcd_key == 4 && !buttonPressed){
        K_poid = 20/(volt_solenoide_mean-tar);
        lcd.setCursor(0,1);
        lcd.print("En cours     ");
        delay(2000);
      }
      else if(lcd_key == 5){
        buttonPressed = false;
        }

      break;
      }
    case 5:
      {
      lcd.setCursor(0,0);
      lcd.print("Tare:             ");
      lcd.setCursor(0,1);
      lcd.print("                     ");
      if (lcd_key == 4 && !buttonPressed){
        tar = volt_solenoide_mean;
        lcd.setCursor(0,1);
        lcd.print("En cours     ");
        delay(2000);
      }
      else if(lcd_key == 5){
      buttonPressed = false;
      }
      break;
      }
  }
}

