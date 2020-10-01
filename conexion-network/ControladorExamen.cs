using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.Networking;
using Models;

using TMPro;
using UnityEngine.UI;

public class ControladorExamen : MonoBehaviour
{

     public TextMeshProUGUI textopreguntas;

    //public Text textopreguntas;
    public Estatus e;
  
 
    public ToggleGroup toggleGroup;
    public List<Toggle> toggles;
 int i ;

  public void Descargarexamen()
    {
        //
        print("Pregunta numero "+i);
        if(i<e.examen.preguntas.Count){
textopreguntas.text = e.examen.preguntas[i].titulo;
         
           int op=0;
            e.examen.preguntas[i].opciones.ForEach(opcion =>
            {
                // Esto es en el caso de que se generen en automatico


                //  GameObject togle = (GameObject)Instantiate(togglePrefab);
               // toggles[i].transform.SetParent(panel.transform);//Setting button parent
                   toggles[op].GetComponentInChildren<TextMeshProUGUI>().text = opcion.titulo;
                toggles[op].GetComponentInChildren<Toggle>().isOn = false;
                toggles[op].GetComponentInChildren<Toggle>().group = toggleGroup;
                op++;

            });
i++;
        }else{
              SceneManager.LoadScene("PlanetaAlien", LoadSceneMode.Single);
        }


    }

    IEnumerator ConectarseAHeroku(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();


            if (webRequest.isNetworkError)
            {
                print(": Error de conexion: " + webRequest.error);
            }
            else
            {
                print(":\nRecibido: " + webRequest.downloadHandler.text);
            }

            string valor = webRequest.downloadHandler.text;
            e = JsonUtility.FromJson<Estatus>(valor);
            print("valor es " + e.mensaje);
            textopreguntas.text = e.examen.preguntas[i].titulo;
         
           int op=0;
            e.examen.preguntas[i].opciones.ForEach(opcion =>
            {
                // Esto es en el caso de que se generen en automatico


                //  GameObject togle = (GameObject)Instantiate(togglePrefab);
               // toggles[i].transform.SetParent(panel.transform);//Setting button parent
                toggles[op].GetComponentInChildren<TextMeshProUGUI>().text = opcion.titulo;
                toggles[op].GetComponentInChildren<Toggle>().isOn = false;
                toggles[op].GetComponentInChildren<Toggle>().group = toggleGroup;
                op++;

            });
   

    //Incrementmos el indice de la pregunta
    i++;



        }
    }

    
    void Start()
    {
        Screen.orientation=ScreenOrientation.Portrait;

          i=0;
        print("Al iniciar..");
        StartCoroutine(ConectarseAHeroku("https://geradmin.herokuapp.com/api/examen-juego/gera/1234"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void cambiar(string escena){
   SceneManager.LoadScene(escena, LoadSceneMode.Single);
    }

  
}
