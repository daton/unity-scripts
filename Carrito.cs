using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.CinemachineSmoothPath;

public class Carrito : MonoBehaviour
{
    // Start is called before the first frame update
    CinemachineDollyCart carrito;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Primera")
        {
            print("Pasaste por el primer waypoint");
        }
    }
}
