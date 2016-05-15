//////////////////////////////////////////////////////////////////////////////////////
//| Name: BLR Robot Algorithm                                                      |//
//| Team: GROMIAN TEAM                                                             |//
//| Date: 2016.05.15                                                               |//
//| Name: By Kovacs Gyorgy                                                         |//
//|________________________________________________________________________________|//
//////////////////////////////////////////////////////////////////////////////////////

/// DO NOT, UNDER ANY CIRCUMSTANCE CUT AND PASTE ANY DECLARATION!!!

// <===========================Technical variables: pins, etc========================>
int distanceSensorPin[] = {A0, A1, A2, A3, A4, A5};
int analogInputPins = 6;
int ledPin = 13;
// <==================================================================================>

void setup() {
  // Set Distance Sensor Input pins
  for (int i = 0; i < analogInputPins; i++) {
    pinMode(distanceSensorPin[i], INPUT);
  }
  
  // Set output pins (normally motor stuff goes here)
  pinMode(ledPin, OUTPUT);
  
  // Serial computer stuff
  Serial.begin(9600);
  while(!Serial) {}
}

// <================================Software Variables================================>
// distanceSensors have analogous outputs a voltage between about 0.8V and 3.5V.
// This threshold is about 0.65 V (0V - 5V) -> (0 - 1023)
#define distanceSensorThreshold 135
// <==================================================================================>


// <===========================Algorithm Variables====================================>
int distanceSensorNumber = 7; 
byte sensorData = B00000000; // The variable that stores the sensor data, easier control
int state = 0; // Stores the state of the robot, the robot can have 15 states
// <==================================================================================>


// <===================================Functions======================================>
// return the bit "bitNumber"
byte getBit(int bitNumber, byte source) {
  if (bitNumber < 0 || bitNumber > 7) return 0;
  return (source >> bitNumber) & B00000001;
} // End of getBit

// return a byte with the "bitNumber" set to "value"
byte setBit(int bitNumber, byte source, int value) {
  if (bitNumber < 0 || bitNumber > 7) return source;
  if (value == 1) {
    source |= (1 << bitNumber);
  }
  else {
    source &= ~(1 << bitNumber);
  }
  return source;
} // End of setBit

// Read distance sensors
int readDistanceSensor(int pin) {
  int val = analogRead(pin);
  // if val is greater than the threshold, return 1, else 0
  return (val > distanceSensorThreshold)? 1 : 0;
} // End of readDistanceSensor

// read all the sensors, and store them in the variable updateSensors
void updateSensors() {
  for (int i = 0; i < distanceSensorNumber; i++) {
    sensorData = setBit(i, sensorData, readDistanceSensor(distanceSensorPin[i]));
  }
} // End of updateSensors

// Updates the state of the robot based on the sensors
void updateState() {
  
} // End of updateState

// Print to computer in binary form
void printByte(byte myByte) {
  Serial.print("B");
  for (int i = 7; i >= 0; i--) {
    Serial.print(getBit(i, sensorData));
    if (i == 4) Serial.print(" ");
  }
  Serial.println();
} // End of printByte

// Control algorithm
int h(int state ){
  return 0;
} // h

// Perform Action
void performAction (int action) {
  
} // End of performAction
// <==================================================================================>

void loop() {
  while (true) {
    updateSensors(); // Read sensors
    updateState(); // Update state
    int action = h(state); // Calculate best action
    performAction(action); // Perform that action
  }
}
