using UnityEngine;
using System.Collections;
using UnityEngine.PlayerLoop;

public class PlayerControllerReto : MonoBehaviour
{
    public static PlayerControllerReto instance;
    public CharacterController characterController;

    public Animator animator;

    private Vector3 moveDirection;

    // Run
    private float moveSpeed;

    // Jump
    public float jumpForce;

    float yStore;

    // Gravedad
    private float garavityScale = 1.5f;


    //velocidad
    public float timer;

    private void Awake()
    {
        instance = this;
        
    }




    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        moveSpeed = 3f;

        //Arranca isGrounded
        moveDirection.y = -1f;
    }

    void Update()
    {

        


        //Almacena el componente Y de la dirección de movimiento actual del jugador
        float yStore = moveDirection.y;

        // Movimiento
        //Calcula la dirección de movimiento basada en las entradas del teclado
        moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
        //Normaliza la dirección de movimiento para mantener una velocidad constante
        moveDirection.Normalize();
        //Escala la dirección de movimiento por la velocidad de movimiento
        moveDirection = moveDirection * moveSpeed;
        //Restaura el componente Y de la dirección de movimiento al valor almacenado anterior
        moveDirection.y = yStore;

        //Aplica el movimiento al Character Controller
        characterController.Move(moveDirection * Time.deltaTime);

        if (Input.GetAxisRaw("Vertical") != 0)
        {
            AudioManager.instance.PlaySFX(2);
        }
       

        //Salto
        if (characterController.isGrounded)
        {
            //moveDirection.y = -1f;

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
                AudioManager.instance.PlaySFX(0);
            }
        }

        else
        {
            // Gravedad
            moveDirection.y += Physics.gravity.y * Time.deltaTime * garavityScale;
        }


        //afecta los datos del animator. Le envía datos al parametro Speed
        animator.SetFloat("speed", Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.z));
        //Afecta el grounded para saber cuando está en el suelo
        animator.SetBool("grounded", characterController.isGrounded);
    }

    public void StartVelocidad()
    {
        //StartCoroutine(Velocidad());
        timer = 2f;
        timer -= Time.deltaTime;
        if (timer > 0)
        {
            moveSpeed = 6f;
        }
        else
        {
            moveSpeed = 3f;
        }

    }

  
}
   

