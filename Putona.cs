using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Putona : MonoBehaviour
{

    Rigidbody rb;
    CharacterController caracter;
    Vector3 vecMovimiento;

    float horizontal;
    float vertical;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        caracter = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (caracter.isGrounded)
        {
            float deltaX = UltimateJoystick.GetHorizontalAxis("Movimiento") * 6 * Time.deltaTime ;
            float deltaZ = UltimateJoystick.GetVerticalAxis("Movimiento") * 6 * Time.deltaTime ;


            vecMovimiento = new Vector3(deltaX, 0, deltaZ);
            vecMovimiento = Vector3.ClampMagnitude(vecMovimiento, 10);
            vecMovimiento = transform.TransformDirection(vecMovimiento);
            if (Input.GetButtonDown("Jump")) vecMovimiento.y = 3.5f;

        }
        vecMovimiento.y -= 9.8f * Time.deltaTime;
        caracter.Move(vecMovimiento * 6 * Time.deltaTime);


    }
}
