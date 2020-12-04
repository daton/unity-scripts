using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;

using UnityEngine.Networking;
using System;
using Modelos;
using TMPro;
using UnityEngine.UI;



public class Cocodrilo : MonoBehaviour
{
    // Start is called before the first frame update
    	private RequestHelper currentRequest;
        string basePath="http://192.168.100.85:9000/api";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
//Para conectarnos a un back end en unity vamos a usar una estructura en unity  conocida coo corutina
//IEnumerator conectarseABackend(string uri){
    //A continuación viene el código de conexion al back-end donde en primer lugar
    //nos vamos a registrar!!


//}

public void Postear(){

	
		currentRequest = new RequestHelper {
			Uri = basePath + "/usuario",
			
			Body = new Usuario {
				nickname = "topoyiyo",
				email = "rapidclim@outlook.com",
		
			},
			EnableDebug = true
		};
		RestClient.Post<Usuario>(currentRequest)
		.Then(res => {

			// And later we can clear the default query string params for all requests
			RestClient.ClearDefaultParams();

			print( JsonUtility.ToJson(res, true));
		})
		.Catch(err => print(err.Message));
	}

    public void Obtener(){
     
            RestClient.GetArray<Usuario>(basePath + "/usuario").Then(res => {
		print("Son "+JsonHelper.ArrayToJsonString<Usuario>(res, true));
        print("Son estos"+res.Length);
        print("Es este "+res[0].nickname);
			return RestClient.GetArray<Usuario>(basePath + "/usuario");
		}).Catch(err => print("Hubo algo malo"+err.Message));

    }

}