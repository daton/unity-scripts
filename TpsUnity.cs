using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpsUnity : MonoBehaviour
{

    CharacterController m_Character; // A reference to the ThirdPersonCharacter on the object
    private Transform m_Cam;                  // A reference to the main camera in the scenes transform
    private Vector3 m_CamForward;             // The current forward direction of the camera
    private Vector3 m_Move;
    Animator m_Animator;
    Rigidbody m_Rigidbody;
    public Rigidbody torpedo;
    public float turnSpeed = 20f;
    Quaternion m_Rotation = Quaternion.identity;
    public GameObject cama;
    public GameObject bola;
    public Vector3 shoot;

    // Start is called before the first frame update
    void Start()
    {
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
    private void FixedUpdate()
    {
        // read inputs
        float h = UltimateJoystick.GetHorizontalAxis("Movimiento");
        float v = UltimateJoystick.GetVerticalAxis("Movimiento");
   

        // calculate move direction to pass to character
        if (m_Cam != null)
        {
            // calculate camera relative direction to move:
            m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
            m_Move = v * m_CamForward + h * m_Cam.right;
        }
        else
        {
            // we use world-relative directions in the case of no main camera
            m_Move = v * Vector3.forward + h * Vector3.right;
        }
        bool hasHorizontalInput = !Mathf.Approximately(h, 0f);
        bool hasVerticalInput = !Mathf.Approximately(v, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("IsWalking", isWalking);

        shoot = (cama.transform.position - transform.position).normalized;
        bola.transform.rotation = Quaternion.LookRotation(shoot);
        shoot = (cama.transform.position - this.transform.position).normalized;


        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Move, turnSpeed * Time.deltaTime, 0f);


        m_Rotation = Quaternion.LookRotation(desiredForward);

        // pass all parameters to the character control script
     //   m_Character.Move(m_Move*4 * Time.deltaTime);
       // m_Jump = false;
    }

    void OnAnimatorMove()
    {
        m_Rigidbody.MoveRotation(m_Rotation);

        //  m_Movement.y -= 9f * Time.deltaTime;
        m_Move.y -= 9f * Time.deltaTime;

        m_Character.Move(m_Move * 6 * Time.deltaTime);
        //   m_Rigidbody.MovePosition(m_Rigidbody.position +m_Movement * Time.deltaTime );


    }

    public void brincar()
    {
        // m_Movement.y = 8f;

        m_Animator.Play("lanzar");
        torpedo = Instantiate(torpedo, new Vector3(transform.position.x, transform.position.y + 2.8f, transform.position.z), Quaternion.identity);
        //  bola.transform.rotation = Quaternion.LookRotation(shoot);

        torpedo.rotation = Quaternion.LookRotation(shoot);
        //l siguiente es el tiro parabolico

        torpedo.GetComponent<Rigidbody>().AddForce(shoot.normalized * 900.0f);

        //  torpedo.GetComponent<Rigidbody>().AddForce( shoot.normalized* 900.0f);
        //  torpe.AddForce(shoot * 200f, ForceMode.Force);








    }

}
