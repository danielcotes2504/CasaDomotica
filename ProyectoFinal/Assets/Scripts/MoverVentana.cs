using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverVentana : MonoBehaviour
{

    // Start is called before the first frame update

    Animator ventanas;
    CasaDomotica casaDomo;
    GameObject casa;
    void Start()
    {
        ventanas = GetComponent<Animator>();
        casa = GameObject.Find("Casa");
        casaDomo = casa.GetComponent<CasaDomotica>();
    }

    // Update is called once per frame
    void Update()
    {
        if (casaDomo.resultadov == "AbrirV")
        {
            ventanas.gameObject.GetComponent<Animator>().enabled = true;
            ventanas.Play("VOpen");

        }
        else if (casaDomo.resultadov == "CerrarV")
        {
            ventanas.gameObject.GetComponent<Animator>().enabled = true;
            ventanas.Play("VClose");

        }
    }
}
