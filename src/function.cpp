#include "function.h"
#include <Arduino.h>
#include <LiquidCrystal.h>

int adc_key_in  = 0;
int array[10];
int array_1[25];
int b = 0;
int c = 0;
int sum_1;
int sum;

//Détermine si l'utilisateur appuie sur un bouton
int read_LCD_buttons()
{
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

//Moyenne de l'erreur
float mean_erreur(float erreur)
{
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
float mean_volt(float volt)
{
  sum_1 = 0;
  array_1[c] = volt;
  c += 1;
  if (c > 25)
  {
    c = 0;
  }
  for (float a : array_1)
  {
    sum_1 += a;
  }
  return (sum_1/25);
}

float calculateMean(int arr[], int size) {
    int sum = 0;
    for (int i = 0; i < size; i++) {
        sum += arr[i];
    }
    return (float)sum / size;
}