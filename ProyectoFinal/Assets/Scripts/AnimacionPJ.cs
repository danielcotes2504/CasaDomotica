using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionPJ : MonoBehaviour
{
    // Start is called before the first frame update



    public Animator animate;


    // Use this for initialization
    void Start()
    {


        animate = this.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {

            animate.SetInteger("EstadoPersonaje", 1);

        }
        else
        {
            animate.SetInteger("EstadoPersonaje", 0);
        }

















    }
}
