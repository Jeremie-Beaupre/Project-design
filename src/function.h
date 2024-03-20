//Bouton sur le LCD shield
#define btnRIGHT    0
#define btnUP       1
#define btnDOWN     2
#define btnLEFT     3
#define btnSELECT   4
#define btnNONE     5

//Num menu utilisateur
#define MENU_INIT       0
#define MENU_POIDgr     1
#define MENU_POIDoz     2
#define MENU_OIDsl      3
#define MENU_NBRpc      4
#define MENU_TEST       5

int read_LCD_buttons();
void choose_menu(int&, int, bool&);
int test();