using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VentanasController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void abrir()
    {
        panel.SetActive(true);

        //Pausamos el videojueg, sio te va a estar mate y mate
        Time.timeScale = 0.0f;
    }

    public void cerrar()
    {
        panel.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
