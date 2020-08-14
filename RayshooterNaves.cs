using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rayshooter : MonoBehaviour
{
  

    Camera camara;
    public GameObject explosion;


    void Start()
    {
     
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        camara = GetComponent<Camera>();

    }


    // Update is called once per frame
    void Update()
    {
        //Programamos el disparo con el mouse izquierdo, como con la granada
        if (Input.GetMouseButtonDown(0))
        {
           
            //Inicia la tecnica del Raycasting
            //Primero obtenemos el punto donde esta la mira del disparo (es la imagen de la reticula)
            //Obtenemos el vector de posicion de esa mira porque es el punto de saida del disparo
            Vector3 p1 = new Vector3(camara.pixelWidth / 2, camara.pixelHeight / 2, 0);
            //Declaramos una variable que es la direccion del rayo proyectado
            RaycastHit golpe;
            //El siguiente paso es generar el rayo que DEBE originarse en el punto p1.
            Ray rayo = camara.ScreenPointToRay(p1);
            //El siguiete if pregunta si ese rayo pego con una superficie (colliders)
            if (Physics.Raycast(rayo, out golpe))
            {
                //Pegamos en algo que tiene collider
                //Vamos a poner primero un objeto en este punto para ver si pegamos en el lugar
                //que apuntamos.
                print("CHOCO CON UN COLLIDER");
                //   Instantiate<GameObject>(proyectil, golpe.point, Quaternion.identity);
           
           


                Instantiate<GameObject>(explosion, golpe.point, Quaternion.identity);

                //Primero descontamos las vidas si el obejto golpeado es
                //el boque rojo
                if (golpe.transform.gameObject.tag == "meteorito")
                {
                    Destroy(golpe.transform.gameObject);
                }
               


            }

        }
    }
}