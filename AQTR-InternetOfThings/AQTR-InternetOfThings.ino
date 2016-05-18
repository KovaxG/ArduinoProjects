//////////////////////////////////////////////////////////////
//| Name: Internet of Things: Traffic Counter              |//
//|________________________________________________________|//
//////////////////////////////////////////////////////////////

#define SampleTime 200
#define sensorNr 5
#define inputPinsLength 10

// Pin data
int inputPins[] = {3, 4, 5, 6, 7, 8, 9, 10, 11, 12};

void setup() {
	for (int i = 0; i < inputPinsLength; i++) {
		pinMode(inputPins[i], INPUT);
	}
  
	Serial.begin(9600);
	while (!Serial) {}
}

// Algoritm variables
int t[] = {0, 0, 0, 0, 0};
int in = 0;

boolean SO[] = {false, false, false, false, false};
boolean SI[] = {false, false, false, false, false};
boolean XSO[] = {false, false, false, false, false};
boolean XSI[] = {false, false, false, false, false};


void readAllSensors() {
	for (int i = 0; i < sensorNr; i++) {
		XSO[i] = SO[i];
		XSI[i] = SI[i];
	}
	for (int i = 0; i < sensorNr; i += 2) {
		SO[i] = !digitalRead(inputPins[i]);
		SI[i] = !digitalRead(inputPins[i+1]);
	}
}

void updateStates(int index) {
	if (!SO[index] && !SI[index] && XSO[index]) {
		if (t[index] == -1) in--;
		t[index]++;
		if (t[index] > 1) t[index] = 1;
	}
	if (!SI[index] && !SO[index] && XSI[index]) {
		if (t[0] == 1) in++;
		t[0]--;
		if (t[0] < -1) t[0] = -1;
	}
}

void loop() {

	readAllSensors();
	
	for (int i = 0; i < sensorNr; i++) {
		updateStates(i);
	}
  
	Serial.print(" t1 = ");
	Serial.print(t[0]);
	Serial.print(" In = ");
	Serial.println(in);

	delay(SampleTime);
}
