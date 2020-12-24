using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControlador : MonoBehaviour
{
 //   CharacterController m_Character; // A reference to the ThirdPersonCharacter on the object
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
    public float jumpHeight = 1.6f;
    private float gravityValue = -5.8f;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private bool IsGrounded;
   public  GameObject flecha;



    private float waitTime = 2.0f;
    private float timer = 0.0f;
    private float visualTime = 0.0f;
    private float scrollBar = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "malo")
        {

            //  m_Animator.SetTrigger("brincar");
            //    m_Character.Move(Vector3.up.normalized * Time.fixedDeltaTime*20);
            m_Rigidbody.AddForce(Vector3.up * Time.deltaTime * 3000, ForceMode.Force);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
    //    m_Rigidbody.isKinematic = true;
        //   Screen.fullScreen = !Screen.fullScreen; 
        //https://docs.unity3d.com/ScriptReference/DeviceType.html
        // El siguiente para ve en andrioid etc si sirve pero en faceboo se sierra
        // txtCliente.SetText("Cliente: " + SystemInfo.operatingSystem);
        botonOprimido = false;
       
      
            m_Cam = Camera.main.transform;
        
     
        //   m_Rigidbody = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();
     //   m_Character = GetComponent<CharacterController>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        print("esta en tierrraaa " + IsGrounded);
   
        /*

        groundedPlayer = m_Character.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        */
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
   
        m_Move.Normalize();
  

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Move, turnSpeed * Time.deltaTime, 0f);


        m_Rotation = Quaternion.LookRotation(desiredForward);
    


        if (ControlFreak2.CF2Input.GetButtonDown("Jump")&& IsGrounded)
        {
       


            print("Tocaste la perra pantalla");
            //     playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);

            //   playerVelocity.y += gravityValue * Time.deltaTime;
            //     m_Move.x *= m_Move.y * Time.deltaTime;

           
                m_Rigidbody.AddForce(Vector3.up * 700, ForceMode.Force);
                //  m_Character.Move(playerVelocity * Time.deltaTime);
                m_Animator.SetTrigger("brincar");

           
           



        }
   




    }


    private void OnCollisionStay(Collision collision)
    {
        print(" Entra al trigger");
        if (collision.transform.tag == "Ground")
        {
            IsGrounded = true;
            Debug.Log("Grounded");
        }
        else
        {
            IsGrounded = false;
            Debug.Log("Not Grounded!");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        IsGrounded = false;
        Debug.Log("Not Grounded!");
    }


    void OnAnimatorMove()
    {
        
            m_Rigidbody.MovePosition(m_Rigidbody.position + m_Move * m_Animator.deltaPosition.magnitude);
            m_Rigidbody.MoveRotation(m_Rotation);
        

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

        if (IsGrounded)
        {


            m_Rigidbody.AddForce(flecha.transform.forward*300, ForceMode.Force);
            m_Animator.SetTrigger("brincar");
  
        }

     
    }


    
    
   
}

