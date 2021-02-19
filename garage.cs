/*

Code for garage door control. Input parameters/sensors are:
	- 2x magnet door sensor (to see are the doors open or closed)
	- IR sensor (to see is there any obstacle in tha path of "door area")
	- ldr sensor (sense is it day or night)
	- relay (to work as a button)
	- wifi n10 (8266) shield
	- arduino nano
Code will recieve and send data with wifi shield and also work on it's own.

*/

int magnet1;   // Lower garage door magnet
int magnet2;   // Upper garage door magnet
int irSensor;  // Garage IR sensor
int garageDoorState = "op/clo";

if (irSensor >= 2.5) { // measured in meters
	if (garageLdr < 300) {
		if (garageDoors() === 1) { // Closing garage doors if left open after geting dark
			garageRelaySwitch(0);
			Serial.println("Closing garage doors...");
		}else if (garageDoors() === 2) {
			Serial.println("Garage doors are opening/closing,please wait..");
		}
	}

	if (garageDoorState = "open") {
		garageRelaySwitch(1);
	} else if (garageDoorState = "close") {
		garageRelaySwitch(0);
	}
}else {
	Serial.println("First remove the obstacle!")
}
garageDoors(); // Checking the state of the doors



// Functions

int garageRelaySwitch (int state) {
	if (state = 0) { // Closing door
		digitalWrite(garageRelay) = "LOW";
		delay(100);
		digitalWrite(garageRelay) = "HIGH";
	}else if (state = 1) { // Opening door
		digitalWrite(garageRelay) = "LOW";
		delay(100);
		digitalWrite(garageRelay) = "HIGH";
	}
}

int garageDoors () {
	if (magnet1 = "HIGH" && magnet2 = "LOW") {
		int state;
		garageDoorState = "close";
		Serial.println("Garage doors are closed");
		return state = 0;
	}else if (magnet1 = "LOW" && magnet2 = "HIGH") {
		int state;
		garageDoorState = "open";
		Serial.println("Garage doors are open");
		return state = 1;
	}else {
		garageDoorState = "op-clo";
		int state = 2;
		Serial.println("Garage doors are opening/closing.");
	}
}