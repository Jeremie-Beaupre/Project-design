#include <Arduino.h>
#define LED 7
// put function declarations here:
void setup() {
  // put your setup code here, to run once:
  pinMode(LED , OUTPUT);
}

void loop() {
  digitalWrite(LED , HIGH);//turn the LED On by making the voltage HIGH
  delay(500);                       // wait half a second
  digitalWrite(LED , LOW);// turn the LED Off by making the voltage LOW
  delay(500);   
}
