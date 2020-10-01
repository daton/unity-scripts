using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Models
{
	[Serializable]
	public class Estatus
	{
	
		public string mensaje;

		public bool success;
		public Examen examen;

		public override string ToString(){
			return UnityEngine.JsonUtility.ToJson (this, true);
		}
	}
}