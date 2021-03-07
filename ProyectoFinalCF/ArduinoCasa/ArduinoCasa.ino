#include <Servo.h>
#include <SoftwareSerial.h>
SoftwareSerial pserial(3, 4); //RX,TX
const int sensorT = A0;
const int bSala = 12;
const int bCocina = 11;
const int bBano = 10;
const int bCuarto = 9;
Servo MPUERTA;
Servo MVENTANA;
const int trigger = A2; //trigger del sensor de ultrasonido
const int echo = A3; //echo del sensor de ultrasonido



void setup() {
  // put your setup code here, to run once:
  pinMode(sensorT, INPUT);
  pinMode(bSala, OUTPUT);
  pinMode(bCocina, OUTPUT);
  pinMode(bBano, OUTPUT);
  pinMode(bCuarto, OUTPUT);
  pinMode(trigger, OUTPUT);
  pinMode(echo, INPUT);
  MPUERTA.attach(7);
  MVENTANA.attach(6);
  digitalWrite(trigger, LOW);
  MPUERTA.write(0);
  MVENTANA.write(0);
  Serial.begin(9600);
  pserial.begin(9600);

}

void loop() {
  // put your main code here, to run repeatedly:

  long t; //tiempo que demora en llegar el eco
  long d; //distancia en centimetros

  digitalWrite(trigger, HIGH);
  delayMicroseconds(10);          //Enviamos un pulso de 10us
  digitalWrite(trigger, LOW);

  t = pulseIn(echo, HIGH); //obtenemos el ancho del pulso
  d = 0.0343 * (t / 59);   //escalamos el tiempo a una distancia en cm

  int valor = analogRead(sensorT);


  float voltaje = ((5.0 / 1023.0) * (valor));
  float temperatura = (voltaje * 100.0);
  Serial.write((int)temperatura);
    if (temperatura <= 22)
    {
      MVENTANA.write(0);
      pserial.print("rain");
      pserial.print(",");

    }
    else
    {
      pserial.print("norain");
      pserial.print(",");
    }


  if (Serial.available()) {

    char dato = Serial.read();
    pserial.print(dato);
    pserial.print(",");

    switch (dato) {
      case ('0'):
        digitalWrite(bSala, HIGH);
        digitalWrite(bCocina, HIGH);
        break;
      case ('1'):
        digitalWrite(bSala, LOW);
        digitalWrite(bCocina, LOW);
        break;
      case ('2'):
        digitalWrite(bBano, HIGH);
        digitalWrite(bCuarto, HIGH);
        break;
      case ('3'):
        digitalWrite(bBano, LOW);
        digitalWrite(bCuarto, LOW);
        break;
      case ('4'):
        MPUERTA.write(180);
        break;
      case ('5'):
        MPUERTA.write(0);
        break;
      case ('6'):

        if (temperatura <= 22)
        {
          MVENTANA.write(0);

        }
        else
        {

          MVENTANA.write(180);
        }

        break;
      case ('7'):
        MVENTANA.write(0);
        break;
    }

  }
  pserial.println();
  Serial.flush();
  delay(1000);
}
