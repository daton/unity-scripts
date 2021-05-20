using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DormirDragon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform posicion;
    bool FueTocado = false;
    Animator animator;
 

    void Start()
    {
        //  GameObject dragonsito = this.transform.GetChild(0).gameObject;
        //  transform.DetachChildren();
        //   dragonsito.transform.position = posicion.position;
        animator = this.gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FueTocado)
        {
            // transform.LookAt(posicion.position);
            Vector3 direccion = posicion.position - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(direccion), Time.deltaTime * 0.8f);
            this.transform.position = Vector3.MoveTowards(transform.position, posicion.position, Time.deltaTime * 1.5f);
            if (this.transform.position == posicion.position)
            {
                animator.SetBool("YaLlego", true);
            }
            else
            {
                animator.SetBool("YaLlego", false);
            }
            

          
           
        }
    }

    private void OnCollisionEnter(Collision colision)
    {
        if (colision.transform.gameObject.tag == "Player")
        {
            FueTocado = true;

            print("LLego");
            // Transform carrito = this.gameObject.transform.parent;
            //  carrito.DetachChildren();
            this.transform.SetParent(null);
            

           // gameObject.transform.position = posicion.position;
        }
    }


}
