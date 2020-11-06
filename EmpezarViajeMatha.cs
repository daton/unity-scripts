using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Cinemachine.Utility;
public class EmpezarViajeMatha : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dollycart;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EmpezarViaje(){
     CinemachineDollyCart cart=   dollycart.GetComponent<CinemachineDollyCart>();
     cart.m_Speed=20.5f;
    }

    public void DetenerViaje(){
         CinemachineDollyCart cart=   dollycart.GetComponent<CinemachineDollyCart>();
     cart.m_Speed=0f;
    }
}
