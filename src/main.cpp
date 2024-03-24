#include <LiquidCrystal.h>
#include <Arduino.h>
#include "function.h"
#include "gui.h"


LiquidCrystal lcd(8, 9, 4, 5, 6, 7);

//variable pour le menu
int menu = 0;
int menu_2 = 1;
int lcd_key;
bool buttonPressed = false;

//GUI
String data, formattedData;
char dl;

//Lecture poid
float tension_poid = 0;
int PIN_in_poid = A14;

//Calibration
unsigned long startTime = 0;
float K_poid = 0.32;

//PIN pour le PID
int PIN_in_position = A15;
int PIN_out_solenoide = 45;

//tarage
float tar = 30;
float poid_gramme;

//variable pour le PID 
float consigne = 300;
float position_lame;
float erreur;
float erreur_mean;
float volt_solenoide;
float volt_solenoide_mean;
long i;

// stabilité mesure
const int n_mesures_stabilite = 80; 
const float tolerance_stabilite = 0.003/K_poid;
float mesures_tension_poids[n_mesures_stabilite];
float standard_dev = 10;
bool stable = false;
bool previous_stable = false;
float tension_stable;

//timer
float past_millis = 0;
float current_millis = 0; 
int interval = 2000;

float get_mean(float array[], const byte length){
  double total = 0;
  for(int i = 0; i < length; i++){
    total = total + array[i];
  }
  return total/length;
}

float get_std(float array[], const byte length){
  float mean = get_mean(array, length);
  long total = 0;
  for (int h = 0; h < length; h++){
    total = total + (array[h] - mean)*(total + (array[h] - mean));
  }

  float variance = total/(float)length;
  float std = pow(variance, 0.5);
  return std;
}



void setup()
{
  i=0;
  Serial.begin(9600);
  analogWrite(PIN_out_solenoide, 20);
  delay(5000);
  lcd.begin(16, 2);             
  lcd.setCursor(0,0);
  lcd.print("Superbe Balance ");
  for (int t = 0; t < 20; t++){
  Serial.println(analogRead(PIN_in_position));
  consigne = mean_position(PIN_in_position);
  Serial.println(consigne);
  }
}


void loop()
{
  //Asservissement de la balance
  position_lame = analogRead(PIN_in_position); //position de la lame
  erreur = position_lame - consigne; //erreur de la position de la lame 
  volt_solenoide = pid(erreur); //tension a fournir au solenoide
  if (volt_solenoide >= 255){
    volt_solenoide =255;
  }

  analogWrite(PIN_out_solenoide, volt_solenoide);
  Serial.print("position lame: ");
  Serial.println(position_lame);
  tension_poid = analogRead(PIN_in_poid);
  volt_solenoide_mean = mean_volt(tension_poid);

  mesures_tension_poids[i % n_mesures_stabilite] = volt_solenoide_mean;

  standard_dev = get_std(mesures_tension_poids, n_mesures_stabilite);
  previous_stable = stable;
  if (standard_dev <= tolerance_stabilite){
    stable = true;
  } else{
    stable = false;
  }

  lcd_key = read_LCD_buttons();
  choose_menu(menu, lcd_key, buttonPressed);
  
  current_millis = millis();
  float voltage = get_mean(mesures_tension_poids, n_mesures_stabilite) - tar;
  poid_gramme = voltage*K_poid;

  writeGUI(String(poid_gramme), "MAIN", Serial);

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
      if (!stable){
        lcd.setCursor(0,1);
        lcd.print((voltage)*K_poid, 1);
        lcd.print("            ");
        lcd.setCursor(5,1);
        lcd.print("Instable          ");
      }
      else if (!previous_stable && stable){
        lcd.setCursor(0,1);
        lcd.print((voltage)*K_poid, 1);
        lcd.print("            ");
        lcd.setCursor(5,1);
        lcd.print("Instable           "); 
      }
      else if (current_millis - past_millis >= interval){
        past_millis = millis();
        lcd.setCursor(0,1);
        lcd.print((voltage)*K_poid, 1);
        lcd.print("            ");
        lcd.setCursor(5,1);
        lcd.print("Instable           "); 

      }
      else{
        lcd.setCursor(4,1);
        lcd.print("            ");
        lcd.setCursor(5,1);
        lcd.print("Stable       ");
      }
      break;
      }
    case 2:
      {
      lcd.setCursor(0,0);
      lcd.print("Poids (oz):         ");
      if (!stable){
        lcd.setCursor(0,1);
        lcd.print((voltage)*K_poid*0.03527, 1);
        lcd.print("            ");
        lcd.setCursor(5,1);
        lcd.print("Instable          ");
      }
      else if (!previous_stable && stable){
        lcd.setCursor(0,1);
        lcd.print((voltage)*K_poid*0.03527, 1);
        lcd.print("            ");
        lcd.setCursor(5,1);
        lcd.print("Instable           "); 
      }
      else if (current_millis - past_millis >= interval){
        past_millis = millis();
        lcd.setCursor(0,1);
        lcd.print((voltage)*K_poid*0.03527, 1);
        lcd.print("            ");
        lcd.setCursor(5,1);
        lcd.print("Instable           "); 

      }
      else{
        lcd.setCursor(4,1);
        lcd.print("            ");
        lcd.setCursor(5,1);
        lcd.print("Stable       ");
      }
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
        case 6:
        {
          lcd.setCursor(0,1);
          lcd.print("Hoang is best");
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
  i++;

  if(stable){
    writeGUI(String("stable"), "STAB", Serial);
  }
  else{
    writeGUI(String("instable"), "STAB", Serial);
  }

  //GUI Reception
  if(Serial.available())
  {
    data = Serial.readString();       
    dl = data.charAt(0);
    int ret = readGUI(data);
    if(ret == 1){
      //Tarage provenant du GUI
      tar = volt_solenoide_mean;
    }
    if(ret == 2){
      //Étalonnage provenant du GUI
    }
  }
}