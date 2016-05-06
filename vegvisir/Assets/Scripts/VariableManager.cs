using UnityEngine;
using System.Collections;

public class VariableManager : MonoBehaviour {
    [SerializeField]
    private EstadisticasManager estadisticas;
	public int sangre = 0;
	public int hambre = 0;
	public int fiesta = 0;
	public int poblacion = 1000;
	public int dias = 0;

	public void aumentarSangre(int cantidad){
		sangre += cantidad;
        estadisticas.refresh();
	}
	public void disminuirSangre(int cantidad){
        if (sangre <= 0)
        {
            sangre -= cantidad;
            estadisticas.refresh();
        }
    }


	public void aumentarHambre(int cantidad){
		hambre += cantidad;
        estadisticas.refresh();
    }
	public void disminuirHambre(int cantidad){
        if (hambre <= 0)
        {
            hambre -= cantidad;
            estadisticas.refresh();
        }
    }


	public void aumentarFiesta(int cantidad){
		fiesta += cantidad;
        estadisticas.refresh();
    }
	public void disminuirFiesta(int cantidad){
        if (fiesta <= 0)
        {
            fiesta -= cantidad;
            estadisticas.refresh();
        }
    }


	public void aumentarPoblacion(int cantidad){
		poblacion += cantidad;
        estadisticas.refresh();
    }
	public void disminuirPoblacion(int cantidad){
		poblacion -= cantidad;
        estadisticas.refresh();
    }

	public void variablesNuevoDia(){
		
		int random = Random.Range (0,3);

		if (random == 0){
            aumentarSangre(1);
		}else if(random == 1){
            aumentarHambre(1);
		}else if(random == 2) {
            aumentarFiesta(1);
		}

		int variacionPoblacion = (int)Mathf.Round((poblacion * Random.Range(-5,5))/100);
        aumentarPoblacion(variacionPoblacion);

        dias++;

	}

}
