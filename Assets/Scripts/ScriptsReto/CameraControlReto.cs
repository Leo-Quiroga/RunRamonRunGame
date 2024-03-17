using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraControlReto : MonoBehaviour
{
    public GameObject player;

    
    public Vector3 offset = new Vector3(0, 5, -7);
 
    void Start()
    {
        player = GameObject.Find("Player");
    }

   
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
