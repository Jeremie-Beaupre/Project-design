#include "function.h"
#include <Arduino.h>
#include <LiquidCrystal.h>

#define btnRIGHT  0
#define btnUP     1
#define btnDOWN   2
#define btnLEFT   3
#define btnSELECT 4
#define btnNONE   5
int adc_key_in  = 0;
int array[10];
int array_1[25];
int array_2[10];
int b = 0;
int c = 0;
int d = 0;
float sum_1;
float sum;
float sum_3;

//Détermine si l'utilisateur appuie sur un bouton
int read_LCD_buttons(){
  adc_key_in = analogRead(0); // read the value from the sensor
  if (adc_key_in > 1500) return btnNONE; // We make this the 1st option for speed reasons since it will be the most likely result
  if (adc_key_in < 50)   return btnRIGHT;  
  if (adc_key_in < 195)  return btnUP; 
  if (adc_key_in < 380)  return btnDOWN; 
  if (adc_key_in < 500)  return btnLEFT; 
  if (adc_key_in < 750)  return btnSELECT;   
  return btnNONE;  // when all others fail, return this...
}

//Met a jour la valeur menu qui détermine le menu affiché
void choose_menu(int& menu, int lcd_key, bool& buttonPressed){
  if (lcd_key == btnUP && !buttonPressed){
    menu += 1;
    if (menu == 6){
    menu = 1;
    }
  buttonPressed = true;
  }
  else if (lcd_key == btnDOWN && !buttonPressed){
    menu -= 1;
    if (menu <= 0){
      menu = 5;
    }
    buttonPressed = true;
  }
  else if (lcd_key == btnNONE) {
    buttonPressed = false;
  }
}

void choose_menu_2(int& menu_2, int lcd_key, bool& buttonPressed){
  if (lcd_key == btnRIGHT && !buttonPressed){
    menu_2 += 1;
    if (menu_2 == 6){
    menu_2 = 1;
    }
  buttonPressed = true;
  }
  else if (lcd_key == btnLEFT && !buttonPressed){
    menu_2 -= 1;
    if (menu_2 <= 0){
      menu_2 = 5;
    }
    buttonPressed = true;
  }
  else if (lcd_key == btnNONE) {
    buttonPressed = false;
  }
}
//Moyenne de position
float mean_position(int PIN_in_position){
  sum_3 = 0;
  array_2[d] = analogRead(PIN_in_position);
  d += 1;
  if (d >= 9){
    d = 0;
  }
  for (float e : array_2){
    sum_3 += e;
  }
  return (sum_3/10);
}


//Moyenne de l'erreur
float mean_erreur(float erreur){
  sum = 0;
  array[b] = erreur;
  b += 1;
  if (b >= 9){
    b = 0;
  }
  for (float n : array){
    sum += n;
  }
  return (sum/10);
}

//Moyenne de la sortie de l'arduino
float mean_volt(float volt){
  sum_1 = 0;
  array_1[c] = volt;
  c += 1;
  if (c > 25){
    c = 0;
  }
  for (float a : array_1){
    sum_1 += a;
  }
  return (sum_1/25);
}


