// Pin data
int SeIn_1 = 9;
int SeOu_1 = 8;
int SeIn_2 = 10;
int SeOu_2 = 11;


void setup() {
  pinMode (SeIn_1, INPUT_PULLUP);
  pinMode (SeOu_1, INPUT_PULLUP);
  pinMode (SeIn_2, INPUT_PULLUP);
  pinMode (SeOu_2, INPUT_PULLUP);
  
  Serial.begin(9600);
  while (!Serial) {}
}


int t1 = 0;
int in = 0;

boolean XSI_1;
boolean XSO_1;
boolean SI_1;
boolean SO_1;


void loop() {
  
  SI_1 = !digitalRead(SeIn_1);
  SO_1 = !digitalRead(SeOu_1);
  
  if (!SO_1 && !SI_1 && XSO_1) {
    if (t1 == -1) in--;
    t1++;
    if (t1 > 1) t1 = 1;
  }
  if (!SI_1 && !SO_1 && XSI_1) {
    if (t1 == 1) in++;
    t1--;
    if (t1 < -1) t1 = -1;
  }
  
  Serial.print(" t1 = ");
  Serial.print(t1);
  Serial.print(" In = ");
  Serial.println(in);
  
  XSI_1 = SI_1;
  XSO_1 = SO_1;
  
  delay(200);
}


