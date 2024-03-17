using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class EnemyControllerReto : MonoBehaviour
{
    public static EnemyControllerReto instance;
    public CharacterController characterControllerEnemy;

    public Animator animatorEnemy;

    private Vector3 moveDirectionEnemy;

    // Run
    private float moveSpeedEnemy = 5f;

    // Jump
    public float jumpForceEnemy;

    // Gravedad
    private float garavityScaleEnemy = 1.5f;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        characterControllerEnemy = GetComponent<CharacterController>();
        animatorEnemy = GetComponentInChildren<Animator>();

        moveDirectionEnemy.y = -1f;
    }

    void Update()
    {
        float yStore = moveDirectionEnemy.y;

        // Movimiento
        moveDirectionEnemy = (transform.forward * 1);
        moveDirectionEnemy.Normalize();
        moveDirectionEnemy = moveDirectionEnemy * moveSpeedEnemy;
        moveDirectionEnemy.y = yStore;

        characterControllerEnemy.Move(moveDirectionEnemy * Time.deltaTime);

        //Gravedad cuando salta
        if (!characterControllerEnemy.isGrounded)
        {
            // Gravedad
            moveDirectionEnemy.y += Physics.gravity.y * Time.deltaTime * garavityScaleEnemy;
        }


        //afecta los datos del animator. Le envía datos al parametro Speed
        animatorEnemy.SetFloat("speed", Mathf.Abs(moveDirectionEnemy.x) + Mathf.Abs(moveDirectionEnemy.z));
        //Afecta el grounded para saber cuando está en el suelo
        animatorEnemy.SetBool("grounded", characterControllerEnemy.isGrounded);
    }


    public void Jump()
    {

        
        //Salto
        if (characterControllerEnemy.isGrounded)
        {
            
            moveDirectionEnemy = moveDirectionEnemy = new Vector3(0, jumpForceEnemy, 0);
           

        }
    }


}
