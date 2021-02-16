using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMalo : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject proyectil;
    public GameObject player;
    public GameObject escudo;
    GameObject proye;
    public Transform pos;
    int golpes = 0;

    float distanciaDragon;
    void Start()
    {
        InvokeRepeating("LanzarProyectil", 5, 3.0f);
    }
    void LanzarProyectil()
    {
        //Checamos antes la distancia del player a el dragon para saber si le lanza fuego.
        distanciaDragon = Vector3.Distance(player.transform.position, transform.position);
        if (distanciaDragon <= 20)
        {
            proye = Instantiate(proyectil, pos.position, Quaternion.identity);
            Rigidbody rb = proye.GetComponent<Rigidbody>();
            //  rb.velocity = Random.insideUnitSphere * 5;
            Vector3 direccion = player.transform.position - pos.position;
            direccion = Vector3.Normalize(direccion);
            rb.velocity = direccion * 10;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (proye != null)
        {
            if (Vector3.Distance(proye.transform.position, escudo.transform.position) <= 1.8f)
            {
                Destroy(proye);
            }

        }

    }
}
