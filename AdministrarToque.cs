using DigitalRubyShared;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AdministrarToque : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject camaravirtual;
    public TextMeshProUGUI texto;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void desactivar()
    {
      //  camaravirtual.GetComponent<FingersRotateCameraComponentScript>().
    }

    public void activar()
    {
        //camaravirtual.GetComponent<FingersRotateCameraComponentScript>().gameObject.SetActive(true);
        print("Tocaste este cubito");
        texto.text = "Tocaste el " + this.transform.gameObject.name;
    }
}
