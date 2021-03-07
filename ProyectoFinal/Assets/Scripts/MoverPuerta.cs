using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPuerta : MonoBehaviour
{
    Animator puertas;
    CasaDomotica casaDomo;
    GameObject casa;
    // Start is called before the first frame update
    void Start()
    {
        puertas = GetComponent<Animator>();
        casa = GameObject.Find("Casa");
        casaDomo = casa.GetComponent<CasaDomotica>();
    }

    // Update is called once per frame
    void Update()
    {
        if(casaDomo.resultado=="Abierto")
        {
            puertas.gameObject.GetComponent<Animator>().enabled = true;
            puertas.Play("Open");
           
        }
        else if(casaDomo.resultado=="Cerrado")
        {
            puertas.gameObject.GetComponent<Animator>().enabled = true;
            puertas.Play("Close");
            
        }
    }
}
