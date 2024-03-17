
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject powerUpParticles;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            PlayerControllerReto.instance.StartVelocidad();
            GameObject.Destroy(gameObject);
            AudioManager.instance.PlaySFX(3);
          

            Instantiate(powerUpParticles, PlayerControllerReto.instance.transform.position + new Vector3(0f, 1f, 0f), PlayerControllerReto.instance.transform.rotation);


        }
    }
}
