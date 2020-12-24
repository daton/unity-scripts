using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControlador : MonoBehaviour
{
    CharacterController m_Character; // A reference to the ThirdPersonCharacter on the object
    private Transform m_Cam;                  // A reference to the main camera in the scenes transform
    private Vector3 m_CamForward;             // The current forward direction of the camera
    private Vector3 m_Move;
    Animator m_Animator;
    Rigidbody m_Rigidbody;

    public float turnSpeed = 20f;
    Quaternion m_Rotation = Quaternion.identity;

    public TextMeshProUGUI txtCliente;
    bool botonOprimido=false;

    //brinco
    private float playerSpeed = 2.0f;
    public float jumpHeight = 3.8f;
    private float gravityValue = -5.8f;
    private Vector3 playerVelocity;
    private bool groundedPlayer;




    private float waitTime = 2.0f;
    private float timer = 0.0f;
    private float visualTime = 0.0f;
    private float scrollBar = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "malo")
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            playerVelocity.y += gravityValue * Time.deltaTime;
            m_Character.Move(playerVelocity * Time.deltaTime);
            m_Animator.SetTrigger("brincar");

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = scrollBar;
        //   Screen.fullScreen = !Screen.fullScreen; 
        //https://docs.unity3d.com/ScriptReference/DeviceType.html
        // El siguiente para ve en andrioid etc si sirve pero en faceboo se sierra
        // txtCliente.SetText("Cliente: " + SystemInfo.operatingSystem);
        botonOprimido = false;
       
        // get the transform of the main camera
        if (Camera.main != null)
        {
            m_Cam = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning(
                "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
            // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
        }
        //   m_Rigidbody = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();
        m_Character = GetComponent<CharacterController>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

   


        groundedPlayer = m_Character.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        // read inputs
         float h = UltimateJoystick.GetHorizontalAxis( "Movimiento" );
      //  float h = Input.GetAxis("Horizontal");
      float v = UltimateJoystick.GetVerticalAxis( "Movimiento" );
      //  float v = Input.GetAxis("Vertical");


      
            // calculate camera relative direction to move:
            m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
            m_Move = v * m_CamForward + h * m_Cam.right;
        
       
        bool hasHorizontalInput = !Mathf.Approximately(h, 0f);
        bool hasVerticalInput = !Mathf.Approximately(v, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;

        m_Animator.SetBool("IsWalking", isWalking);
  

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Move, turnSpeed * Time.deltaTime, 0f);


        m_Rotation = Quaternion.LookRotation(desiredForward);
       
        playerVelocity.y += gravityValue * Time.deltaTime;
        m_Character.Move(playerVelocity * Time.deltaTime);
        m_Rotation = Quaternion.LookRotation(desiredForward);


        if (ControlFreak2.CF2Input.GetButtonDown("Jump"))
        {

            if (m_Character.isGrounded)
            {
                print("Tocaste la perra pantalla");
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -5.0f * gravityValue);

                playerVelocity.y += gravityValue * Time.deltaTime;

                m_Character.Move(playerVelocity * Time.deltaTime);
                m_Animator.SetTrigger("brincar");

            }



        }
   




    }

    void OnAnimatorMove()
    {

        // Changes the height position of the player..
       

        m_Rigidbody.MoveRotation(m_Rotation);

        //  m_Movement.y -= 9f * Time.deltaTime;
        m_Move.y -= 80f * Time.deltaTime;

       m_Character.Move(m_Move * 4 * Time.deltaTime);
        //  m_Rigidbody.MovePosition(m_Rigidbody.position +m_Move * Time.deltaTime );


    }

    public void hacerMagia()
    {
        // m_Movement.y = 8f;

        m_Animator.Play("lanzar");
        ///   torpedo = Instantiate(torpedo, new Vector3(transform.position.x, transform.position.y + 2.8f, transform.position.z), Quaternion.identity);
        //  bola.transform.rotation = Quaternion.LookRotation(shoot);

        //  torpedo.GetComponent<Rigidbody>().AddForce( shoot.normalized* 900.0f);
        //  torpe.AddForce(shoot * 200f, ForceMode.Force);

        m_Animator.SetTrigger("haceMagia");





    }

    public void brincar()
    {
        playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);

        playerVelocity.y += gravityValue * Time.deltaTime;

        m_Character.Move(playerVelocity * Time.deltaTime);
        m_Animator.SetTrigger("brincar");
    }


    
    
   
}

