#include <LiquidCrystal.h>
#include <Arduino.h>

// select the pins used on the LCD panel
LiquidCrystal lcd(8, 9, 4, 5, 6, 7);

// define some values used by the panel and buttons
int lcd_key     = 0;
int adc_key_in  = 0;
int menu = 0;
bool buttonPressed = false;

#define btnRIGHT  0
#define btnUP     1
#define btnDOWN   2
#define btnLEFT   3
#define btnSELECT 4
#define btnNONE   5

// read the buttons
int read_LCD_buttons()
{
  adc_key_in = analogRead(0);      // read the value from the sensor
  Serial.println(adc_key_in);
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


void setup()
{
  Serial.begin(9600);
  lcd.begin(16, 2);              // start the library
  lcd.setCursor(0,0);
  lcd.print("Masse: "); // print a simple message
}


void loop()
{



  lcd_key = read_LCD_buttons();  // read the buttons
  if (lcd_key == btnUP && !buttonPressed){
    menu += 1;
    buttonPressed = true;
  }
  else if (lcd_key == btnDOWN && !buttonPressed){
    menu -= 1;
    buttonPressed = true;
  }

  else if (lcd_key == btnNONE) {
    buttonPressed = false;
  }

  if(menu > 0){
    lcd.setCursor(9,1); 
  }
  else
    lcd.setCursor(8,1);            // move cursor to second line "1" and 9 spaces over 

  lcd.print(menu);

  lcd.setCursor(0,1);            // move to the begining of the second line
  switch (lcd_key)               // depending on which button was pushed, we perform an action
  {
    case btnRIGHT:
      {
      lcd.print("RIGHT ");
      break;
      }
    case btnLEFT:
      {
      lcd.print("LEFT   ");
      break;
      }
    case btnUP:
      {
      lcd.print("UP    ");
      break;
      }
    case btnDOWN:
      {
      lcd.print("DOWN  ");
      break;
      }
    case btnSELECT:
      {
      lcd.print("SELECT");
      break;
      }
      case btnNONE:
      {
      lcd.print("NONE  ");
      break;
      }
  }
  }