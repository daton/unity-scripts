using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiFrameRate : MonoBehaviour
{
    // Start is called before the first frame update

    public int target = 60;
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        print("RATE INIIAL " + Application.targetFrameRate);
        Application.targetFrameRate = target;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (target != Application.targetFrameRate)
        {
            Application.targetFrameRate = target;
            print("el rate es " + Application.targetFrameRate);
        }
        */
    }
}
