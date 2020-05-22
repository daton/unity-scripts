using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimentoTPS : MonoBehaviour
{


    public float turnSpeed = 20f;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    CharacterController caracter;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;
    public Text texto;
    float horizontal;
    float vertical;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        caracter = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {

        float posicionX = transform.right.magnitude;

        // float horizontal = Input.GetAxis("Horizontal");
        //La expresion Camera.main.transform.right.x nos da la vita de la camara colocando siempre
        //la camara hacia la derecha del eje de las x (positivo derecha o sea (1), izquierda sera (-1)
      float deltaX = UltimateJoystick.GetHorizontalAxis("Movimiento") * Camera.main.transform.right.x;

     float   deltaZ = UltimateJoystick.GetVerticalAxis("Movimiento") * Camera.main.transform.forward.z;

     

        m_Movement = new Vector3(deltaX, 0, deltaZ);
        m_Movement = Vector3.ClampMagnitude(m_Movement, 8);
      //  m_Movement = transform.TransformDirection(m_Movement);


       // m_Movement.Set(, 0f, vertical);

      //  m_Movement.Normalize();




        bool hasHorizontalInput = !Mathf.Approximately(deltaX, 0f);
        bool hasVerticalInput = !Mathf.Approximately(deltaZ, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("IsWalking", isWalking);
      //  texto.text = "Posicion en x " + Camera.main.transform.right.x;



        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);


        m_Rotation = Quaternion.LookRotation(desiredForward);






    }

    public void brincar()
    {
        m_Movement.y = 8f;
    
        print("Brincar");
    }

    void OnAnimatorMove()
    {

        m_Movement.y -= 9f * Time.deltaTime;

        caracter.Move(m_Movement * 6 * Time.deltaTime);
        //   m_Rigidbody.MovePosition(m_Rigidbody.position +m_Movement * Time.deltaTime );
        m_Rigidbody.MoveRotation(m_Rotation);

    }
}