/// Name: Internet of Things: Traffic Counter

// Pin data
int inputPins[] = {3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
int inputPinsLength = 10;

void setup() {
	for (int i = 0; i < inputPinsLength; i++) {
		pinMode(inputPins[i], INPUT);
	}
  
	Serial.begin(9600);
	while (!Serial) {}
}

int t[] = {0, 0, 0, 0, 0};
int sensorNr = 5;
int in = 0;

boolean SO[] = {false, false, false, false, false};
boolean SI[] = {false, false, false, false, false};
boolean XSO[] = {false, false, false, false, false};
boolean XSI[] = {false, false, false, false, false};


void readAllSensors() {
	for (int i = 0; i < sensorNr; i++) {
		SO[i] = !digitalRead(inputPins[]);
	}
}

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


