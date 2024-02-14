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
int PIN_out_solenoide = 7;
//int PIN_3V = 31;

//variable pour le PID 
float kp = 0.01;
float ki = 0.001;
float kd = 0;
float consigne = 300;
float position_lame;
float erreur;
float volt_solenoide;
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
  //digitalWrite(PIN_3V, HIGH);
}

float calculateMean(int arr[], int size) {
    int sum = 0;
    for (int i = 0; i < size; i++) {
        sum += arr[i];
    }
    return (float)sum / size;
}

void loop()
{
  //Asservissement de la balance
  position_lame = analogRead(PIN_in_position); //position de la lame
  erreur = position_lame - consigne; //erreur de la position de la lame 
  volt_solenoide = pid(erreur, kp, ki, kd); //tension a fournir au solenoide

  //Changer le menu affiché
  moy[i] = volt_solenoide;
  if(i%10){
    mean = calculateMean(moy, 10);
    i=0;
  }
  i++;
  if (volt_solenoide >= 255){
    volt_solenoide =255;
  }
  else if (volt_solenoide <= 0){
    volt_solenoide = 0;
  }
  analogWrite(PIN_out_solenoide, volt_solenoide);
  Serial.print("position lame: ");
  Serial.println(position_lame);
  Serial.print("erreur: ");
  Serial.println(erreur);
  Serial.print("solenoide: ");
  Serial.println(volt_solenoide);
  //delay(2000);

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

