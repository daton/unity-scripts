using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCarrito : MonoBehaviour
{
    // Start is called before the first frame update
    CinemachineDollyCart carrito;
    void Start()
    {
        carrito = GetComponent<CinemachineDollyCart>();
        carrito.m_Speed = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
