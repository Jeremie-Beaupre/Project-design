#include "function.h"
#include <Arduino.h>
#include <LiquidCrystal.h>
float integral, proportionnel, derive = 0;
float dt, temps_0, temps_1 = 0;
float erreur_precedente = 0;
float sortie_pid;

float pid(float erreur, float kp, float ki, float kd){
  temps_1 = millis();
  dt = temps_1 - temps_0;
  temps_0 = temps_1;
  proportionnel = erreur;
  integral += erreur*dt;
  derive = (erreur - erreur_precedente) / dt;
  erreur_precedente = erreur;
  sortie_pid = (kp * proportionnel) + (ki * integral) + (kd * derive);
  return sortie_pid;
}

int test(){
  return 0;
}