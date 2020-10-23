using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Cinemachine.Utility;
using static Cinemachine.CinemachineSmoothPath;
using SpeechBubbleManager = VikingCrew.Tools.UI.SpeechBubbleManager;
using UnityEngine.Assertions.Must;

public class CarritoPosicion : MonoBehaviour
{
    // Start is called before the first frame update

    //  CinemachineTrackedDolly trackedDolly;
    CinemachineVirtualCamera cv;
    CinemachineTrackedDolly dolly;
    public Transform mouth;
    bool pasoElPunto = false;
    int puntos=1;

    void Start()
    {

      cv = GetComponent<CinemachineVirtualCamera>();
        // float x=    trackedDolly.m_PathPosition;
dolly=    cv.GetCinemachineComponent<CinemachineTrackedDolly>();

    }

    // Update is called once per frame
    void Update()
    {
       // print("aj " + dolly.m_PathPosition);
       
        if (dolly.m_PathPosition>=puntos && puntos<9)
        {
            SpeechBubbleManager.Instance.AddSpeechBubble(mouth, "Haz pasado por el punto!"+puntos);
            print("HAS PASADO CERCAAAA del punto "+puntos);
            puntos++;
            pasoElPunto = false;
        }
        if (dolly.m_PathPosition >= 9) puntos = 1;
   
    }
}
