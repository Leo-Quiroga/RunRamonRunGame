using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed, speedRotation;
    
    private float rotY, movZ;

    private float maxRotationAngle = 45f;
   
    GameObject wheelRight, wheelLeft;

       
    void Start()
    {
        wheelRight = GameObject.Find("Wheel_fr");
        wheelLeft = GameObject.Find("Wheel_fl");
    }

   
    void Update()
    {
        movZ = Input.GetAxis("Vertical");
        rotY = Input.GetAxis("Horizontal");
        
        //Adelante y atr�s del veh�culo
       
        //transform.Translate(0, 0, movZ * Time.deltaTime * speed);

        transform.Translate(Vector3.forward * Time.deltaTime * speed * movZ);

        //Giro derecha o izquierda  si el veh�culo se est� moviendo
        if (movZ > 0)
        {
           // transform.Rotate(0, rotY * Time.deltaTime * speedRotation, 0);

            transform.Rotate(Vector3.up, speedRotation * rotY * Time.deltaTime);
        }
        else if (movZ < 0) //girar en reversa de forma intuitiva
        {
           // transform.Rotate(0, rotY * Time.deltaTime * -(speedRotation), 0);

            transform.Rotate(Vector3.up, -(speedRotation) * rotY * Time.deltaTime);

        }


        //Rotaci�n de llantas
  
            // Si no se gira las llantas vuelven a 0
            if (rotY == 0)
            {
                ResetWheelRotation();
            }
            else
            {
                // Rotar las llantas seg�n la entrada de direcci�n
                RotateWheels(rotY);
            }
        
    }

    void RotateWheels(float rotationInput)
    {
        // Calcular el �ngulo de rotaci�n para las llantas
        float targetRotation = rotationInput * maxRotationAngle;

        // Aplicar la rotaci�n gradualmente
        wheelRight.transform.localRotation = Quaternion.RotateTowards(wheelRight.transform.localRotation, Quaternion.Euler(0f, targetRotation, 0f), speedRotation * Time.deltaTime);
        wheelLeft.transform.localRotation = Quaternion.RotateTowards(wheelLeft.transform.localRotation, Quaternion.Euler(0f, targetRotation, 0f), speedRotation * Time.deltaTime);
    }

    void ResetWheelRotation()
    {
        // Restablecer la rotaci�n de las llantas
        wheelRight.transform.localRotation = Quaternion.RotateTowards(wheelRight.transform.localRotation, Quaternion.identity, speedRotation * Time.deltaTime);
        wheelLeft.transform.localRotation = Quaternion.RotateTowards(wheelLeft.transform.localRotation, Quaternion.identity, speedRotation * Time.deltaTime);
    }





}
