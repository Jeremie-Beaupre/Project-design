#include "function.h"
#include <Arduino.h>
#include <LiquidCrystal.h>
float integral, proportionnel, derive = 0;
float dt, temps_0, temps_1 = 0;
float erreur_precedente = 0;
float sortie_pid;
float sortie_pid_precedente;


// float pid(float erreur, float kp, float ki, float kd){
//   temps_1 = millis();
//   dt = temps_1 - temps_0;
//   temps_0 = temps_1; 
//   sortie_pid = sortie_pid_precedente + kp*(erreur - erreur_precedente) + ki*erreur*dt;
//   sortie_pid_precedente = sortie_pid;
//   erreur_precedente = erreur; 
//   return sortie_pid;
// }

float pid(float erreur, float kp, float ki, float kd){
  temps_1 = millis(); //temps_1 pour calculer dt
  dt = temps_1 - temps_0; //dt pour calculer l'integral
  temps_0 = temps_1; //temps_0 pour calculer dt
  proportionnel = erreur; //consigne proportionnel
  integral += erreur*dt; //consigne intergral, peut être amélioré
  if (integral*ki > 300){//Pour ne pas ajouter de l'erreur si c'est déjà au maximum
    integral = 300/ki;
  }
  derive = (erreur - erreur_precedente) / dt; //consigne derive
  erreur_precedente = erreur; //pour le prochain calcul de la derive
  sortie_pid = (kp * proportionnel) + (ki * integral) + (kd * derive);
  return sortie_pid;
}

int test(){
  return 0;
}