#include <LiquidCrystal.h>
#include <Arduino.h>
#include "function.h"


LiquidCrystal lcd(8, 9, 4, 5, 6, 7);

//variable pour le menu
int menu = 0;
int lcd_key;
bool buttonPressed = false;

//Lecture poid
float tension_poid = 0;
int PIN_in_poid = A14;


//Calibration
unsigned long startTime = 0;
float K_poid = 0.59;

//PIN pour le PID
int PIN_in_position = A15;
int PIN_out_solenoide = 45;
//int PIN_3V = 31;

//variable pour le PID 
float kp = 0.2;
float ki = 0.0001;
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
  analogWrite(PIN_out_solenoide, 0);
  lcd.begin(16, 2);             
  lcd.setCursor(0,0);
  lcd.print("Superbe Balance ");
  consigne = analogRead(PIN_in_position);
  //digitalWrite(PIN_3V, HIGH);
}

// float calculateMean(int arr[], int size) {
//     int sum = 0;
//     for (int i = 0; i < size; i++) {
//         sum += arr[i];
//     }
//     return (float)sum / size;
// }

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
  else if (volt_solenoide <= 0){
    volt_solenoide = 0;
  }
  

  

  // analogWrite(PIN_out_solenoide, 0);
  analogWrite(PIN_out_solenoide, volt_solenoide);
  // Serial.print("position lame: ");
  // Serial.println(position_lame);
  // Serial.print("erreur: ");
  // Serial.println(erreur);
  // Serial.print(": erreur moyenne: ");
  // Serial.println(erreur_mean);
  // Serial.print("solenoide: ");
  // Serial.println(volt_solenoide);
  
  tension_poid = analogRead(PIN_in_poid);
  volt_solenoide_mean = mean_volt(tension_poid);
  Serial.print("Poids: ");
  Serial.println(volt_solenoide_mean*0.37);
  // Serial.print("Poids: ");
  // Serial.println(volt_solenoide_mean*0.59);
  // Serial.println(K_poid);


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
      lcd.print("Poids (g):          ");
      break;
      }
    case 2:
      {
      lcd.print("Poids (oz):         ");
      break;
      }
    case 3:
      {
      lcd.print("Poids (slug):        ");
      break;
      }
    case 4:
      {
      lcd.print("Calibration:      ");
      if (lcd_key == 4 && !buttonPressed){
        lcd.setCursor(0,0);
        lcd.print("Debut calibration...      ");
        lcd.setCursor(0,1);
        lcd.print("Ne pas toucher     ");
        analogWrite(PIN_out_solenoide, 0);
        delay(3000);
        consigne = analogRead(PIN_in_position);
        lcd.setCursor(0,0);
        lcd.print("Mettre 50g         ");
        lcd.setCursor(0,1);
        lcd.print("Press select       ");
        lcd_key = read_LCD_buttons();
        while (lcd_key != 4){
          lcd_key = read_LCD_buttons();
          delay(1);
        }
        startTime = millis();
        while (millis() - startTime <= 6000 ){
          position_lame = analogRead(PIN_in_position); //position de la lame
          erreur = position_lame - consigne; //erreur de la position de la lame 
          //erreur_mean = mean_erreur(erreur);
          volt_solenoide = pid(erreur, kp, ki, kd); //tension a fournir au solenoide
          //volt_solenoide_mean = mean_volt(volt_solenoide);
          Serial.println(volt_solenoide);
        }
        K_poid = 20/volt_solenoide;
        lcd.setCursor(0,0);
      }
      else if(lcd_key == 5){
        buttonPressed = false;
        }
      break;
      }
    case 5:
      {
      lcd.print("Tare:            ");
      break;
      }
  }
}

