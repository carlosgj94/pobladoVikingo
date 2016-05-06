using UnityEngine;
using System.Collections;

public class VariableManager : MonoBehaviour {

	public int sangre = 0;
	public int hambre = 0;
	public int fiesta = 0;
	public int poblacion = 1000;
	public int dias = 1;

	public void aumentarSangre(int cantidad){
		sangre += cantidad;
	}
	public void disminuirSangre(int cantidad){
		sangre -= cantidad;
	}


	public void aumentarHambre(int cantidad){
		hambre += cantidad;
	}
	public void disminuirHambre(int cantidad){
		hambre -= cantidad;
	}


	public void aumentarFiesta(int cantidad){
		fiesta += cantidad;
	}
	public void disminuirFiesta(int cantidad){
		fiesta -= cantidad;
	}


	public void aumentarPoblacion(int cantidad){
		poblacion += cantidad;
	}
	public void disminuirPoblacion(int cantidad){
		poblacion -= cantidad;
	}

	public void variablesNuevoDia(){
		
		int random = Random.Range (0,2);

		if (random == 0){
			sangre++;
		}else if(random == 1){
			hambre++;
		}else if(random == 2) {
			fiesta++;
		}

		int variacionPoblacion = (int)Mathf.Round((poblacion * Random.Range(-5,5))/100);
		poblacion += variacionPoblacion;

	}

}
