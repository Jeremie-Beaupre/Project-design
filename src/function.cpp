#include "function.h"
#include <Arduino.h>
#include <LiquidCrystal.h>

int adc_key_in  = 0;

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
void choose_menu(int& menu, int lcd_key, bool& buttonPressed)
{
  if (lcd_key == btnUP && !buttonPressed)
  {
    menu += 1;
    if (menu == MENU_TEST){
    menu = 1;
    }
    buttonPressed = true;
  }
  else if (lcd_key == btnDOWN && !buttonPressed)
  {
    menu -= 1;
    if (menu <= 0){
      menu = MENU_NBRpc;
    }
    buttonPressed = true;
  }
  else if (lcd_key == btnNONE) 
  {
    buttonPressed = false;
  }
  else if (lcd_key == btnRIGHT){
    menu = MENU_TEST;
    buttonPressed = true;
  }
}

