﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;
    public float propellerSpeed;

    public GameObject propeller;

    // Start is called before the first frame update
    void Start()
    {
        propeller = GameObject.Find("Propeller");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
       verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // tilt the plane up/down based on up/down arrow keys
        // transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);

        transform.Rotate(Vector3.right, -(verticalInput) * rotationSpeed * Time.deltaTime);


        //Rotate Propeller

        propeller.transform.Rotate(Vector3.forward, propellerSpeed * Time.deltaTime);

    }
}
