#include "function.h"
#include <Arduino.h>


#define btnRIGHT  0
#define btnUP     1
#define btnDOWN   2
#define btnLEFT   3
#define btnSELECT 4
#define btnNONE   5
int adc_key_in  = 0;

int read_LCD_buttons(){
  adc_key_in = analogRead(0);      // read the value from the sensor
  Serial.println("f");
  // my buttons when read are centered at these valies: 0, 144, 329, 504, 741
  // we add approx 50 to those values and check to see if we are close
  if (adc_key_in > 1500) return btnNONE; // We make this the 1st option for speed reasons since it will be the most likely result
  if (adc_key_in < 50)   return btnRIGHT;  
  if (adc_key_in < 195)  return btnUP; 
  if (adc_key_in < 380)  return btnDOWN; 
  if (adc_key_in < 500)  return btnLEFT; 
  if (adc_key_in < 750)  return btnSELECT;   
  return btnNONE;  // when all others fail, return this...
}