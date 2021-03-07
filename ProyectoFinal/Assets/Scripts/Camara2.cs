using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara2 : MonoBehaviour
{
    [SerializeField]
    private string mouseXInputName, mouseYInputName;//campo para poner cuales son los inputs de mi mouse en X y en Y
    [SerializeField]
    private float mouseSensetivity;//campo para poner un valor de sensibilidad del mouse

    private float limite; //limite de camara para no girar totalmente en y, solo para hacerlo 90 grados hacia arriba y abajo
    [SerializeField]
    private Transform PlayerBody; //campo para seleccionar quien es mi jugador en movimiento
   
    



    // Use this for initialization
    void Start()
    {
        LockCursor(); //metodo para bloquear el cursor inicialmente

    }




    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation(); //metodo que genera la rotación con sus condiciones

    }

    private void CameraRotation()
    {
        //this.gameObject.transform.eulerAngles.y + mouseX

        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensetivity * Time.deltaTime;//obtenga el eje de mi mouse, multipliquelo por la sensibilidad del este en un tiempo cualquiera
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensetivity * Time.deltaTime;

        limite += mouseY;

        if(limite>90.0f)
        {
            limite = 90.0f;
            mouseY = 0.0f;
            generarLimiteCamara(270.0f);
        }
        else if (limite < -90.0f)
        {
            limite = -90.0f;
            mouseY = 0.0f;
            generarLimiteCamara(90.0f);
            
        }
        transform.Rotate(-Vector3.right* mouseY);//el - que multiplica el vector es porque sin este se invierte los movimientos en y
        PlayerBody.Rotate(Vector3.up * mouseX);
       





    }

    private void generarLimiteCamara(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }





}
