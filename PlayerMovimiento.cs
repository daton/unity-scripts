using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerMovimiento : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    public float speed = 9.5f;
    public float gravedad = 9.81f;
    Vector3 velocidad;
    Rigidbody puto;

    public float distanciaPiso = 0.4f;


     public AudioSource audio;
    public float stepRate = 0.5f;
    public float stepCoolDown;
    public AudioClip clipPasos;




    void Start()
    {
 
   
    }

    // Update is called once per frame

    void Update()
    {

        stepCoolDown -= Time.deltaTime;
        if ((Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f) && stepCoolDown < 0f)
        {
            audio.pitch = 1f + Random.Range(-0.2f, 0.2f);
            audio.PlayOneShot(clipPasos, 0.9f);
            stepCoolDown = stepRate;
        }

        if (controller.isGrounded)
        {

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");


          

          velocidad = transform.right * x + transform.forward * z;
            controller.Move(velocidad * speed * Time.deltaTime);
            if (Input.GetButtonDown("Jump"))
            {
                velocidad.y = 6.5f;
                print("Ha brincar");
            }
        }
        velocidad.y -= gravedad*Time.deltaTime;
        controller.Move(velocidad * Time.deltaTime);

    }
 

        
    }

