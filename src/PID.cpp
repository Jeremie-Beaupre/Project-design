#include "PID.h"
#include <Arduino.h>
#include <LiquidCrystal.h>

float integral, proportionnel, derive = 0;
float dt, temps_0, temps_1 = 0;
float erreur_precedente = 0;
float sortie_pid;
//Valeur par défaut pour le PID
float kp = 0.01;
float ki = 0.001;
float kd = 0;

float pid(float erreur){
  temps_1 = millis();                         //temps_1 pour calculer dt
  dt = temps_1 - temps_0;                     //dt pour calculer l'integral
  temps_0 = temps_1;                          //temps_0 pour calculer dt
  proportionnel = erreur;                     //consigne proportionnel
  integral += erreur*dt;                      //consigne intergral, peut être amélioré
  derive = (erreur - erreur_precedente) / dt; //consigne derive
  erreur_precedente = erreur;                 //pour le prochain calcul de la derive
  sortie_pid = (kp * proportionnel) + (ki * integral) + (kd * derive);
  return sortie_pid;
}

void getPIDValues(float &outKp, float &outKi, float &outKd) {
    outKp = kp;
    outKi = ki;
    outKd = kd;
}

void setPIDValues(float newKp, float newKi, float newKd) {
    kp = newKp;
    ki = newKi;
    kd = newKd;
}