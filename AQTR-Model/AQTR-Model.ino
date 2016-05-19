/// Internet of Things 
/// Intelligent Roadways

#define samplingTime 100
#define sensorThreshold 250

#define parkingSensor1 A0
#define parkingSensor2 A1
#define y1Sensor A2
#define y2Sensor A3

#define redPin1 13
#define greenPin1 12 
#define redPin2 11
#define greenPin2 10


void setup() {
  pinMode(parkingSensor1, INPUT);
  pinMode(parkingSensor2, INPUT);
  pinMode(y1Sensor, INPUT);
  pinMode(y2Sensor, INPUT);
  
  pinMode(redPin1, OUTPUT);
  pinMode(greenPin1, OUTPUT);
  pinMode(redPin2, OUTPUT);
  pinMode(greenPin2, OUTPUT);
  
  Serial.begin(9600);
  while (!Serial) {}
}

boolean readSensor(int pin) {
  int value = analogRead(pin);
  return (value < sensorThreshold)? true : false;
}

int carsInY1 = 0;
int carsInY2 = 0;
int carsInParking = 0;
int parkingState = 0; // State (1, 1)

boolean y1 = false;
boolean xy1 = y1;
boolean y2 = false;
boolean xy2 = y2;
boolean psi = false;
boolean xpsi = psi;
boolean pso = false;
boolean xpso = pso;

void loop() {
  y1 = readSensor(y1Sensor);
  y2 = readSensor(y2Sensor);
  psi = readSensor(parkingSensor1);
  pso = readSensor(parkingSensor2);
  
  // <==== Parking ====================================>
  Serial.print("SI = ");
  Serial.print(psi);
  Serial.print(" SO = ");
  Serial.print(pso);
  Serial.print(" | State = ");
  Serial.print(parkingState);
  
  if (parkingState == 0) {
    if (!pso && psi) parkingState = 1; // State (1, 1) -> (0, 1)
    if (pso && !psi) parkingState = 4; // State (1, 1) -> (1, 0)
  }
  
  if (parkingState == 1) {
    if (!pso && !psi) parkingState = 2; // (1, 1) -> (0, 1) -> (0, 0) 
    if (pso && psi) parkingState = 0; // (1, 1) -> (0, 1) -> (1, 1) => probably error
  }
  
  if (parkingState == 4) {
    if (!pso && !psi) parkingState = 5; // (1, 1) -> (1, 0) -> (0, 0)
    if (pso && psi) parkingState = 0; // (1, 1) -> (0, 1) -> (1, 1) => probably error
  }
  
  if (parkingState == 2) {
    if (pso && !psi) parkingState = 3; // (1, 1) -> (1, 0) -> (0, 0) -> (1, 0)
  }
  
  if (parkingState == 5) {
    if (!pso && psi) parkingState = 6; // (1, 1) -> (1, 0) -> (0, 0) -> (0, 1)
  }
  
  if (parkingState == 3) {
    if (pso && psi) {
      parkingState = 0; // -> (1, 1)
      carsInParking++;
    }
  }
  
  if (parkingState == 6) {
    if (pso && psi) {
      parkingState = 0; // -> (1, 1)
      carsInParking--;
    }
  }
  
  Serial.print(" Cars: ");
  Serial.println(carsInParking);
  // <==== End of Parking =============================>
  
  // <==== Y split ====================================>
  if (!y1 && xy1) carsInY1++;
  if (!y2 && xy2) carsInY2++;
  
  if (carsInY1 > carsInY2) {
    digitalWrite(redPin1, HIGH);
    digitalWrite(redPin2, LOW);
    digitalWrite(greenPin1, LOW);
    digitalWrite(greenPin2, HIGH);
  }
  else {
    digitalWrite(redPin1, LOW);
    digitalWrite(redPin2, HIGH);
    digitalWrite(greenPin1, HIGH);
    digitalWrite(greenPin2, LOW);
  }
  // <==== END OF Y split ==============================>
  /*
  Serial.print("Y1 = ");
  Serial.print(carsInY1);
  Serial.print(" Y2 = ");
  Serial.println(carsInY2);
  */
  
  xy1 = y1;
  xy2 = y2;
  xpsi = psi;
  xpso = pso;
  delay(samplingTime);
}
