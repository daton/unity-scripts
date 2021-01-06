using DigitalRubyShared;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TocasteJoystick : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject camaravirtual;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  public void activarDosToques()
    {
        camaravirtual.GetComponent<FingersRotateCameraComponentScript>().NumberOfTouchesRequired = 2;
    }
    public void activarUnToque()
    {
        camaravirtual.GetComponent<FingersRotateCameraComponentScript>().NumberOfTouchesRequired = 1;
    }
}
