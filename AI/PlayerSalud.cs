using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerSalud : MonoBehaviour
{
    // Start is called before the first frame update
    BarraSaludable barraSaludable;
    public GameObject objetoBarra;
    public int vidas = 60;
    Animator animator;
    public static bool estaVivo;
  

    void Start()
    {

        estaVivo = true;
        

        barraSaludable = objetoBarra.GetComponent<BarraSaludable>();

        barraSaludable.setMaximoVidas(vidas);
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "mazo" && estaVivo)
        {
            vidas = vidas - 5;

            barraSaludable.setVidas(vidas);
       
            if (vidas <= 0)
            {
                print("las vidas deben ser 0 o menos"+vidas);
              
                animator.Play("morir");
            
                estaVivo = false;
            }
        }
    }
}
