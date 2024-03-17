using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleJump : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)

    {
        
        if (other.tag == "RunnerEnemy")
        {
            
            EnemyControllerReto.instance.Jump();
        }
    }
}
