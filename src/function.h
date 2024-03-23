int read_LCD_buttons();
void choose_menu(int&, int, bool&);
void choose_menu_2(int&, int, bool&);
float pid(float);
float mean_erreur(float);
float mean_volt(float);
float mean_position(int);
void getPIDValues(float &outKp, float &outKi, float &outKd);
void setPIDValues(float newKp, float newKi, float newKd);
