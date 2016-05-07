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
    void start()
    {
        if(PlayerPrefs.GetInt("Dias")!=0){
            sangre = PlayerPrefs.GetInt("Sangre");
            hambre = PlayerPrefs.GetInt("Hambre");
            fiesta = PlayerPrefs.GetInt("Fiesta");
            poblacion = PlayerPrefs.GetInt("Poblacion");

            estadisticas.refresh();
        }
    }
	public void aumentarSangre(int cantidad){
		sangre += cantidad;
        estadisticas.refresh();
        PlayerPrefs.SetInt("Sangre", sangre);
    }
	public void disminuirSangre(int cantidad){
        if (sangre >= cantidad)
        {
            sangre -= cantidad;
        }
        else
        {
            sangre = 0;
        }
        estadisticas.refresh();
        PlayerPrefs.SetInt("Sangre", sangre);
    }


	public void aumentarHambre(int cantidad){
		hambre += cantidad;
        estadisticas.refresh();
        PlayerPrefs.SetInt("Hambre", hambre);
    }
	public void disminuirHambre(int cantidad){
        if (hambre >= cantidad)
        {
            hambre -= cantidad;
        }
        else
        {
            hambre = 0;
            
        }
        estadisticas.refresh();
        PlayerPrefs.SetInt("Hambre", hambre);
    }


	public void aumentarFiesta(int cantidad){
		fiesta += cantidad;
        estadisticas.refresh();
        PlayerPrefs.SetInt("Fiesta", fiesta);
    }
	public void disminuirFiesta(int cantidad){
        if (fiesta >= cantidad)
        {
            fiesta -= cantidad;
        }
        else
        {
            fiesta = 0;
        }
        PlayerPrefs.SetInt("Fiesta", fiesta);
    }


	public void aumentarPoblacion(int cantidad){
		poblacion += cantidad;
        estadisticas.refresh();
        PlayerPrefs.SetInt("Poblacion", poblacion);
    }
	public void disminuirPoblacion(int cantidad){
        if (poblacion >= cantidad)
        {
            poblacion -= cantidad;
        }
        else
        {
            poblacion = 0;
        }
        PlayerPrefs.SetInt("Poblacion", poblacion);
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
        PlayerPrefs.SetInt("Dias", dias);

	}

}
