using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavegacionBasica : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform objetivo;
    void Start()
    {
        NavMeshAgent agente = GetComponent<NavMeshAgent>();
        agente.destination = objetivo.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
