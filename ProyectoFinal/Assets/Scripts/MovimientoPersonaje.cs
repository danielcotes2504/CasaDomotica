using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour


{

    public float velocidad = 5f;
    public float sensitivity = 100f;

    Camara motor;

    public Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<Camara>();
    }

    // Update is called once per frame
    void Update()
    {

        float zMove = Input.GetAxisRaw("Vertical");
        float xMove = Input.GetAxisRaw("Horizontal");

        Vector3 directionZ = transform.forward * zMove;
        Vector3 directionX = transform.forward * xMove;


        Vector3 velocity = (directionZ + directionX).normalized * velocidad;


        motor.Movement(velocity);

        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0, yRot, 0) * sensitivity ;

        motor.Rotation(rotation);

        float xRot = Input.GetAxisRaw("Mouse Y");

        float camRot = xRot * sensitivity;

        mainCam.transform.localEulerAngles -= new Vector3(camRot,0 , 0);

    }



}
