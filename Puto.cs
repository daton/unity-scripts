using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puto : MonoBehaviour
{
    public float turnSpeed = 20f;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // float horizontal = Input.GetAxis("Horizontal");
        float horizontal = -UltimateJoystick.GetHorizontalAxis("Movimiento");
        //  float vertical = Input.GetAxis("Vertical");
        float vertical = -UltimateJoystick.GetVerticalAxis("Movimiento");

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("IsWalking", isWalking);

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);




    }


    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * Time.deltaTime*0.5f);
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}