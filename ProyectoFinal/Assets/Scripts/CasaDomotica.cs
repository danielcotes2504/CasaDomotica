using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;
using DigitalRuby.RainMaker;


public class CasaDomotica : MonoBehaviour
{
    // Start is called before the first frame update
    SerialPort stream = new SerialPort("COM1", 9600);

    public string[] vec;
    public string value;
    public GameObject lucesSalaCocina;
    public GameObject lucesBanoCuarto;
    RainScript rainSC;
    public GameObject lluvia;
    public string resultado = "";
    public String resultadov = "";
// public GameObject lluvia;
    void Start()
    {
        stream.Open(); //Open the Serial Stream.

        stream.ReadTimeout = 100;
        rainSC = lluvia.GetComponent<RainScript>();
    }

    // Update is called once per frame
    void Update()
    {
           try
        {
        value = stream.ReadLine();
       vec = value.Split(',');
        //print(value);
      print(vec[1]);
     
            if(vec[0]=="rain")
            {
                rainSC.RainIntensity = 1;
                resultadov = "CerrarV";
            }
            else if(vec[0]=="norain")
            {
                rainSC.RainIntensity = 0;
                
            }
            if(vec[1]=="0")
            {
                lucesSalaCocina.SetActive(true);
            }
            else if(vec[1]=="1")
            {
                lucesSalaCocina.SetActive(false);
            }

            if(vec[1]=="2")
            {
                lucesBanoCuarto.SetActive(true);
            }
            else if(vec[1]=="3")
            {
                lucesBanoCuarto.SetActive(false);
            }
            if(vec[1]=="4")
            {
                resultado = "Abierto";
            }
            else if(vec[1]=="5")
            {
                resultado = "Cerrado";
            }
            if(vec[1]=="6" && vec[0]=="rain")
            {
                resultadov = "nada";
            }
            else if(vec[1]=="6" && vec[0]=="norain")
            {
                resultadov = "AbrirV";
            }
            else if(vec[1]=="7")
            {
                resultadov = "CerrarV";
            }
               }

// Only catch timeout exceptions.
    catch (TimeoutException e)
        {
       
        }
    catch(InvalidOperationException i)
        {
        
        }
       
    }
}
