
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public  class Multiplicaciones {
    

/*
Generacion de multiplicaciones al azar
*/
    public Tabla generarMultiplicacion(){
        //Todas las tablas
        Tabla t11=new Tabla("1x1","1");
         Tabla t12=new Tabla("1x2","2");

         Tabla t33=new Tabla("3x3", "9");
         Tabla t34=new Tabla("3x4","12");
         Tabla t35=new Tabla("3x5","15");
          Tabla t36=new Tabla("3x6","18");
           Tabla t37=new Tabla("3x7","21");
            Tabla t38=new Tabla("3x8","24");
             Tabla t39=new Tabla("3x9","27");
              Tabla t310=new Tabla("3x10","30");

             Tabla t41=new Tabla("4x1","4");
              Tabla t42=new Tabla("4x2","8");

   Tabla []tablas={t11,t12, t33,t34,t35,t36,t37,t38,t39,t310,t41,t42};
      //  Generacion al azar

 
    return generarTablaAlAzar(tablas);
    }

    //El siguiente método es para checar si el resultado es el correcto
    public bool checarRespuesta(Tabla tabla, long respuesta){
       bool esCorrecta=false;
       try{
   
      long valorTabla=long.Parse(tabla.resultado);
      if(respuesta==valorTabla &&tabla!=null)esCorrecta=true;
       }catch(System.Exception e){
           esCorrecta=false;
       }

       return esCorrecta;
    }
    public Tabla generarTablaAlAzar(Tabla []tablas){
        Tabla tabla=null;
       int indiceAleatorio= Random.Range(0,tablas.Length-1);
        tabla=tablas[indiceAleatorio];
        return tabla;
    }
}
