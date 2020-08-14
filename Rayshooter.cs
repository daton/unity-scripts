using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Rayshooter : MonoBehaviour
{
    public AudioSource audioDisparo;
    public AudioClip clipDisparo;

    public GameObject prefab;
    public GameObject cubo;
    PlayableDirector playable;

    public GameObject tarjetRojo;
    public GameObject tarjetAzul;

    public BarraSaludable barra;





    Camera camara;
    public GameObject proyectil;

    //Declaramos el objeto que es nuestro target
    public GameObject target;


    void Start()
    {
        playable = GetComponent<PlayableDirector>();
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
            audioDisparo.PlayOneShot(clipDisparo);

            //Invocamos la animacion de nuestro timeline
            playable.Play();
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
                //Ultimo paso: Donde golpeó indicarle que imprima una fuerza en la direccion
                //del disparo para simular el efecto de impacto de la bala
                Rigidbody rb = golpe.transform.gameObject.GetComponent<Rigidbody>();
                //En el metodo AddForce debe de ir el vector de posicion del cubo
                //CON RESPECTO A LA RETICULA porque en esa direccion debe salir disparado el cubo
                Vector3 vec = target.transform.position - transform.position;

                rb.AddForce(vec.normalized * 500);
                //Primero descontamos las vidas si el obejto golpeado es
                //el boque rojo
                if(golpe.transform.gameObject==tarjetRojo){
                    //Nos va a descontar 5 puntos
                    AnimacionesZombis.maximoVidas=AnimacionesZombis.maximoVidas-5;
                    //Le pasamos el nuevo valor de maximoVidas a la barra de salud
                    barra.setVidas(AnimacionesZombis.maximoVidas);
                }
                if(golpe.transform.gameObject==tarjetAzul){
                    //Este nos dara 5 puntos!!
                    AnimacionesZombis.maximoVidas=AnimacionesZombis.maximoVidas+5;
                    barra.setVidas(AnimacionesZombis.maximoVidas);
                }
            

            }

        }
    }
}
