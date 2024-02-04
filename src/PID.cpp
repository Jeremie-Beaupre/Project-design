#include "function.h"
#include <Arduino.h>
#include <LiquidCrystal.h>

float dt, last_time;
float integral, previous, output = 0;
float kp, ki, kd;
float setpoint = 75.00;