using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class ControladorConexion :MonoBehaviour
{

    //local data
    string nombreMision = "";


    // Start is called before the first frame update
    public Estatus e;

    public TMP_InputField txtnombreMision;
    string fullPath;
    bool encrypt = false;

    //for debug purpose only
    static string logText = "";
    Mision misionValores = new Mision();
    void Awake()
    {
        //the filename where saved data will be stored
        fullPath = Application.persistentDataPath + "/" + "ArchivoNavutan";
    }

    public void cargarValoresJugo()
    {
#if JSONSerializationFileSave || BinarySerializationFileSave
        logText += "\nCargado iniciado (Archivo): " + fullPath;
#else
        logText += "\nLoad Started (PlayerPrefs): " + fullPath;
#endif
        SaveManager.Instance.Load<Mision>(fullPath, DatosFueronCargados, encrypt);
    }

    public void guardarDatos()
    {
        logText += "\nGuardado iniciado";

        //Obtenemos del valor del campos de texto 
       
       

        misionValores.nombre = txtnombreMision.text;
        print("La mision a guardarse con nombre " + misionValores.nombre);
        SaveManager.Instance.Save(misionValores, fullPath, DatosFueronGuardados, encrypt);
    
}
    private void DatosFueronGuardados(SaveResult result, string message)
    {
        logText += "\nDatos guardados";
        logText += "\nresultado: " + result + ", mensaje: " + message;
        if (result == SaveResult.Error)
        {
            logText += "\nError guardando datos";
        }
    }
    public void Clear()
    {
        logText += "\nLimpiar";
        SaveManager.Instance.ClearFIle(fullPath);
    }

    public void ClearLog()
    {
        logText = "";
    }
    private void DatosFueronCargados(Mision mision, SaveResult result, string message)
    {
        logText += "\nLos Datos fueroncargados";
        logText += "\nresultado: " + result + ", mensaje: " + message;

        if (result == SaveResult.EmptyData || result == SaveResult.Error)
        {
            logText += "\nArchivo de datos no encontrado -> Creando nuevos datos...";
            misionValores = new Mision();
        }

        if (result == SaveResult.Success)
        {
            misionValores = mision;
        }
        nombreMision =misionValores.nombre;
        //Aqui irian las siguiente asignacioness del objeto local Mision
        txtnombreMision.text = "Cargado " + misionValores.nombre;
    }



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
            //   print("valor es " + e.mensaje);
            //     textopreguntas.text = e.examen.preguntas[i].titulo;

            int op = 0;
            //   e.examen.preguntas[i].opciones.ForEach(opcion =>
            //  {
            // Esto es en el caso de que se generen en automatico


            //  GameObject togle = (GameObject)Instantiate(togglePrefab);
            // toggles[i].transform.SetParent(panel.transform);//Setting button parent
            //  toggles[op].GetComponentInChildren<TextMeshProUGUI>().text = opcion.titulo;
            // toggles[op].GetComponentInChildren<Toggle>().isOn = false;
            //  toggles[op].GetComponentInChildren<Toggle>().group = toggleGroup;
            //  op++;

            //  });


            //Incrementmos el indice de la pregunta
            // i++;



        }
    }


}

