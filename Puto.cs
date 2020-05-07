using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Puto : MonoBehaviour
{
    public float turnSpeed = 20f;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;
    public Text texto;
    float horizontal;
    float vertical;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        float posicionX = transform.right.magnitude;

        // float horizontal = Input.GetAxis("Horizontal");
         horizontal = UltimateJoystick.GetHorizontalAxis("Movimiento")*Camera.main.transform.right.x;
        //  float vertical = Input.GetAxis("Vertical")*Camera.main.transform.f.x;
        vertical = UltimateJoystick.GetVerticalAxis("Movimiento")* Camera.main.transform.forward.z;
      
     


        m_Movement.Set(horizontal, 0f, vertical);

        m_Movement.Normalize();
      //  m_Movement = transform.TransformDirection(m_Movement);
  
           

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("IsWalking", isWalking);
        texto.text="Posicion en x "+ Camera.main.transform.right.x;


    
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
  

        m_Rotation = Quaternion.LookRotation(desiredForward);
     

     



    }


    void OnAnimatorMove()
    {
      //  texto.text = "x " + m_Rigidbody.position.x + m_Movement.x;
 
        
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * Time.deltaTime*1.5f);
        m_Rigidbody.MoveRotation(m_Rotation);
       
    }
}