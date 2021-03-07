using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class Camara : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;

    public Rigidbody rb;


    public void Movement(Vector3 _velocity)
    {

        velocity = _velocity;
    
    }

    public void Rotation(Vector3 _rotation) 
    {

        rotation = _rotation;
    
    }


    void FixedUpdate()
    {

        MovimientoM();
        RotacionM();

    }

    void MovimientoM()
    {

        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

    }

    void RotacionM()
    {

        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

    }


}