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
int array[10] = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
int b = 0;
int sum;

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

float mean(float erreur){
  sum = 0;
  array[b] = erreur;
  b += 1;
  if (b >= 9){
    b = 0;
  }
  for (int n : array){
    sum += n;
  }
  return (sum/10);
}
